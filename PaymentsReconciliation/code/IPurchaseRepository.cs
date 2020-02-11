using PaymentsReconciliation.Impl.Repository.Domain;
using System.Collections.Generic;

namespace PaymentsReconciliation
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        List<PaymentsNotMatched> GetPaymentsNotMatched();
    }
}
