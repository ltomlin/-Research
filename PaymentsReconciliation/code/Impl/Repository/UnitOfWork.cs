using System;

namespace PaymentsReconciliation.Impl.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext = null;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;

            ItemPrices = new ItemPriceRepository(dataContext);
            Payments = new PaymentRepository(dataContext);
            Purchases = new PurchaseRepository(dataContext);
        }

        public IItemPriceRepository ItemPrices
        {
            get; private set;
        }

        public IPaymentRepository Payments
        {
            get; private set;
        }

        public IPurchaseRepository Purchases
        {
            get; private set;
        }

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
