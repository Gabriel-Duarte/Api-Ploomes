using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.CategoriesRequests
{
	public class DeleteCategoryRequest : IRequest<DeleteCategoryResponse>
	{
		public int Id { get; set; }
	}
}
