using ApiPloomes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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

			return services;
		}
	}
}
