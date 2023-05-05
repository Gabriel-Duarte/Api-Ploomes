using ApiPloomes.Domain.Interfaces;
using ApiPloomes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiPloomes.Infrastructure.Repositories
{
	public class Repository<T> : IRepository<T> where T : class 
	{
		protected AppDbContext _context;

		public Repository(AppDbContext contexto)
		{
			_context = contexto;
		}

		public IQueryable<T> Get()
		{
			return _context.Set<T>().AsNoTracking();
		}

		public T GetById(Expression<Func<T, bool>> predicate)
		{
			return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);
		}

		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public void Update(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			_context.Set<T>().Update(entity);
		}
	}
}
