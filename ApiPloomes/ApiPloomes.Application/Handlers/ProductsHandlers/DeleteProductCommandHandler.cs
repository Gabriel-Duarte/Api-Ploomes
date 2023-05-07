using ApiPloomes.Application.Commands.Requests;
using ApiPloomes.Application.Commands.Responses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApiPloomes.Application.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
	{
		private readonly IUnitOfWork _context;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public DeleteProductCommandHandler(IUnitOfWork context, IMediator mediator, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
			_mediator = mediator;
		}
		public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
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

			_context.ProductRepository.Delete(product);
			_context.Commit();

			var productActionNotification = _mapper.Map<ProductActionNotification>(product);
			productActionNotification.Action = ActionNotification.Deleted;
			
			var produtoResponse = _mapper.Map<DeleteProductResponse>(product);

			return produtoResponse;
		}
	}
}
