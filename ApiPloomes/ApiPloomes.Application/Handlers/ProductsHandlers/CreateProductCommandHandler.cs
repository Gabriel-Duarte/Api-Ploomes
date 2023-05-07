using ApiPloomes.Application.Commands.Requests;
using ApiPloomes.Application.Commands.Responses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Handlers
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public CreateProductCommandHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}
		public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
		{
			request.RegistrationDate = DateTime.Now;
			Product newProduct = _mapper.Map<Product>(request);

			_context.ProductRepository.Add(newProduct);
			_context.Commit();

			var productActionNotification = _mapper.Map<ProductActionNotification>(newProduct);
			productActionNotification.Action = ActionNotification.Created;
			await _mediator.Publish(productActionNotification, cancellationToken); ;

			var productResponse = _mapper.Map<CreateProductResponse>(newProduct);

			return productResponse;
		}
	}
}
