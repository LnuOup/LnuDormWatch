using LDW.Application.Utilities;
using LDW.Domain.Entities.Options;
using LDW.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LDW.Persistence.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _jwtOptions;

        public JwtService(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;

            ThrowIfInvalidOptions(_jwtOptions);
        }

        public async Task<string> GenerateToken(
            string userId,
            IEnumerable<string> roles,
            TimeSpan timeSpan)
        {
            var jti = await _jwtOptions.JtiGenerator();
            var iat = ToUnixEpochDate(_jwtOptions.IssuedAt).ToString();

            var jwt = TokenBuilder.Create()
                .AddIssuer(_jwtOptions.Issuer)
                .AddAudience(_jwtOptions.Audience)
                .AddNotBefore(_jwtOptions.NotBefore)
                .AddExpires(_jwtOptions.IssuedAt.Add(timeSpan))
                .AddSigningCredentials(_jwtOptions.SigningCredentials)
                .AddClaim(JwtRegisteredClaimNames.Sub, userId)
                .AddClaim(JwtRegisteredClaimNames.Jti, jti)
                .AddClaim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64)
                .AddClaim(ClaimsIdentity.DefaultNameClaimType, userId)
                .AddClaims(roles.Select(x => new Tuple<string, string>(ClaimsIdentity.DefaultRoleClaimType, x)))
                .Build();

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() -
                                         new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);
        }

        private static void ThrowIfInvalidOptions(JwtOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.TokenExpireInMinutes <= 0)
            {
                throw new ArgumentException("Must be a not less or equal to 0.", nameof(JwtOptions.TokenExpireInMinutes));
            }

            if (options.RefreshTokenExpireInDays <= 0)
            {
                throw new ArgumentException("Must be a not less or equal to 0.", nameof(JwtOptions.RefreshTokenExpireInDays));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtOptions.JtiGenerator));
            }
        }
    }
}
