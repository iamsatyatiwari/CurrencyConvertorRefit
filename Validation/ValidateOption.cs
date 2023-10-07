using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvertor
{
    public class ValidateOption
    {
        public static bool Validate(string? option)
        {
            if (int.TryParse(option, out int number))
            {
               if(Convert.ToInt32(option) >= 0 && Convert.ToInt32(option) <= 5)
                {
                    return true ;
                } 
            }
            Console.WriteLine("Enter Valid number!!!!!!!!");
            return false;
        }
    }
}
