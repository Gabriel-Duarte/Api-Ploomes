using ApiPloomes.Application.Commands.Requests;
using ApiPloomes.Application.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
		public async Task<ActionResult<IEnumerable<GetProductResponse>>> Get()
		{
			try
			{
				var request = new GetProductsRequest();
				var response = await _mediator.Send(request);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetProductsByPrice")]
		public async Task<ActionResult<IEnumerable<GetProductResponse>>> GetProductsByPrice()
		{
			try
			{
				var request = new GetProductsByPriceRequest();
				var response = await _mediator.Send(request);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<GetProductResponse>> Get(int id)
		{
			try
			{
				var request = new GetProductByIdRequest { Id = id };
				var response = await _mediator.Send(request);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult<CreateProductResponse>> Create([FromBody] CreateProductRequest request)
		{
			try
			{
				var response = await _mediator.Send(request);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<ActionResult<UpdateProductResponse>> Update([FromBody] UpdateProductRequest request)
		{
			try
			{
				var response = await _mediator.Send(request);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<DeleteProductResponse>> Delete(int id)
		{
			try
			{
				var result = await _mediator.Send(new DeleteProductRequest { Id = id });
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
