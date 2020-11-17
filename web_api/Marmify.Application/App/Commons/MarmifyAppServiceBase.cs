using Marmify.Application.Interfaces.Commons;
using Marmify.Domain.Interfaces.Commons;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Marmify.Application.App.Commons
{
    public class MarmifyAppServiceBase<TEntity> : IMarmifyServiceBase<TEntity>, IDisposable where TEntity : class
    {
        private readonly IMarmifyServiceBase<TEntity> _marmifiAppServiceBase;

        public MarmifyAppServiceBase(IMarmifyServiceBase<TEntity> marmifyServiceBase)
        {
            _marmifiAppServiceBase = marmifyServiceBase;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _marmifiAppServiceBase.GetAll();
        }

        public TEntity GetById(long id)
        {
            return _marmifiAppServiceBase.GetById(id);
        }

        public TEntity CreateEntity(TEntity entity)
        {
            return _marmifiAppServiceBase.CreateEntity(entity);
        }

        public void RemoveEntity(TEntity entity)
        {
            _marmifiAppServiceBase.RemoveEntity(entity);
        }

        public TEntity UpdateEntity(TEntity entity)
        {
            return _marmifiAppServiceBase.UpdateEntity(entity);
        }
        public IEnumerable<TEntity> GetByInclude(Expression<Func<TEntity, bool>> predicate, IList<string> listIncludes)
        {
            return _marmifiAppServiceBase.GetByInclude(predicate, listIncludes);
        }

        public void Dispose()
        {
            _marmifiAppServiceBase.Dispose();
        }

    }
}
