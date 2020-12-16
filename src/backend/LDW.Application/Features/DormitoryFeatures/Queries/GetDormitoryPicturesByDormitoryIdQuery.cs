using LDW.Application.Interfaces;
using LDW.Application.Models.Dormitory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.DormitoryFeatures.Queries
{
    public class GetDormitoryPicturesByDormitoryIdQuery : IRequest<IEnumerable<DormitoryPictureModel>>
    {
        public int DormitoryId { get; set; }

        public GetDormitoryPicturesByDormitoryIdQuery(int dormitoryId)
        {
            DormitoryId = dormitoryId;
        }

        public class GetDormitoryPicturesByDormitoryIdQueryHandler : IRequestHandler<GetDormitoryPicturesByDormitoryIdQuery, IEnumerable<DormitoryPictureModel>>
        {
            private readonly IApplicationDbContext _context;

            public GetDormitoryPicturesByDormitoryIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

			public async Task<IEnumerable<DormitoryPictureModel>> Handle(GetDormitoryPicturesByDormitoryIdQuery request, CancellationToken cancellationToken)
			{
                var dormitoryPictureEntities = await _context.DormitoryPictures
                    .Where(dp => dp.DormitoryId == request.DormitoryId)
                    .ToListAsync();

                DormitoryPictureModel dormitoryPictureModel;

                var dormitoryPictureModels = dormitoryPictureEntities.Select(entity =>
                {
                    dormitoryPictureModel = new DormitoryPictureModel
                    {
                        Id = entity.Id,
                        DormitoryId = entity.DormitoryId,
                        Image = entity.Image,
                        IsMain = entity.IsMain
                    };

                    return dormitoryPictureModel;
                });

                return dormitoryPictureModels;
            }
		}
    }
}
