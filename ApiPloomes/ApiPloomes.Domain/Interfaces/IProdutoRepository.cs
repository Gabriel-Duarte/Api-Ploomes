using ApiPloomes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Domain.Interfaces
{
	public interface IProdutoRepository: IRepository<Produto>
	{
		IEnumerable<Produto> GetProdutosPorPreco();

	}
}
