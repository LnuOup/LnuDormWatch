using System.Threading;
using System.Threading.Tasks;
using LDW.Application.Interfaces;
using LDW.Domain.Common.Exceptions;
using MediatR;

namespace LDW.Application.Features.DormitoryFeatures.Commands
{
    public class DeleteDormitoryByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteDormitoryByIdCommandHandler : IRequestHandler<DeleteDormitoryByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteDormitoryByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteDormitoryByIdCommand request, CancellationToken cancellationToken)
            {
                var dormitoryToDelete = await _context.Dormitories.FindAsync(request.Id);

                if (dormitoryToDelete == null)
                {
                    throw new NotFoundException("Dormitory", request.Id);
                }

                _context.Dormitories.Remove(dormitoryToDelete);
                await _context.SaveChangesAsync(cancellationToken: cancellationToken);
                return dormitoryToDelete.Id;
            }
        }
    }
}