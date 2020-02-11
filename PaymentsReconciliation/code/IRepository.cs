using System.Collections.Generic;

namespace PaymentsReconciliation
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
    }
}
