using ApiPloomes.Application.Commands.Requests.CategoriesRequests;
using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Queries
{
	public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesRequest, IEnumerable<GetCategoriesResponse>>
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

		public async Task<IEnumerable<GetCategoriesResponse>> Handle(GetCategoriesRequest request,
			CancellationToken cancellationToken)
		{
			var categories = _context.CategoryRepository.Get();
			if (categories == null)
			{
				await _mediator.Publish(new ErrorNotification
				{
					Error = "A lista de categorias não pode ser encontrada",
					Stack = "A lista de categorias é nula"
				}, cancellationToken);

				return null;
			}
			var categoriesresponse = _mapper.Map<List<GetCategoriesResponse>>(categories);
			return categoriesresponse;
		}
	}
}

