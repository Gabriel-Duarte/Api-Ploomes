using ApiPloomes.Application.Commands.Requests;
using ApiPloomes.Application.Commands.Requests.ProductRequests;
using ApiPloomes.Application.Commands.Responses;
using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using ApiPloomes.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPloomes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private IMediator _mediator;

		public ProductController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetProductByIdResponse>>> Get([FromQuery] GetProductsRequest request)
		{
			try
			{
				var response = await _mediator.Send(request);
				if (response == null)
				{
					return NotFound("A lista de produtos não pode ser encontrada");
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
			
				return Ok(response.products);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					   $"Ocorreu um problema ao tratar a sua solicitação. {ex.Message}");
			}
		}

		[HttpGet("GetProductsByPrice")]
		public async Task<ActionResult<IEnumerable<GetProductByIdResponse>>> GetProductsByPrice()
		{
			try
			{
				var request = new GetProductsByPriceRequest();
				var response = await _mediator.Send(request);
				if (response == null)
				{
					return NotFound("A lista de produtos não pode ser encontrada");
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
		public async Task<ActionResult<GetProductByIdResponse>> Get(int id)
		{
			try
			{
				var request = new GetProductByIdRequest { Id = id };
				var response = await _mediator.Send(request);
				if (response == null)
				{
					return NotFound($"Produto com id= {id} não encontrado...");
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
		public async Task<ActionResult<CreateProductResponse>> Create([FromBody] CreateProductRequest request)
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
		public async Task<ActionResult<UpdateProductResponse>> Update([FromBody] UpdateProductRequest request)
		{
			try
			{
				var response = await _mediator.Send(request);
				if (response == null)
				{
					return NotFound($"Produto com id= {request.Id} não encontrada...");
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
		public async Task<ActionResult<DeleteProductResponse>> Delete(int id)
		{
			try
			{
				var response = await _mediator.Send(new DeleteProductRequest { Id = id });
				if (response == null)
				{
					return NotFound($"Produto com id= {id} não encontrada...");
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
