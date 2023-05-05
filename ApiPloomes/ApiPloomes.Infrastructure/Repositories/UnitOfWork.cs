using ApiPloomes.Domain.Interfaces;
using ApiPloomes.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private ProdutoRepository _produtoRepo;
		public AppDbContext _context;
		
		public UnitOfWork(AppDbContext contexto)
		{
			_context = contexto;
		}

		public IProdutoRepository ProdutoRepository
		{
			get
			{
				return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
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
