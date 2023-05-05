using ApiPloomes.Application.Commands.Responses;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Application.Queries
{
	public class GetProdutosQueryHandler :IRequest<IEnumerable<Produto>>
	{
		public class GetProdutosQuery : IRequestHandler<GetProdutosQueryHandler,
		   IEnumerable<Produto>>
		{
			private readonly IUnitOfWork _context;
			private readonly IMediator _mediator;

			public GetProdutosQuery(IUnitOfWork context, IMediator mediator)
			{
				_context = context;
				_mediator = mediator;
			}

			public async Task<IEnumerable<Produto>> Handle(GetProdutosQueryHandler query,
				CancellationToken cancellationToken)
			{
				var produtos =  _context.ProdutoRepository.Get();
				if (produtos == null)
				{
					await _mediator.Publish(new ErrorNotification
					{
						Error = "A lista de produtos não pode ser encontrada",
						Stack = "A lista de produtos é nulo"
					}, cancellationToken);

					return null;
				}

				return produtos;
			}
		}
	}
}
