using CurrencyConvertor;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvertor
{
    public class ValidateInputs
    {
        public static bool ValidateDate(string userInput, out DateTime date)
        {
            string dateFormat = "yyyy-MM-dd";
            DateTime lowerDateLimit,higherDateLimit;
            DateTime.TryParseExact("1999-01-01", dateFormat, null, System.Globalization.DateTimeStyles.None, out lowerDateLimit);
            higherDateLimit = DateTime.Now;

            var chk = DateTime.TryParseExact(userInput, dateFormat, null, System.Globalization.DateTimeStyles.None, out date);
           
            if ((chk == true && DateTime.Compare(lowerDateLimit, date)==1)
                || (chk == true &&  DateTime.Compare(higherDateLimit, date) == -1))
            {
                Console.WriteLine("Date should be in between year 1999 to current year");
                return false;
            }
            else if (chk == true)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Date Format. Please ENter Valid date Format i.e. yyyy-MM-dd");
                return false;
            }
        }

        public static bool ValidateFrom(string from)
        {
            if (!CurrencyCodeSearcher.SearchByCurrencyCode(from))
            {
                Console.WriteLine("Invalid Input");
                return false;
            }
            return true;
        }
        public static bool ValidateTo(string to)
        {
            if (!CurrencyCodeSearcher.SearchByCurrencyCode(to))
            {
                Console.WriteLine("Invalid Input");
                return false;
            }
            return true;
        }
        public static bool ValidateAmount(string amount)
        {
            decimal amountToConvert = 0.0m;
            if (amount.Length > 27)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Given Amount is too large to convert");
                Thread.Sleep(500);
                return false;
            }
            else if (decimal.TryParse(amount, out amountToConvert))
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount");
                Thread.Sleep(500);
                return false;
            }
            
        }
    }
}
