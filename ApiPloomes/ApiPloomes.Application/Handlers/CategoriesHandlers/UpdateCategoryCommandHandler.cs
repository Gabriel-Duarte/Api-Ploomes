using ApiPloomes.Application.Commands.Requests.CategoriesRequests;
using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Handlers
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public UpdateCategoryCommandHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}
		public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
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

			Category updatecategory = _mapper.Map<Category>(request);

			_context.CategoryRepository.Update(updatecategory);
			_context.Commit();

			var categoryActionNotification = _mapper.Map<CategoriesActionNotification>(updatecategory);
			categoryActionNotification.Action = ActionNotification.Updated;
			await _mediator.Publish(categoryActionNotification, cancellationToken); ;

			var categoryResponse = _mapper.Map<UpdateCategoryResponse>(updatecategory);

			return categoryResponse;
		}
	}
}
