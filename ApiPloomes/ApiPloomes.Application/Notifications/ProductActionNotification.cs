using MediatR;

namespace ApiPloomes.Application.Notifications
{
	public class ProductActionNotification : INotification
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
		public ActionNotification Action { get; set; }
	}
}
