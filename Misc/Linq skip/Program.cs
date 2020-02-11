using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = @"year,value
2018,2
2019,5".Replace("\r", "").Split('\n');

            var csv = lines.Select(l => l.Split(',')).ToList();

            var headers = csv[0];
            var dicts = csv.Skip(1).Select(row => Enumerable.Zip(headers, row, Tuple.Create).ToDictionary(p => p.Item1, p => p.Item2)).ToArray();

            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dicts);
            Console.WriteLine(json);
        }
    }
}
