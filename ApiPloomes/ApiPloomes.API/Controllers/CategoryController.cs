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

		[HttpGet("GetCategoriesProducts")]
		public async Task<ActionResult<IEnumerable<GetCategoriesProductsResponse>>> GetCategoriesProducts()
		{
			try
			{
				var request = new GetCategoriesProductsRequest();
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

		[HttpGet("{id:int}")]
		public async Task<ActionResult<GetCategoriesResponse>> Get(int id)
		{
			try
			{
				var request = new GetCategoryByIdRequest { Id = id };
				var response = await _mediator.Send(request);
				if (response == null)
				{
					return NotFound($"Categoria com id= {id} não encontrada...");
				}
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
				   $"Ocorreu um problema ao tratar a sua solicitação. {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<ActionResult<CreateCategoryResponse>> Create([FromBody] CreateCategoryRequest request)
		{
			try
			{
				if (request is null)
					return BadRequest("Dados inválidos");

				var response = await _mediator.Send(request);
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
