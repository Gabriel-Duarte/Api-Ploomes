using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using ApiPloomes.Domain.Pagination;

namespace ApiPloomes.Application.Commands.Responses.CategoriesResponses
{
	public class GetCategoriesResponse : ResponseHeaders
	{
		public List<GetCategoryByIdResponse> categories { get; set; }
	}
}
