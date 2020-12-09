using LDW.Application.Interfaces;
using LDW.Application.Models;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.UserFeatures.Commands
{
    public class UpdateUserCommand : IRequest<string>
    {
        public UserModel User { get; set; }

        public UpdateUserCommand(UserModel userModel)
        {
            User = userModel;
        }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
        {
            private readonly UserManager<UserEntity> _userManager;
            private readonly IUserDbContext _userDbContext;

            public UpdateUserCommandHandler(UserManager<UserEntity> userManager, IUserDbContext dbContext)
            {
                this._userManager = userManager;
                this._userDbContext = dbContext;
            }
            public async Task<string> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(command.User.UserName);

                user.PhotoUrl = command.User.PhotoUrl;
                user.CompressedPhotoUrl = command.User.CompressedPhotoUrl;
                user.Email = command.User.Email;
                user.UserName = command.User.UserName;

                var result = await _userManager.UpdateAsync(user);

                var errors = result.Errors.Aggregate("", (current, identityError) => current + identityError.Description + "|");
                if (!result.Succeeded)
                {
                    throw new Exception(errors);
                }

                await _userDbContext.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
        }
    }
}

