using PaymentsReconciliation.Impl.Repository.Domain;

namespace PaymentsReconciliation
{
    public interface IItemPriceRepository : IRepository<ItemPrice>
    {
        ItemPrice GetItemPriceById(string id);
    }
}
