using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Pagination;

namespace ApiPloomes.Domain.Interfaces
{
	public interface IProductRepository : IRepository<Product>
	{
		IEnumerable<Product> GetProductsByPrice();
		PagedList<Product> GetPtoduct(QueryStringParameters productParameters);
	}
}
