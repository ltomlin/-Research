using PaymentsReconciliation.Impl.Repository.Domain;

namespace PaymentsReconciliation
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Payment GetPaymentByYearAndMonth(string id, int year, int month);
    }
}
