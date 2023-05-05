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
	public class ProdutoRepository : Repository<Produto>, IProdutoRepository
	{
		
		
		public ProdutoRepository(AppDbContext context) :base(context) 
		{
		}
		

		public  IEnumerable<Produto> GetProdutosPorPreco()
		{
			return Get().OrderBy(x=> x.Preco).ToList();
		}

	}
}
