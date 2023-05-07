using ApiPloomes.Application.Commands.Requests.ProductRequests;
using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdRequest, GetProductResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public GetProductByIdQueryHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}

		public async Task<GetProductResponse> Handle(GetProductByIdRequest query,
			CancellationToken cancellationToken)
		{
			var productId = _context.ProductRepository.GetById(y => y.Id == query.Id);
			if (productId == null)
			{
				await _mediator.Publish(new ErrorNotification
				{
					Error = "produto especifico não pode ser encontrada",
					Stack = "O produto é nulo"
				}, cancellationToken);

				return null;
			}

			var productIdresponse = _mapper.Map<GetProductResponse>(productId);
			return productIdresponse;
		}
	}
}

