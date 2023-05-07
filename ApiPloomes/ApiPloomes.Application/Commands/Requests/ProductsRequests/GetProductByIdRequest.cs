using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.ProductRequests
{
    public class GetProductByIdRequest : IRequest<GetProductResponse>
    {
        public int Id { get; set; }
    }
}
