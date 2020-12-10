using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.DormitoryFeatures.Queries
{
    public class GetUserLoginQuery : IRequest<bool>
    {
        public GetUserLoginQuery(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
        public string Email { get; set; }

        public string Password { get; set; }

        public class GetUserLoginQueryHandler : IRequestHandler<GetUserLoginQuery, bool> 
        {
            private readonly UserManager<UserEntity> _userManager;

            public GetUserLoginQueryHandler(UserManager<UserEntity> userManager)
            {
                this._userManager = userManager;
            }

            public async Task<bool> Handle(GetUserLoginQuery query, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(query.Email);

                if(user != null)
                {
                    return await _userManager.CheckPasswordAsync(user, query.Password);
                }

                return false;
            }
        }

    }
}
