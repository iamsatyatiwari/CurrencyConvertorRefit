using Refit;
using System.Security.Cryptography;

namespace CurrencyConvertor
{
    public interface ICurrencyConvert
    {
        [Get("/api/latest?access_key={key}&symbols={from},{to}")]
        Task<DataModel> GetAllTasks(string key, string from, string to);

        [Get("/api/{date}?access_key={key}&symbols={from},{to}")]
        Task<DataModel> GetAllTasksByDate(string key, string from, string to, String date);

    }
}




