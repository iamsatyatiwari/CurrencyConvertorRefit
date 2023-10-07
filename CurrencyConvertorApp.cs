using CurrencyConvertor;
using Microsoft.Extensions.Configuration;
using Refit;
using System;

namespace API_Practice
{

    public class CurrencyConvertorApp
    {
        static async Task Main(string[] args)
        {

            var builder = new ConfigurationBuilder().AddJsonFile("AppSetting.json").Build();

            var client = RestService.For<ICurrencyConvert>(builder["UrlToApi"]);

            ExchangeRateProvider exchangeRateProvider = new(client, builder);

            CurrencyCodeFile.getCurrencyData();
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            ConsoleInterface.WelcomeMsg();
            string from = "", to = "";
            decimal amountToConvert = 0.0m;
            DateTime date = new();
            int option;
            bool inputsHandled = true;
            while (true)
            {
                while (true)
                {
                    ConsoleInterface.UI();
                    string input = Console.ReadLine();
                    if (!ValidateOption.Validate(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong Input, taking back to main menu");
                        await Task.Delay(1000);
                        Console.Clear();
                        continue;
                    }
                    option = Convert.ToInt32(input);
                    TakeInputs.HandleInputsFromUser(ref from, ref to, ref amountToConvert, ref inputsHandled, option, ref date);
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (inputsHandled)
                {
                    switch (option)
                    {
                        case 1:
                            await exchangeRateProvider.GetExchangeRate(from, to, amountToConvert,null);
                            break;

                        case 2:
                            await exchangeRateProvider.GetExchangeRate(from, to, amountToConvert, date);
                            break;

                        case 3:
                            Console.WriteLine("Enter country name without spaces,e.g. UnitedStates");
                            string? country = Console.ReadLine();
                            CurrencyCodeSearcher.CodeSearchByCountryName(country);
                            break;

                        case 4:
                            Console.WriteLine("Enter character to display the list of country code with it:  ");
                            char firstLetter = Console.ReadKey().KeyChar;
                            CurrencyCodeSearcher.GetCodeByFirstLetter(firstLetter);
                            break;

                        case 5:
                            UpdateAppSetting.AppSetting();
                            break;

                        case 0:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            ConsoleInterface.GoodByeMsg();
                            return;
                    }
                }

            }
        }
    }
}

