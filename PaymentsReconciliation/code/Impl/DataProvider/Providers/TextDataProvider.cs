using PaymentsReconciliation.Impl.Repository.Domain;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace PaymentsReconciliation.Impl.Parser.Providers
{
    public class TextDataProvider : IDataProvider
    {
        public void LoadData(IUnitOfWork unitOfWork)
        {
            using (var streamReader = new StreamReader($"{ConfigurationManager.AppSettings["FileLocation"]}\\Purchases.dat"))
            {
                Purchase purchase = null;
                string customer = null;

                do
                {
                    var valueWithPrefix = streamReader.ReadLine();
                    var prefix = valueWithPrefix.Substring(0, 4);
                    var value = valueWithPrefix.Substring(4);
                    
                    if (prefix == "CUST")
                    {
                        if (purchase != null)
                        {
                            unitOfWork.Purchases.Add(purchase);
                        }

                        purchase = new Purchase();
                        customer = value;
                    }
                    else if (prefix == "DATE")
                    {
                        purchase.Date = DateTime.ParseExact(value, "ddMMyyyyHHmm", CultureInfo.InvariantCulture);
                        purchase.Payment = unitOfWork.Payments.GetPaymentByYearAndMonth(customer, purchase.Date.Year, purchase.Date.Month);

                        if (purchase.Payment == null)
                        {
                            purchase.Payment = new Payment { Customer = customer, Year = purchase.Date.Year, Month = purchase.Date.Month };
                        }
                    }
                    else if (prefix == "ITEM")
                    {
                        purchase.Items.Add(unitOfWork.ItemPrices.GetItemPriceById(value));
                    }

                } while (!streamReader.EndOfStream);

                streamReader.Close();
            }
        }
    }
}
