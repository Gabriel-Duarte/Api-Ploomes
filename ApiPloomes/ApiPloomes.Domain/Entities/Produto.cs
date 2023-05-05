using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Domain.Entities
{
	[Table("Produtos")]
	public class Produto
	{

		public int ProdutoId { get; set; }
		public string? Nome { get; set; }
		public string? Descricao { get; set; }
		public decimal Preco { get; set; }
		public string? ImagemUrl { get; set; }
		public float Estoque { get; set; }
		public DateTime DataCadastro { get; set; }
		public int CategoriaId { get; set; }
		public Categoria? Categoria { get; set; }

	}
}
