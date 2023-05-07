using ApiPloomes.Application.Commands.Requests;
using ApiPloomes.Application.Commands.Requests.CategoriesRequests;
using ApiPloomes.Application.Commands.Requests.ProductRequests;
using ApiPloomes.Application.Commands.Responses;
using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiPloomes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : Controller
	{
		private IMediator _mediator;

		public CategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetCategoriesResponse>>> Get()
		{
			try
			{
				var request = new GetCategoriesRequest();
				var response = await _mediator.Send(request);
				if (response == null)
				{
					return NotFound("A lista de categorias não pode ser encontrada");
				}
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					   $"Ocorreu um problema ao tratar a sua solicitação. {ex.Message}");
			}
		}

	}
}
