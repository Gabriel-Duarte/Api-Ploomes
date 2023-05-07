using ApiPloomes.Application.Commands.Requests.CategoriesRequests;
using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Handlers
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public CreateCategoryCommandHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}
		public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
		{

			Category newCategory = _mapper.Map<Category>(request);

			_context.CategoryRepository.Add(newCategory);
			_context.Commit();

			var categoriesActionNotification = _mapper.Map<CategoriesActionNotification>(newCategory);
			categoriesActionNotification.Action = ActionNotification.Created;
			await _mediator.Publish(categoriesActionNotification, cancellationToken); ;

			var categoryResponse = _mapper.Map<CreateCategoryResponse>(newCategory);

			return categoryResponse;
		}
	}
}
