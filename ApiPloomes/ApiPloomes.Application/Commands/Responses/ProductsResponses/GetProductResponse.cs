using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Pagination;

namespace ApiPloomes.Application.Commands.Responses.ProductsResponses
{
    public class GetProductResponse: ResponseHeaders
	{
		public List<GetProductByIdResponse> products { get; set; }

	}
}
