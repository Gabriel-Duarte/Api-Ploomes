using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
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
	}
}
