using ApiPloomes.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.CrossCutting.Extensions
{
	public static class MediatrExtension
	{
		public static void AddMediatRApi(this IServiceCollection services)
		{
			services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(GetProdutosQueryHandler)));
			
		}
	}
}
