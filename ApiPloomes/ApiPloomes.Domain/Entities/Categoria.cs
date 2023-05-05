using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Domain.Entities
{
	[Table("Categorias")]
	public class Categoria
	{
		public Categoria()
		{
			Produtos = new Collection<Produto>();
		}
	
		public int CategoriaId { get; set; }
		public string? Nome { get; set; }
		public string? ImagemUrl { get; set; }
		public ICollection<Produto>? Produtos { get; set; }
	}
}
