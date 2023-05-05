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
		[Key]
		public int ProdutoId { get; set; }
		[Required]
		[StringLength(80)]
		public string? Nome { get; set; }
		[Required]
		[StringLength(300)]
		public string? Descricao { get; set; }
		[Required]
		[Column(TypeName = "decimal(10,2)")]
		public decimal Preco { get; set; }
		[Required]
		[StringLength(300)]
		public string? ImagemUrl { get; set; }
		public float Estoque { get; set; }
		public DateTime DataCadastro { get; set; }
		public int CategoriaId { get; set; }
		public Categoria? Categoria { get; set; }

	}
}
