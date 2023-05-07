using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.CategoriesRequests
{
	public class GetCategoriesRequest : IRequest<IEnumerable<GetCategoriesResponse>>
	{
	}
}
