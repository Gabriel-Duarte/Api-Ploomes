using ApiPloomes.Application.Commands.Responses;
using MediatR;

namespace ApiPloomes.Application.Commands.Requests
{
	public class CreateProductRequest : IRequest<CreateProductResponse>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public int Stock { get; set; }
		public DateTime RegistrationDate { get; set; }
		public int CategoryId { get; set; }
	}
}
