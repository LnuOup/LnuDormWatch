using LDW.Application;
using LDW.Application.Interfaces.Services;
using LDW.Domain.Entities;
using LDW.Domain.Entities.Options;
using LDW.Domain.Interfaces.Services;
using LDW.Persistence;
using LDW.Persistence.Context;
using LDW.Persistence.Services;
using LDW.Persistence.Settings;
using LDW.WebAPI.Filters;
using LDW.WebAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace LDW.WebAPI
{
    public class Startup
    {
        private const string TOKEN = "token";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SmtpOptions>(Configuration.GetSection("SmtpConfig"));
            services.Configure<AzureStorageOptions>(Configuration.GetSection("AzureStorageConfig"));
            services.Configure<EnvironmentSettings>(Configuration.GetSection("ClientEnvironment"));

            services.AddMvc(options => { options.Filters.Add<GlobalExceptionFilter>(); });

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerFileOperationFilter>();
                c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\LnuDormWatch.xml");
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "LnuDormWatch",
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Scheme = "Bearer", 
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });
            });
            #endregion

            #region API Versioning
            // Add API Versioning to the Project
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
            #endregion

            services.AddCors();
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddIdentityContext(Configuration);
            services.AddControllers();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IImageService, ImageService>();
            #region Identity
            services.AddIdentity<UserEntity, IdentityRole>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();
            #endregion
            
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtOptions));

            var _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["SecretKey"]));
            
            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtOptions.Audience)];
                options.TokenExpireInMinutes = int.Parse(jwtAppSettingOptions[nameof(JwtOptions.TokenExpireInMinutes)]);
                options.RefreshTokenExpireInDays = int.Parse(jwtAppSettingOptions[nameof(JwtOptions.RefreshTokenExpireInDays)]);
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtAppSettingOptions[nameof(JwtOptions.Issuer)],
                        ValidateAudience = true,
                        ValidAudience = jwtAppSettingOptions[nameof(JwtOptions.Audience)],
                        ValidateLifetime = true,
                        IssuerSigningKey = _signingKey,
                        ValidateIssuerSigningKey = true
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Query.ContainsKey(TOKEN))
                            {
                                context.Token = context.Request.Query[TOKEN];
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var envSettings = Configuration.GetSection("ClientEnvironment").Get<EnvironmentSettings>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            IdentitySeed.InitializeAsync(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
            .CreateScope().ServiceProvider).Wait();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder
            .WithOrigins(envSettings.WebClientUrl.ToString().TrimEnd('/'))
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .Build());

            app.UseAuthentication();
            app.UseAuthorization();

            #region Swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LnuDormWatch");
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
