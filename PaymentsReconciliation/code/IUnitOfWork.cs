using System;

namespace PaymentsReconciliation
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentRepository Payments { get; }

        IPurchaseRepository Purchases { get; }

        IItemPriceRepository ItemPrices { get; }

        int Complete();
    }
}
