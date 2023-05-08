using ApiPloomes.Domain.Entities;
using ApiPloomes.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Domain.Interfaces
{
	public interface ICategoryRepository : IRepository<Category>
	{
		PagedList<Category> GetCategories(QueryStringParameters queryStringParameters);
		IEnumerable<Category> GetCategoriesProducts();
	}
}
