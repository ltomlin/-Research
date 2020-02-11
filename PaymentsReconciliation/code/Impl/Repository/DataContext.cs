using PaymentsReconciliation.Impl.Repository.Domain;
using System;
using System.Collections.Generic;

namespace PaymentsReconciliation.Impl.Repository
{
    public class DataContext: IDisposable
    {
        public DataContext()
        {
            ItemPrices = new List<ItemPrice>();
            Payments = new List<Payment>();
            Purchases = new List<Purchase>();
        }

        public List<ItemPrice> ItemPrices { get; set; }

        public List<Payment> Payments  { get; set; }

        public List<Purchase> Purchases { get; set; }

        internal List<TEntity> Set<TEntity>() where TEntity : class
        {
            if (typeof(TEntity) == typeof(ItemPrice))
            {
                return ItemPrices as List<TEntity>;
            }
            else if (typeof(TEntity) == typeof(Payment))
            {
                return Payments as List<TEntity>;
            }
            else
            {
                return Purchases as List<TEntity>;
            }
        }

        public void Dispose(){}
    }
}

