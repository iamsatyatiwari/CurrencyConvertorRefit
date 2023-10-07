using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CurrencyConvertor
{
    internal class CurrencyCodeFile
    {

        public static Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        public static void getCurrencyData()
        {
            Dictionary<string, string> currencyCodeWrtCountry = new Dictionary<string, string>();
            var currencyList = File.ReadAllLines(Path.PathToCurrencyCode());
            foreach (var line in currencyList)
            {
                var data = line.Split(',');
                currencyCodeWrtCountry.Add(data[0], data[1]);

            }
            keyValuePairs = currencyCodeWrtCountry;
            return;
        }

    }
}
