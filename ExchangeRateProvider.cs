using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConvertor
{
    public class ExchangeRateProvider
    {
        private readonly ICurrencyConvert Client;
        private readonly string ApiKey;
        public ExchangeRateProvider(ICurrencyConvert client, IConfigurationRoot builder)
        {
            Client = client;
            ApiKey = builder["ApiKey"];
        }

        // Base currency is in EUR
        decimal fromWrtBase = 0.0m;
        decimal toWrtBase = 0.0m;
        public async Task GetExchangeRate(string from, string to, decimal amountToConvert,DateTime? date)
        {
            DataModel data = null;
            try
            {
                var dateString = date?.ToString("yyyy-MM-dd");
                data = date!=null ? await Client.GetAllTasksByDate(ApiKey, from, to, dateString)
                    : await Client.GetAllTasks(ApiKey, from, to); 
            }
            catch (ApiException)
            {
                Console.WriteLine($"API Exception occured");
            }
            catch (Exception)
            {
                Console.WriteLine($"There is a Error in fetching exchange rates");
            }
            fromWrtBase = data.Rates.Where(rate => rate.Key == from.ToUpper()).Select(rate => rate.Value).FirstOrDefault();
            toWrtBase = data.Rates.Where(rate => rate.Key == to.ToUpper()).Select(rate => rate.Value).FirstOrDefault();

            if (from == to)
            {
                Console.WriteLine($"{amountToConvert} {from} in {to} is -> " + amountToConvert);
            }
            else
            {
                var convertedCurrency = GetConvertedCurrency(amountToConvert);
                if (convertedCurrency >= 0.0m)
                {
                    Console.WriteLine($"{amountToConvert} {from} in {to} is ->" + convertedCurrency);
                }
            }
        }
        private decimal GetConvertedCurrency(decimal amountToConvert)
        {
            decimal convertedCurrency = 0.0m;
            decimal amountEur = amountToConvert / fromWrtBase;//rateEurToUsd, converting usd to eur
            if(fromWrtBase==0 || toWrtBase == 0)
            {
                return convertedCurrency;
            }
            try
            {
                convertedCurrency = amountEur * toWrtBase;//EurTOINR,coverting eur to inr
            }
            catch (OverflowException)
            {
                Console.WriteLine("Converted amount is too large to handle.");
                return -1.0m;
            }
            catch(Exception)
            {
                Console.WriteLine("An error occured while currency conversion");
            }
            return convertedCurrency;
        }
    }
}
