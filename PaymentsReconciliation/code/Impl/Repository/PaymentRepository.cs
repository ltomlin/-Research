using PaymentsReconciliation.Impl.Repository.Domain;

namespace PaymentsReconciliation.Impl.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private DataContext dataContext;

        public PaymentRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public Payment GetPaymentByYearAndMonth(string id, int year, int month)
        {
            return dataContext.Payments.Find(x => x.Customer == id && x.Year == year && x.Month == month);
        }
    }
}