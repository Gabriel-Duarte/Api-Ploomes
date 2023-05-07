using ApiPloomes.Application.Commands.Responses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
	{
		public int Id { get; set; }
	}
}
