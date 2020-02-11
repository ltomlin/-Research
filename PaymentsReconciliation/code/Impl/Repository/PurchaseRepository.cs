using System.Collections.Generic;
using PaymentsReconciliation.Impl.Repository.Domain;
using System.Linq;
using System;

namespace PaymentsReconciliation.Impl.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        private DataContext dataContext;

        public PurchaseRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<PaymentsNotMatched> GetPaymentsNotMatched()
        {
            var paymentsNotMatched = new List<PaymentsNotMatched>();

            foreach (var payment in dataContext.Payments)
            {
                var purchases = dataContext.Purchases
                    .Where(x => x.Payment.Customer == payment.Customer
                        && x.Payment.Year == payment.Year
                        && x.Payment.Month == payment.Month)
                    .SelectMany(x => x.Items)
                    .ToList();

                var amountToBePaid = Math.Round(purchases.Sum(x => x.Price), 2);

                if (amountToBePaid != payment.Amount)
                {
                    paymentsNotMatched.Add(new PaymentsNotMatched
                    {
                        AmountDue = payment.Amount,
                        AmountPaid = amountToBePaid,
                        Customer = payment.Customer,
                        Year = payment.Year,
                        Month = payment.Month
                    });
                }
            }

            return paymentsNotMatched.OrderByDescending(x => x.Balance).ToList();
           
        }
    }
}