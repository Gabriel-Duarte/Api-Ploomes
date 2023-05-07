using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.CategoriesRequests
{
	public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
	{
		public string Name { get; set; }
		public string ImageUrl { get; set; }
	}
}
