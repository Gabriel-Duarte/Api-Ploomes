using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using ApiPloomes.Domain.Pagination;
using ApiPloomes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiPloomes.Infrastructure.Repositories
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly AppDbContext _context;

		public CategoryRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
		public IEnumerable<Category> GetCategoriesProducts()
		{
			return _context.Categories.Include(c => c.Products).AsNoTracking().ToList();
		}
		public PagedList<Category> GetCategories(QueryStringParameters queryStringParameters)
		{
			return PagedList<Category>.ToPagedList(Get().OrderBy(on => on.Id),
				queryStringParameters.PageNumber, queryStringParameters.PageSize);
		}
	}
}
