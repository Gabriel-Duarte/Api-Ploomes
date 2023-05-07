using ApiPloomes.Application.Mapping;
using ApiPloomes.CrossCutting.Extensions;
using ApiPloomes.Domain.Interfaces;
using ApiPloomes.Infrastructure.Context;
using ApiPloomes.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPloomes.CrossCutting.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services,
			IConfiguration configuration)
		{
			string mySqlConnection = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<AppDbContext>(options =>
						 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
						), b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});
			IMapper mapper = mappingConfig.CreateMapper();

			services.AddSingleton(mapper);
			services.AddMediatRApi();
			return services;
		}
	}
}
