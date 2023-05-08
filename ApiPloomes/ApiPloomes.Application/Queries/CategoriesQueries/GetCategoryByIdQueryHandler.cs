using ApiPloomes.Application.Commands.Requests.CategoriesRequests;
using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Queries
{
	public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public GetCategoryByIdQueryHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}

		public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest query,
			CancellationToken cancellationToken)
		{
			var categoryId = _context.CategoryRepository.GetById(y => y.Id == query.Id);
			if (categoryId == null)
			{
				await _mediator.Publish(new ErrorNotification
				{
					Error = "Categoria especifica não pode ser encontrada",
					Stack = "A categoria é nula"
				}, cancellationToken);

				return null;
			}

			var categoryIdresponse = _mapper.Map<GetCategoryByIdResponse>(categoryId);
			return categoryIdresponse;
		}
	}
}
