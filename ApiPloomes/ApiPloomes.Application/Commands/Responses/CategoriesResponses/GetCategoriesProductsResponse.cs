using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using ApiPloomes.Domain.Entities;

namespace ApiPloomes.Application.Commands.Responses.CategoriesResponses
{
	public class GetCategoriesProductsResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public ICollection<GetProductResponse> Products { get; set; }
	}
}
