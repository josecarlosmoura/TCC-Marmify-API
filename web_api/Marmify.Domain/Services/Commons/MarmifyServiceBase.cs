using Marmify.Domain.Interfaces.Commons;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Marmify.Domain.Services.Commons
{
    public class MarmifyServiceBase<TEntiry> : IMarmifyServiceBase<TEntiry>, IDisposable where TEntiry : class
    {
        private readonly IMarmifyRepositoryBase<TEntiry> _marmifyRepositoryBase;

        public MarmifyServiceBase(IMarmifyRepositoryBase<TEntiry> marmifyRepositoryBase)
        {
            _marmifyRepositoryBase = marmifyRepositoryBase;
        }

        public IEnumerable<TEntiry> GetAll()
        {
            return _marmifyRepositoryBase.GetAll();
        }

        public TEntiry GetById(long id)
        {
            return _marmifyRepositoryBase.GetById(id);
        }

        public TEntiry CreateEntity(TEntiry entity)
        {
            return _marmifyRepositoryBase.CreateEntity(entity);
        }

        public void RemoveEntity(TEntiry entity)
        {
            _marmifyRepositoryBase.RemoveEntity(entity);
        }

        public TEntiry UpdateEntity(TEntiry entity)
        {
            return _marmifyRepositoryBase.UpdateEntity(entity);
        }
        public IEnumerable<TEntiry> GetByInclude(Expression<Func<TEntiry, bool>> predicate, IList<string> listIncludes)
        {
            return _marmifyRepositoryBase.GetByInclude(predicate, listIncludes);
        }

        public void Dispose()
        {
            _marmifyRepositoryBase.Dispose();
        }

    }
}
