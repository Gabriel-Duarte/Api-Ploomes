using ApiPloomes.Application.Commands.Requests;
using ApiPloomes.Application.Commands.Responses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Handlers
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public UpdateProductCommandHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}
		public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
		{
			var product = _context.ProductRepository.GetById(y => y.Id == request.Id);
			if (product == null)
			{
				await _mediator.Publish(new ErrorNotification
				{
					Error = "produto especifico não pode ser encontrada",
					Stack = "O produto é nulo"
				}, cancellationToken);

				return null;
			}

			request.RegistrationDate = product.RegistrationDate;
			Product updateproduct = _mapper.Map<Product>(request);

			_context.ProductRepository.Update(updateproduct);
			_context.Commit();

			var productActionNotification = _mapper.Map<ProductActionNotification>(updateproduct);
			productActionNotification.Action = ActionNotification.Updated;
			await _mediator.Publish(productActionNotification, cancellationToken); ;

			var productResponse = _mapper.Map<UpdateProductResponse>(updateproduct);

			return productResponse;
		}
	}
}

