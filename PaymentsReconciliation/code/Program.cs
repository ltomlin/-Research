using Newtonsoft.Json;
using PaymentsReconciliation.Impl.DataProvider;
using PaymentsReconciliation.Impl.Repository;
using PaymentsReconciliation.Impl.Util;
using System.Configuration;
using System.IO;

namespace PaymentsReconciliation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new DataContext()))
            {
                // load item prices data
                DataProviderFactory.GetProvider(Enums.DataTypeEnum.Xml).LoadData(unitOfWork);

                // load payments data
                DataProviderFactory.GetProvider(Enums.DataTypeEnum.Json).LoadData(unitOfWork);

                // load purchases data 
                DataProviderFactory.GetProvider(Enums.DataTypeEnum.Text).LoadData(unitOfWork);

                //  get payment not matched
                var paymentsNotMatched = unitOfWork.Purchases.GetPaymentsNotMatched();

                // save as json
                var json = JsonConvert.SerializeObject(paymentsNotMatched);
                File.WriteAllText($"{ConfigurationManager.AppSettings["FileLocation"]}\\PaymentsNotMatched.json", json);
                
                // save as csv
                Helper.ExportAsCsv(paymentsNotMatched, true);
            }
        }
    }
}
