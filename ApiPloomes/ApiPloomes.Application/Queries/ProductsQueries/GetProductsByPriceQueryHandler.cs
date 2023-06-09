﻿using ApiPloomes.Application.Commands.Requests.ProductRequests;
using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Queries
{
    public class GetProductsByPriceQueryHandler : IRequestHandler<GetProductsByPriceRequest, IEnumerable<GetProductByIdResponse>>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public GetProductsByPriceQueryHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}

		public async Task<IEnumerable<GetProductByIdResponse>> Handle(GetProductsByPriceRequest request,
			CancellationToken cancellationToken)
		{
			var products = _context.ProductRepository.GetProductsByPrice();
			if (products == null)
			{
				await _mediator.Publish(new ErrorNotification
				{
					Error = "A lista de produtos não pode ser encontrada",
					Stack = "A lista de produtos é nulo"
				}, cancellationToken);

				return null;
			}
			var productsresponse = _mapper.Map<List<GetProductByIdResponse>>(products);
			return productsresponse;
		}
	}
}
