using LDW.Application.Interfaces;
using LDW.Application.Models;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.DormitoryFeatures.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public CreateUserCommand(UserModel user, string password)
        {
            this.User = user;
            this.Password = password;
        }

        public UserModel User { get; set; }

        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
        {
            private readonly UserManager<UserEntity> _userManager;
            private readonly IUserDbContext _userDbContext;
            public CreateUserCommandHandler(UserManager<UserEntity> userManager, IUserDbContext dbContext)
            {
                this._userManager = userManager;
                this._userDbContext = dbContext;
            }
            public async Task<string> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var newUser = new UserEntity
                {
                    Email = command.User.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = command.User.UserName,
                    PhotoUrl = command.User.PhotoUrl,
                    EmailConfirmed = false, 
                };
                await _userManager.CreateAsync(newUser, command.Password);
                await _userManager.AddToRoleAsync(newUser, "User");
                await _userDbContext.SaveChangesAsync(cancellationToken);

                var createdUser = await _userManager.FindByNameAsync(newUser.Email);
                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(createdUser);
                return confirmationToken;
            }
        }
    }
}
