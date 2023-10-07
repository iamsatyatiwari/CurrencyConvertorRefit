using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvertor
{
    internal class TakeInputs
    {
        public static void HandleInputsFromUser(ref string from, ref string to, ref decimal amountToConvert, 
            ref bool inputHandled, int option, ref DateTime date)
        {
            while (option == 2 && inputHandled == true)
            {
                Console.WriteLine("Enter a date in the format yyyy-mm-dd: ");
                string userInput = Console.ReadLine();

                if (!ValidateInputs.ValidateDate(userInput, out date))
                {
                    continue;
                }
                inputHandled = false;
            }

            inputHandled = true;
            while (option == 1 || option == 2)
            {
                Console.WriteLine("Enter Currency code to convert from");
                from = Console.ReadLine();
                if (!ValidateInputs.ValidateFrom(from))
                {
                    continue;
                }
                while (true)
                {
                    Console.WriteLine("Enter Currency code to convert to");
                    to = Console.ReadLine();
                    if (!ValidateInputs.ValidateTo(to))
                    {
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.WriteLine("Enter Amount You Want to convert");
                    string amount = Console.ReadLine();
                    if (!ValidateInputs.ValidateAmount(amount))
                    {
                        continue;
                    }
                    else
                    {
                        decimal.TryParse(amount, out amountToConvert);
                        if (amountToConvert < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Amount can't be negative");
                            inputHandled = false;

                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}

