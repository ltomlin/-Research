using System.Collections.Generic;

namespace PaymentsReconciliation.Impl.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext dataContext = null;

        public Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(TEntity entity)
        {
            dataContext.Set<TEntity>().Add(entity);
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            return dataContext.Set<TEntity>();
        }
    }
}
