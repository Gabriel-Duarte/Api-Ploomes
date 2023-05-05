using ApiPloomes.Application.Queries;
using ApiPloomes.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiPloomes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
		private IMediator _mediator;

		public ProdutosController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("produto")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _mediator.Send(new GetProdutosQueryHandler());
			return Ok(result);
		}
	}
}
