using PaymentsReconciliation.Impl.Repository.Domain;
using System.Configuration;
using System.Xml;

namespace PaymentsReconciliation.Impl.Parser.Providers
{
    public class XmlDataProvider : IDataProvider
    {
        public void LoadData(IUnitOfWork unitOfWork)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load($"{ConfigurationManager.AppSettings["FileLocation"]}\\Prices.xml");

            foreach (XmlNode xmlNode in xmlDoc.SelectNodes(@"//ItemPrice"))
            {
                unitOfWork.ItemPrices.Add(new ItemPrice
                {
                    Item = xmlNode.ChildNodes[0].InnerText,
                    Price = double.Parse(xmlNode.ChildNodes[1].InnerText)
                });
            }
        }
    }
}
