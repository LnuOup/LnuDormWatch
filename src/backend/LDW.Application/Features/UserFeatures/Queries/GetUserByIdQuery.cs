using LDW.Application.Models;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.UserFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<UserModel>
    {
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
        {
            private readonly UserManager<UserEntity> _userManager;

            public GetUserByIdQueryHandler(UserManager<UserEntity> userManager)
            {
                this._userManager = userManager;
            }

            public async Task<UserModel> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(query.Id);
                var roles = await _userManager.GetRolesAsync(user);
                var userModel = new UserModel
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PhotoUrl = user.PhotoUrl,
                    CompressedPhotoUrl = user.CompressedPhotoUrl,
                    PhoneNumber = user.PhoneNumber,
                    UserRoles = roles
                };
                return userModel;
            }
        }
    }
}
