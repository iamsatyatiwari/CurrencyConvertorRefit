using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvertor
{
    internal class ConsoleInterface
    {
        public static void UI()
        {
            Console.WriteLine();
            Console.WriteLine("*-----------------------------------------------------------------------------------------------------------------------*");
            Console.WriteLine("*---------------------------------------------Welcome to Currency-Convertor-App-----------------------------------------*");
            Console.WriteLine("*-----------------------------------------------------------------------------------------------------------------------*");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*----------------Choose Your Option Number----------------*");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("*-----> 1-  Convert Currency");
            Console.WriteLine("*-----> 2-  Convert Currency By Date");
            Console.WriteLine("*-----> 3-  Get Currency Code By Country Name");
            Console.WriteLine("*-----> 4-  Get Country CurrencyCode list By first letter");
            Console.WriteLine("*-----> 5-  Add your api key");
            Console.WriteLine("*-----> 0-  Exit");

        }
        public static void GoodByeMsg()
        {
            Console.WriteLine("\n\n\n\n██   ██  █████  ██    ██ ███████      █████      ███    ██ ██  ██████ ███████     ██████   █████  ██    ██     ██ \r\n██   ██ ██   ██ ██    ██ ██          ██   ██     ████   ██ ██ ██      ██          ██   ██ ██   ██  ██  ██      ██ \r\n███████ ███████ ██    ██ █████       ███████     ██ ██  ██ ██ ██      █████       ██   ██ ███████   ████       ██ \r\n██   ██ ██   ██  ██  ██  ██          ██   ██     ██  ██ ██ ██ ██      ██          ██   ██ ██   ██    ██           \r\n██   ██ ██   ██   ████   ███████     ██   ██     ██   ████ ██  ██████ ███████     ██████  ██   ██    ██        ██ \r\n                                                                                                                  \r\n                                                                                                                  ");

        }
        public static void WelcomeMsg()
        {
            Console.WriteLine(" █████╗ ██████╗ ███╗   ██╗ █████╗      ██████╗ ██████╗ ███╗   ██╗██╗   ██╗███████╗██████╗ ████████╗ ██████╗ ██████╗ \r\n██╔══██╗██╔══██╗████╗  ██║██╔══██╗    ██╔════╝██╔═══██╗████╗  ██║██║   ██║██╔════╝██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗\r\n███████║██████╔╝██╔██╗ ██║███████║    ██║     ██║   ██║██╔██╗ ██║██║   ██║█████╗  ██████╔╝   ██║   ██║   ██║██████╔╝\r\n██╔══██║██╔═══╝ ██║╚██╗██║██╔══██║    ██║     ██║   ██║██║╚██╗██║╚██╗ ██╔╝██╔══╝  ██╔══██╗   ██║   ██║   ██║██╔══██╗\r\n██║  ██║██║     ██║ ╚████║██║  ██║    ╚██████╗╚██████╔╝██║ ╚████║ ╚████╔╝ ███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║\r\n╚═╝  ╚═╝╚═╝     ╚═╝  ╚═══╝╚═╝  ╚═╝     ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝  ╚═══╝  ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝\r\n                                                                                                                    ");
        }

    }
}
