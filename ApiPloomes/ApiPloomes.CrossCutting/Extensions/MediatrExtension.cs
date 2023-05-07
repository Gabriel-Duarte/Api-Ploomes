using ApiPloomes.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPloomes.CrossCutting.Extensions
{
	public static class MediatrExtension
	{
		public static void AddMediatRApi(this IServiceCollection services)
		{
			services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(GetProductsQueryHandler)));
		}
	}
}
