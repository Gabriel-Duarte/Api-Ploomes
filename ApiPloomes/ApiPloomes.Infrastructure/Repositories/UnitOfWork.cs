using ApiPloomes.Domain.Interfaces;
using ApiPloomes.Infrastructure.Context;

namespace ApiPloomes.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private CategoryRepository _categoryRepository;
		private ProductRepository _productRepository;
		public AppDbContext _context;

		public UnitOfWork(AppDbContext contexto)
		{
			_context = contexto;
		}

		public IProductRepository ProductRepository
		{
			get
			{
				return _productRepository = _productRepository ?? new ProductRepository(_context);
			}
		}
		public ICategoryRepository CategoryRepository
		{
			get
			{
				return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
			}
		}
		public void Commit()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}

	}
}
