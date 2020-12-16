using System.Threading;
using System.Threading.Tasks;
using LDW.Application.Interfaces;
using LDW.Domain.Entities;
using MediatR;

namespace LDW.Application.Features.DormitoryFeatures.Commands
{
    public class CreateDormitoryCommand : IRequest<int>
    {
        public int Number { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public class CreateProductCommandHandler : IRequestHandler<CreateDormitoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateDormitoryCommand command, CancellationToken cancellationToken)
            {
                var newDormitory = new DormitoryEntity
                {
                    Number = command.Number,
                    Address = command.Address,
                    PhoneNumber = command.PhoneNumber,
					Latitude = command.Latitude,
					Longitude = command.Longitude
                };
                await _context.Dormitories.AddAsync(newDormitory, cancellationToken: cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return newDormitory.Id;
            }
        }
    }
}