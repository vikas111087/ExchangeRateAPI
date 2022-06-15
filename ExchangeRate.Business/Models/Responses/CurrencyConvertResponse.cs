using System;

namespace ExchangeRate.Business.Models.Responses
{
    public class CurrencyConvertResponse
    {
        public ExchangeRateMotd motd { get; set; }

        public bool success { get; set; }
        public CurrencyConvertQuery query { get; set; }
        public CurrencyConvertInfo info { get; set; }
        public bool historical { get; set; }
        public DateTime date { get; set; }
        public decimal result { get; set; }
    }

    public class CurrencyConvertQuery
    {
        public string from { get; set; }
        public string to { get; set; }
        public string amount { get; set; }
    }

    public class CurrencyConvertInfo {
        public decimal rate { get; set; }
    }
}