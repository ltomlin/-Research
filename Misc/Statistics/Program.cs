using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

class Program
{
    static void Main()
    {
        // Create an XML reader for this file.
        using (XmlReader reader = XmlReader.Create(new StringReader(
@"<Data><Bars log_return=""-0.00870""/><Bars log_return=""-0.00840""/><Bars log_return=""0.00000""/></Data>")))
        {
            var samples = new List<double>();

            while (reader.Read())
            {
                if (reader.IsStartElement() && reader.Name == "Bars")
                {
                    samples.Add(double.Parse(reader.GetAttribute("log_return")));
                }
            }

            GetKurtosis(@"<Data><Bars log_return=""-0.00870""/><Bars log_return=""-0.00840""/><Bars log_return=""0.00000""/></Data>");
            var statistic = new Normal();

            statistic.Samples();
            
            Console.WriteLine(Statistics.Kurtosis(samples));
            Console.WriteLine(statistic.Skewness);
            Console.WriteLine(Normal.PDF(statistic.Mean, statistic.StdDev, 0.9));
            Console.WriteLine(Normal.CDF(statistic.Mean, statistic.StdDev, 0.9));

        }
    }

    public static double? GetKurtosis(String sample)
    {
        double? kurtosis = null;

        try
        {

            using (XmlReader reader = XmlReader.Create(new StringReader(sample)))
            {
                var samples = new List<double>();

                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name == "Bars")
                    {
                        samples.Add(double.Parse(reader.GetAttribute("log_return")));
                    }
                }

                kurtosis = Statistics.Kurtosis(samples);

                if (kurtosis.HasValue && (double.IsInfinity(kurtosis.Value) || double.IsNaN(kurtosis.Value)))
                    kurtosis = 0;
 
            }


        }
        catch (System.Exception)
        {
        }

        return kurtosis;
    }
}