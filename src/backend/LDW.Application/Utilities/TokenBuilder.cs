using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace LDW.Application.Utilities
{
    public class TokenBuilder
    {
        private string _issuer = null;
        private string _audience = null;
        private DateTime? _notBefore;
        private DateTime? _expires;
        private SigningCredentials _signingCredentials;

        private readonly List<Claim> _claims = new List<Claim>();

        public static TokenBuilder Create()
        {
            return new TokenBuilder();
        }

        public TokenBuilder AddIssuer(string issuer)
        {
            _issuer = issuer;
            return this;
        }

        public TokenBuilder AddAudience(string audience)
        {
            _audience = audience;
            return this;
        }

        public TokenBuilder AddNotBefore(DateTime notBeforeTime)
        {
            _notBefore = notBeforeTime;
            return this;
        }

        public TokenBuilder AddExpires(DateTime expires)
        {
            _expires = expires;
            return this;
        }

        public TokenBuilder AddSigningCredentials(SigningCredentials signingCredentials)
        {
            _signingCredentials = signingCredentials;
            return this;
        }

        public TokenBuilder AddClaim(string type, string value)
        {
            _claims.Add(new Claim(type, value));
            return this;
        }

        ///<param name="claims">Item1 should be a Type of claim, and Item2 should be a Value of claim</param>
        public TokenBuilder AddClaims(IEnumerable<Tuple<string, string>> claims)
        {
            _claims.AddRange(claims.Select(x => new Claim(x.Item1, x.Item2)));
            return this;
        }

        public TokenBuilder AddClaim(string type, string value, string valueType)
        {
            _claims.Add(new Claim(type, value, valueType));
            return this;
        }

        public JwtSecurityToken Build()
        {
            return new JwtSecurityToken(
                _issuer,
                _audience,
                _claims,
                _notBefore,
                _expires,
                _signingCredentials);
        }
    }
}
