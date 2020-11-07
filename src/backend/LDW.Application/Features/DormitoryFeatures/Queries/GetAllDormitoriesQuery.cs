using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LDW.Application.Interfaces;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LDW.Application.Features.DormitoryFeatures.Queries
{
    public class GetAllDormitoriesQuery : IRequest<IEnumerable<DormitoryEntity>>
    {
        public class GetAllDormitoriesQueryHandler : IRequestHandler<GetAllDormitoriesQuery, IEnumerable<DormitoryEntity>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllDormitoriesQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<DormitoryEntity>> Handle(GetAllDormitoriesQuery request, CancellationToken cancellationToken)
            {
                var dormitoryList = await _context.Dormitories.ToListAsync(cancellationToken: cancellationToken);

                return dormitoryList?.AsReadOnly();
            }
        }
    }
}