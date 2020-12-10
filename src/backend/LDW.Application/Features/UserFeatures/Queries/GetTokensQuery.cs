using LDW.Application.Models;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LDW.Domain.Common.Exceptions;
using Microsoft.Extensions.Options;
using LDW.Domain.Entities.Options;
using LDW.Domain.Interfaces.Services;

namespace LDW.Application.Features.DormitoryFeatures.Queries
{
    public class GetTokensQuery : IRequest<TokenResponseModel>
    {
        public GetTokensQuery(string email, JwtOptions jwtOptions)
        {
            Email = email;
            JwtOptions = jwtOptions;
        }

        public string Email { get; set; }

        public JwtOptions JwtOptions { get; set; }

        public class GetTokensQueryHandler : IRequestHandler<GetTokensQuery, TokenResponseModel>
        {
            private readonly UserManager<UserEntity> _userManager;
            private readonly IJwtService _jwtService;

            public GetTokensQueryHandler(UserManager<UserEntity> userManager, 
                                         IOptions<JwtOptions> jwtOptions, IJwtService jwtService)
            {
                this._userManager = userManager;
                this._jwtService = jwtService;
            }

            public async Task<TokenResponseModel> Handle(GetTokensQuery query, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(query.Email);

                if (user == null)
                {
                    throw new NotFoundException("User", query.Email);
                }

                var roles = await _userManager.GetRolesAsync(user);

                var userId = user.Id.ToString();
                var tokenValidFor = TimeSpan.FromMinutes(query.JwtOptions.TokenExpireInMinutes);
                var refreshTokenValidFor = TimeSpan.FromDays(query.JwtOptions.RefreshTokenExpireInDays);

                var token = await _jwtService.GenerateToken(
                    userId,
                    roles,
                    tokenValidFor);

                var refreshToken = await _jwtService.GenerateToken(
                    userId,
                    roles,
                    refreshTokenValidFor);

                return new TokenResponseModel
                {
                    Token = token,
                    RefreshToken = refreshToken
                };
            }
        }

    }
}
