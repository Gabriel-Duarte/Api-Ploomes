using ApiPloomes.Application.Commands.Requests.CategoriesRequests;
using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Handlers
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public DeleteCategoryCommandHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}
		public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
		{
			var category = _context.CategoryRepository.GetById(y => y.Id == request.Id);
			if (category == null)
			{
				await _mediator.Publish(new ErrorNotification
				{
					Error = "Categoria especifica não pode ser encontrada",
					Stack = "A categoria é nula"
				}, cancellationToken);

				return null;
			}

			_context.CategoryRepository.Delete(category);
			_context.Commit();

			var categoryActionNotification = _mapper.Map<CategoriesActionNotification>(category);
			categoryActionNotification.Action = ActionNotification.Deleted;

			var categoryResponse = _mapper.Map<DeleteCategoryResponse>(category);

			return categoryResponse;
		}
	}
}
