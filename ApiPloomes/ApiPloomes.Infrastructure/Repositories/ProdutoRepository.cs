using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Interfaces;
using ApiPloomes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Infrastructure.Repositories
{
	public class ProdutoRepository : IProdutoRepository
	{
		private AppDbContext _productContext;
		public ProdutoRepository(AppDbContext context)
		{
			_productContext = context;
		}

		public async Task<IEnumerable<Produto>> GetProdutosAsync()
		{
			return await _productContext.Produtos.ToListAsync();
		}

	}
}
