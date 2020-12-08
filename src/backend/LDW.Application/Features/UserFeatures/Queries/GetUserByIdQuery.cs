using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.UserFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<UserEntity>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserEntity>
        {
            private readonly UserManager<UserEntity> _userManager;

            public GetUserByIdQueryHandler(UserManager<UserEntity> userManager)
            {
                this._userManager = userManager;
            }

            public async Task<UserEntity> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(query.Id);

                return user;
            }
        }
    }
}
