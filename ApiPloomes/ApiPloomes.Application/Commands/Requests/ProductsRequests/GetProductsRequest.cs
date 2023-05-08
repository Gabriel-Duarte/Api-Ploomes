using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using ApiPloomes.Domain.Pagination;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.ProductRequests
{
    public class GetProductsRequest : QueryStringParameters, IRequest<GetProductResponse>
    {
    }
}
