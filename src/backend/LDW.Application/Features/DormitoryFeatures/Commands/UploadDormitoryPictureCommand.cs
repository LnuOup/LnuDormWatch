using LDW.Application.Interfaces;
using LDW.Application.Models.Dormitory;
using LDW.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.DormitoryFeatures.Commands
{

	public class UploadDormitoryPictureCommand : IRequest<DormitoryPictureModel>
	{
		public int DormitoryId { get; set; }
		public bool IsMain { get; set; }
		public string ImageUrl { get; set; }

		public class UploadDormitoryPictureCommandHandler : IRequestHandler<UploadDormitoryPictureCommand, DormitoryPictureModel>
		{
			private readonly IApplicationDbContext _context;
			public UploadDormitoryPictureCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}
			public async Task<DormitoryPictureModel> Handle(UploadDormitoryPictureCommand request, CancellationToken cancellationToken)
			{
				var newDormitoryPictureEntity = new DormitoryPictureEntity
				{
					DormitoryId = request.DormitoryId,
					IsMain = request.IsMain,
					ImageUrl = request.ImageUrl
				};

				await _context.DormitoryPictures.AddAsync(newDormitoryPictureEntity, cancellationToken: cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);

				var dormitoryPictureModel = new DormitoryPictureModel
				{
					Id = newDormitoryPictureEntity.Id,
					IsMain = newDormitoryPictureEntity.IsMain,
					ImageUrl = newDormitoryPictureEntity.ImageUrl,
					DormitoryId = newDormitoryPictureEntity.DormitoryId
				};

				return dormitoryPictureModel;
			}
		}
	}
}
