﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Application.Commands.Responses
{
	public class GetProdutosResponse
	{
		public int ProdutoId { get; set; }
		public string? Nome { get; set; }
		public string? Descricao { get; set; }
		public decimal Preco { get; set; }
		public string? ImagemUrl { get; set; }
		public int CategoriaId { get; set; }
	}
}
