using Newtonsoft.Json.Linq;
using PaymentsReconciliation.Impl.Repository.Domain;
using System.Configuration;
using System.IO;

namespace PaymentsReconciliation.Impl.Parser.Providers
{
    public class JsonDataProvider : IDataProvider
    {
        public void LoadData(IUnitOfWork unitOfWork)
        {
            var json = File.ReadAllText($"{ConfigurationManager.AppSettings["FileLocation"]}\\Payments.json");
            var objects = JArray.Parse(json);

            foreach (JObject item in objects)
            {
                unitOfWork.Payments.Add(new Payment
                {
                    Amount = double.Parse(item.GetValue("Amount").ToString()),
                    Customer = item.GetValue("Customer").ToString(),
                    Month = int.Parse(item.GetValue("Month").ToString()),
                    Year = int.Parse(item.GetValue("Year").ToString())
                });
            }
        }
    }
}
