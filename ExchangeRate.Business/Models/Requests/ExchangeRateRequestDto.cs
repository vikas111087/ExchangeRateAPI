using System;
using System.Collections.Generic;

namespace ExchangeRate.Business.Models.Requests
{
    public class ExchangeRateRequestDto
    {
        public List<DateTime> Dates { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}
