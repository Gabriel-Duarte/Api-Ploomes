using ApiPloomes.Application.Commands.Responses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests
{
	public class GetProductsRequest : IRequest<IEnumerable<GetProductResponse>>
	{
	}
}
