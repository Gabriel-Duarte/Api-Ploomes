using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.CategoriesRequests
{
	public class GetCategoryByIdRequest : IRequest<GetCategoryByIdResponse>
	{
		public int Id { get; set; }
	}
}
