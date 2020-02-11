namespace PaymentsReconciliation.Impl.Repository.Domain
{
    public class Payment
    {
        public string Customer { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public double Amount { get; set; }

    }
}
