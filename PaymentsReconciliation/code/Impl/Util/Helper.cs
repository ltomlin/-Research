using PaymentsReconciliation.Impl.Repository.Domain;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PaymentsReconciliation.Impl.Util
{
    public static class Helper
    {
        public static void ExportAsCsv(List<PaymentsNotMatched> paymentsNotMatched, bool launchExcel)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Customer,Year,Month,AmountDue,AmountPaid,Balance");

            foreach (var item in paymentsNotMatched)
            {
                stringBuilder.Append($"CUST{item.Customer},");
                stringBuilder.Append($"{item.Year},");
                stringBuilder.Append($"{item.Month},");
                stringBuilder.Append($"{item.AmountDue},");
                stringBuilder.Append($"{item.AmountPaid},");
                stringBuilder.Append($"{item.Balance},");

                stringBuilder.AppendLine();

            }

            var file = $"{ConfigurationManager.AppSettings["FileLocation"]}\\PaymentsNotMatched.csv";
            System.IO.File.WriteAllText(file, stringBuilder.ToString());

            if (launchExcel)
            {
                System.Diagnostics.Process.Start(file);
            }
        }
    }
}
