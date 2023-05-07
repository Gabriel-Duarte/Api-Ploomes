using ApiPloomes.Application.Commands.Responses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests
{
	public class GetProductByIdRequest : IRequest<GetProductResponse>
	{
		public int Id { get; set; }
	}
}
