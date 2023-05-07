using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.CategoriesRequests
{
	public class UpdateCategoryRequest : IRequest<UpdateCategoryResponse>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
	}
}
