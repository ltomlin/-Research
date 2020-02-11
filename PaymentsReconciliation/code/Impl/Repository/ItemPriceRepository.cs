using PaymentsReconciliation.Impl.Repository.Domain;

namespace PaymentsReconciliation.Impl.Repository
{
    public class ItemPriceRepository : Repository<ItemPrice>, IItemPriceRepository
    {
        private DataContext dataContext;

        public ItemPriceRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public ItemPrice GetItemPriceById(string id)
        {
            return dataContext.ItemPrices.Find(x => x.Item == id);
        }
    }
}