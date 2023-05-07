using ApiPloomes.Domain.Entities;

namespace ApiPloomes.Domain.Interfaces
{
	public interface IProductRepository : IRepository<Product>
	{
		IEnumerable<Product> GetProductsByPrice();
	}
}
