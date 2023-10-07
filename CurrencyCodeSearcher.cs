using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvertor
{
    internal class CurrencyCodeSearcher
    {
        public static bool SearchByCurrencyCode(string input)
        {
            foreach (var line in CurrencyCodeFile.keyValuePairs)
            {
                if (line.Key == input.ToUpper())
                {
                    return true;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;

            return false;

        }
        public static void CodeSearchByCountryName(string CountryName)
        {
            foreach (var line in CurrencyCodeFile.keyValuePairs)
            {
                if (line.Value.ToUpper() == CountryName.Trim().ToUpper())
                {
                    Console.WriteLine($"CurrencyCode for {line.Value} is  " + line.Key);
                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Match found! ");
            return;
        }

        public static void GetCodeByFirstLetter(char c)
        {
            Console.WriteLine();
            if (char.IsLetter(c))
            {
                Console.WriteLine($"CurrencyCode with letter {c} is :");
                foreach (var line in CurrencyCodeFile.keyValuePairs)
                {
                    if (line.Value[0] == char.ToUpper(c))
                    {
                        Console.WriteLine(line);

                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Character ");
            }

        }
    }
}
