using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.ProductRequests
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public int Id { get; set; }
    }
}
