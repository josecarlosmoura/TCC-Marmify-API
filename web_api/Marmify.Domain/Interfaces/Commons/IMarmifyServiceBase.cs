using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Marmify.Domain.Interfaces.Commons
{
    public interface IMarmifyServiceBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Return all elements.
        /// </summary>
        /// <returns>IEnumerable whit all elements of the passed entity.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Return element with the last id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Element with the last id.</returns>
        TEntity GetById(long id);

        /// <summary>
        /// Create a new entitie.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>A new entitie that was created.</returns>
        TEntity CreateEntity(TEntity entity);

        /// <summary>
        /// Update a entitie already existing.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The entitie with the new changes.</returns>
        TEntity UpdateEntity(TEntity entity);

        /// <summary>
        /// Remove entity that was passed.
        /// </summary>
        /// <param name="entity"></param>
        void RemoveEntity(TEntity entity);

        /// <summary>
        /// Get entity making joins.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="listIncludes"></param>
        /// <returns>Entiie making eager loading.</returns>
        IEnumerable<TEntity> GetByInclude(Expression<Func<TEntity, bool>> predicate, IList<string> listIncludes);

        /// <summary>
        /// Dispose.
        /// </summary>
        void Dispose();
    }
}
