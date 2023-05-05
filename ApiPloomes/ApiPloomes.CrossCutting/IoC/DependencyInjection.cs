using ApiPloomes.CrossCutting.Extensions;
using ApiPloomes.Domain.Interfaces;
using ApiPloomes.Infrastructure.Context;
using ApiPloomes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

			services.AddScoped<IProdutoRepository, ProdutoRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddMediatRApi();
			return services;
		}
	}
}
