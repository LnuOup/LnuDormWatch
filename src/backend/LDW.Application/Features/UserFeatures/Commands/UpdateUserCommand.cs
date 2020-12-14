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
    public class UpdateUserCommand : IRequest<UserEntity>
    {
        public UserModel User { get; set; }

        public string UserId { get; set; }

        public UpdateUserCommand(UserModel userModel, string userId)
        {
            User = userModel;
            UserId = userId;
        }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserEntity>
        {
            private readonly UserManager<UserEntity> _userManager;
            private readonly IUserDbContext _userDbContext;

            public UpdateUserCommandHandler(UserManager<UserEntity> userManager, IUserDbContext dbContext)
            {
                this._userManager = userManager;
                this._userDbContext = dbContext;
            }
            public async Task<UserEntity> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(command.UserId);

                user.PhotoUrl = command.User.PhotoUrl;
                user.CompressedPhotoUrl = command.User.CompressedPhotoUrl;
                user.Email = command.User.Email;
                user.UserName = command.User.UserName;
                user.PhoneNumber = command.User.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);

                var errors = result.Errors.Aggregate("", (current, identityError) => current + identityError.Description + "|");
                if (!result.Succeeded)
                {
                    throw new Exception(errors);
                }

                await _userDbContext.SaveChangesAsync(cancellationToken);

                return user;
            }
        }
    }
}

