﻿namespace ApiPloomes.Application.Commands.Responses
{
	public class GetProductResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
	}
}
