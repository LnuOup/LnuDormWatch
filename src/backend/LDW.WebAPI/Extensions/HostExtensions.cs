using LDW.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LDW.WebAPI.Extensions
{
    public static class HostExtensions
	{
		public static IHost MigrateDatabase(this IHost webHost)
		{
			using (var scope = webHost.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<ApplicationDbContext>();
				context.Database.Migrate();
				var identityContext = services.GetRequiredService<UserDbContext>();
				identityContext.Database.Migrate();
			}

			return webHost;
		}
	}
}
