using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using ApiPloomes.Domain.Pagination;
using ApiPloomes.Infrastructure.Context;

namespace ApiPloomes.Infrastructure.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(AppDbContext context) : base(context)
		{
		}

		public IEnumerable<Product> GetProductsByPrice()
		{
			return Get().OrderBy(x => x.Price).ToList();
		}
		public PagedList<Product> GetPtoduct(QueryStringParameters productParameters)
		{
			return PagedList<Product>.ToPagedList(Get().OrderBy(on => on.Id),
				productParameters.PageNumber, productParameters.PageSize);
		}
	}
}
