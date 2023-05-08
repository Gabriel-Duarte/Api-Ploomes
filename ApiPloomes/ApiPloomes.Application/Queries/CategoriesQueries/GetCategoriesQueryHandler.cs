using ApiPloomes.Application.Commands.Requests.CategoriesRequests;
using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Queries
{
	public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public GetCategoriesQueryHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}

		public async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request,
			CancellationToken cancellationToken)
		{
			var categories = _context.CategoryRepository.GetCategories(request);
			if (categories == null)
			{
				await _mediator.Publish(new ErrorNotification
				{
					Error = "A lista de categorias não pode ser encontrada",
					Stack = "A lista de categorias é nula"
				}, cancellationToken);

				return null;
			}
			GetCategoriesResponse categoriesresponse = new GetCategoriesResponse
			{
				TotalCount = categories.TotalCount,
				PageSize = categories.PageSize,
				CurrentPage = categories.CurrentPage,
				TotalPages = categories.TotalPages,
				HasNext = categories.HasNext,
				HasPrevious = categories.HasPrevious
			};
			 categoriesresponse.categories = _mapper.Map<List<GetCategoryByIdResponse>>(categories);
			return categoriesresponse;
		}
	}
}

