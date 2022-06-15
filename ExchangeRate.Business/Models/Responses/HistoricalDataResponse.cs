using System;
using System.Collections.Generic;

namespace ExchangeRate.Business.Models
{
    public class HistoricalDataResponse
    {
        public bool Success { get; set; }
        public bool Historical { get; set; }
        public string Base { get; set; }
        public DateTime date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
        public HistoricalDataMotd Motd { get; set; }
    }

    public class HistoricalDataMotd
    {
        public string Msg { get; set; }
        public string Url { get; set; }
    }
}
