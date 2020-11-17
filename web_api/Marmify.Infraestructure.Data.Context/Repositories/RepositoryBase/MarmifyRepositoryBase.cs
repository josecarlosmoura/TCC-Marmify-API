using Marmify.Domain.Interfaces.Commons;
using Marmify.Infraestructure.Data.Context.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Marmify.Infraestructure.Data.Context.Repositories.RepositoryBase
{
	public class MarmifyRepositoryBase<TEntity> : IMarmifyRepositoryBase<TEntity>, IDisposable where TEntity : class
	{
		protected readonly DbContextOptionsBuilder<MarmifyContext> _dbContextOptionsBuilder;
		private readonly DbContext _dbContext;
		protected DbSet<TEntity> _dbSet { get; private set; }

		public MarmifyRepositoryBase()
		{
			_dbContextOptionsBuilder = new DbContextOptionsBuilder<MarmifyContext>();
			_dbContext = new MarmifyContext(_dbContextOptionsBuilder.Options);
			_dbSet = _dbContext.Set<TEntity>();
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _dbSet;
		}

		public TEntity GetById(long id)
		{
			return _dbSet.Find(id);
		}

		public TEntity CreateEntity(TEntity entity)
		{
			_dbSet.Add(entity);
			_dbContext.SaveChanges();

			return entity;
		}

		public void RemoveEntity(TEntity entity)
		{
			_dbSet.Remove(entity);
			_dbContext.SaveChanges();
		}

		public TEntity UpdateEntity(TEntity entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			_dbContext.Update(entity);
			_dbContext.SaveChanges();
			return entity;
		}

		public IEnumerable<TEntity> GetByInclude(Expression<Func<TEntity, bool>> predicate, IList<string> listIncludes)
		{
			IQueryable<TEntity> query = _dbSet;
			if (listIncludes != null && listIncludes.Any())
			{
				foreach (var inc in listIncludes)
					query = query.Include(inc);
			}
			return query.Where(predicate).ToList();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool isDispose)
		{
			if (!isDispose) return;
		}

		~MarmifyRepositoryBase()
		{
			Dispose(false);
		}
	}
}
