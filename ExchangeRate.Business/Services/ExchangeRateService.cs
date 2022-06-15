using ExchangeRate.Business.Models.Requests;
using ExchangeRate.Business.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRate.Business
{
    public class ExchangeRateService : IExchangeRateService
    {
        private const string EXCHANGE_RATE_CONVERT_URL = "https://api.exchangerate.host/convert";

        public async Task<string> GetExchangeRates(ExchangeRateRequestDto requestDto)
        {           

            var loadingTasks = new List<Task<Dictionary<string, decimal>>>();

            foreach (var date in requestDto.Dates)
            {
                var task = ProcessCurrencyConvertByDate(date, requestDto.BaseCurrency, requestDto.TargetCurrency);
                loadingTasks.Add(task);
            }

            var rates = await Task.WhenAll(loadingTasks);
            var exchangeRatesDic = rates.SelectMany(dict => dict)
                         .ToDictionary(pair => pair.Key, pair => pair.Value);

            var result = GetExchangeRateOutput(exchangeRatesDic);
            return result;
        }

        private async Task<Dictionary<string, decimal>> ProcessCurrencyConvertByDate(DateTime date, string baseCurrency, string targetCurrency)
        {
            var dic = new Dictionary<string, decimal>();
            decimal currencyConvertRate;
            try
            {
                using (var client = new HttpClient())
                {
                    var d = date.ToString("yyyy-MM-dd");
                    var url = $"{EXCHANGE_RATE_CONVERT_URL}?from={baseCurrency}&to={targetCurrency}&date={d}";
                    var result = await client.GetAsync(url);
                    result.EnsureSuccessStatusCode();
                    var response = JsonConvert.DeserializeObject<CurrencyConvertResponse>(await result.Content.ReadAsStringAsync());
                    currencyConvertRate = response.result;
                    dic.Add(d, response.result);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed due to : {ex.Message}");
            }
            
            return dic;
        }

        private string GetExchangeRateOutput(Dictionary<string, decimal> exchangeRatesDic)
        {
            var result = string.Empty;

            var minRate = exchangeRatesDic.OrderBy(k => k.Value).FirstOrDefault();
            var maxRate = exchangeRatesDic.OrderBy(k => k.Value).LastOrDefault();
            var averageScore = exchangeRatesDic.Values.Average();

            result = $"The min rate of {minRate.Value} on {minRate.Key}";
            result += $"\nThe max rate of {maxRate.Value} on {maxRate.Key}";
            result += $"\nThe average rate of {averageScore}";

            return result;
        }
    }
}