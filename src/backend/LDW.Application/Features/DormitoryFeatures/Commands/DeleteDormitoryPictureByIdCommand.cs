using LDW.Application.Interfaces;
using LDW.Domain.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.DormitoryFeatures.Commands
{
	public class DeleteDormitoryPictureByIdCommand : IRequest
	{
		public int Id { get; set; }

		public DeleteDormitoryPictureByIdCommand(int id)
		{
			Id = id;
		}

		public class DeleteDormitoryPictureByIdCommandHandler : IRequestHandler<DeleteDormitoryPictureByIdCommand>
		{
			private readonly IApplicationDbContext _context;
			public DeleteDormitoryPictureByIdCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<Unit> Handle(DeleteDormitoryPictureByIdCommand request, CancellationToken cancellationToken)
			{
				var dormitoryPictureToDelete = await _context.DormitoryPictures.FindAsync(request.Id);

				if (dormitoryPictureToDelete == null)
				{
					throw new NotFoundException("DormitoryPicture", request.Id);
				}

				_context.DormitoryPictures.Remove(dormitoryPictureToDelete);
				await _context.SaveChangesAsync(cancellationToken: cancellationToken);

				return Unit.Value;
			}
		}
	}
}
