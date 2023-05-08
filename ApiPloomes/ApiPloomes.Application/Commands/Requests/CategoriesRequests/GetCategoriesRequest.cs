using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using ApiPloomes.Domain.Pagination;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests.CategoriesRequests
{
	public class GetCategoriesRequest : QueryStringParameters, IRequest<GetCategoriesResponse>
	{
	}
}
