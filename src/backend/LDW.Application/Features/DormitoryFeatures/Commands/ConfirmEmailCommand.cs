using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.DormitoryFeatures.Commands
{
    public class ConfirmEmailCommand : IRequest<IdentityResult>
    {
        public string Email { get; set; }

        public string Code { get; set; }
        public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, IdentityResult>
        {
            private readonly UserManager<UserEntity> _userManager;
            public ConfirmEmailCommandHandler(UserManager<UserEntity> userManager)
            {
                _userManager = userManager;
            }
            public async Task<IdentityResult> Handle(ConfirmEmailCommand command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(command.Email);
                var result = await _userManager.ConfirmEmailAsync(user, command.Code);

                var errors = result.Errors
                             .Aggregate("", (current, identityError) => current + identityError.Description + "|");

                if (!result.Succeeded)
                {
                    throw new Exception(errors);
                }
                return result;
            }
        }
    }
}
