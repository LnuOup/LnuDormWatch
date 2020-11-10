﻿using System.Threading;
using System.Threading.Tasks;
using LDW.Application.Interfaces;
using MediatR;

namespace LDW.Application.Features.DormitoryFeatures.Commands
{
    public class UpdateDormitoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public class UpdateDormitoryCommandHandler : IRequestHandler<UpdateDormitoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateDormitoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateDormitoryCommand request, CancellationToken cancellationToken)
            {
                var dormitoryToUpdate = await _context.Dormitories.FindAsync(request.Id);

                if (dormitoryToUpdate == null)
                {
                    return default;
                }

                dormitoryToUpdate.Number = request.Number;
                dormitoryToUpdate.Address = request.Address;
                dormitoryToUpdate.PhoneNumber = request.PhoneNumber;

                await _context.SaveChangesAsync(cancellationToken: cancellationToken);

                return dormitoryToUpdate.Id;
            }
        }
    }
}