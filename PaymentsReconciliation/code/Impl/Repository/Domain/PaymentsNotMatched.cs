using System;

namespace PaymentsReconciliation.Impl.Repository.Domain
{
    public class PaymentsNotMatched
    {
        public string Customer { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public double AmountDue { get; set; }

        public double AmountPaid { get; set; }

        public double Balance
        {
            get
            {
                return Math.Round(AmountDue - AmountPaid, 2);

            }
        }
    }
}