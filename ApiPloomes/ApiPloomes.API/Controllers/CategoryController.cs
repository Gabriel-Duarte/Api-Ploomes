using ApiPloomes.API.Communication;
using ApiPloomes.Application.Commands.Requests.CategoriesRequests;
using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
		[ProducesResponseType(typeof(ResponseSuccess), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<GetCategoryByIdResponse>>> Get([FromQuery] GetCategoriesRequest request)
		{
			try
			{
				var response = await _mediator.Send(request);
				if (response == null)
				{
					return NotFound("A lista de categorias não pode ser encontrada");
				}
				var metadata = new
				{
					response.TotalCount,
					response.PageSize,
					response.CurrentPage,
					response.TotalPages,
					response.HasNext,
					response.HasPrevious
				};
				Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
				return Ok(response.categories);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					   $"Ocorreu um problema ao tratar a sua solicitação. {ex.Message}");
			}
		}

		[HttpGet("GetCategoriesProducts")]
		[ProducesResponseType(typeof(ResponseSuccess), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status500InternalServerError)]
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
		[ProducesResponseType(typeof(ResponseSuccess), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<GetCategoryByIdResponse>> Get(int id)
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
		[ProducesResponseType(typeof(ResponseSuccess), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status500InternalServerError)]
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

		[HttpPut]
		[ProducesResponseType(typeof(ResponseSuccess), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<UpdateCategoryResponse>> Update([FromBody] UpdateCategoryRequest request)
		{
			try
			{
				var response = await _mediator.Send(request);
				if (response == null)
				{
					return NotFound($"Categoria com id= {request.Id} não encontrada...");
				}
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
				   $"Ocorreu um problema ao tratar a sua solicitação. {ex.Message}");
			}
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(typeof(ResponseSuccess), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ResponseFailure), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<DeleteCategoryResponse>> Delete(int id)
		{
			try
			{
				var response = await _mediator.Send(new DeleteCategoryRequest { Id = id });
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
	}
}
