using LDW.Application.Interfaces;
using LDW.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.DormitoryFeatures.Queries
{
    public class GetDormitoryByIdQuery : IRequest<DormitoryEntity>
    {
        public GetDormitoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public class GetDormitoryByIdQueryHandler : IRequestHandler<GetDormitoryByIdQuery, DormitoryEntity>
        {
            private readonly IApplicationDbContext _context;

            public GetDormitoryByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<DormitoryEntity> Handle(GetDormitoryByIdQuery query, CancellationToken cancellationToken)
            {
                var dormitory = await _context.Dormitories.FindAsync(query.Id);

                return dormitory;
            }
        }
    }
}