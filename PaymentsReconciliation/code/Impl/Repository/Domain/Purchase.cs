using System;
using System.Collections.Generic;

namespace PaymentsReconciliation.Impl.Repository.Domain
{
    public class Purchase
    {
        public Purchase ()
        {
            Items = new List<ItemPrice>();
        }

        public DateTime Date { get; set; }

        public Payment Payment { get; set; }

        public List<ItemPrice> Items { get; set; }
    }
}
