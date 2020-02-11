using PaymentsReconciliation.Enums;
using PaymentsReconciliation.Impl.Parser.Providers;

namespace PaymentsReconciliation.Impl.DataProvider
{
    public static class DataProviderFactory
    {
        public static IDataProvider GetProvider(DataTypeEnum dataType)
        {
            IDataProvider dataProvider = null;

            switch (dataType)
            {
                case DataTypeEnum.Text:
                    dataProvider = new TextDataProvider();
                    break;
                case DataTypeEnum.Xml:
                    dataProvider = new XmlDataProvider();
                    break;
                case DataTypeEnum.Json:
                    dataProvider = new JsonDataProvider();
                    break;
                default:
                    break;
            }

            return dataProvider;
        }
    }
}
