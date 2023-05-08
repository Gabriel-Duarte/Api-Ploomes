using ApiPloomes.Application.Commands.Requests.ProductRequests;
using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsRequest, GetProductResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public GetProductsQueryHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}

		public async Task<GetProductResponse> Handle(GetProductsRequest request,
			CancellationToken cancellationToken)
		{
			var products = _context.ProductRepository.GetPtoduct(request);
			if (products == null)
			{
				await _mediator.Publish(new ErrorNotification
				{
					Error = "A lista de produtos não pode ser encontrada",
					Stack = "A lista de produtos é nulo"
				}, cancellationToken);

				return null;
			}
			GetProductResponse productsresponse = new GetProductResponse
			{
				TotalCount=products.TotalCount,
				PageSize=products.PageSize,
				CurrentPage =products.CurrentPage,
				TotalPages = products.TotalPages,
				HasNext=products.HasNext,
				HasPrevious=products.HasPrevious
			};
			productsresponse.products = _mapper.Map<List<GetProductByIdResponse>>(products);
			return productsresponse;
		}
	}
}
