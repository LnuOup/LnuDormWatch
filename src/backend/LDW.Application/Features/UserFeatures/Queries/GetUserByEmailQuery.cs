using LDW.Domain.Common.Exceptions;
using LDW.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LDW.Application.Features.DormitoryFeatures.Queries
{
    public class GetUserByEmailQuery : IRequest<UserEntity>
    {
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserEntity>
        {
            private readonly UserManager<UserEntity> _userManager;

            public GetUserByEmailQueryHandler(UserManager<UserEntity> userManager)
            {
                this._userManager = userManager;
            }

            public async Task<UserEntity> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(query.Email);

                return user;
            }
        }
    }
}
