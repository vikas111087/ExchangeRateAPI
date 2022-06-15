using ExchangeRate.Business;
using ExchangeRate.Business.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : ControllerBase
    {       
        private readonly ILogger<ExchangeRateController> _logger;
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(ILogger<ExchangeRateController> logger, IExchangeRateService exchangeRateService)
        {
            _logger = logger;
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet]
        public string GetStatus()
        {
            return "App is running Successfully";
        }

        [HttpGet("GetExchangeRatesByDates")]        
        public async Task<string> GetExchangeRates([FromBody] ExchangeRateRequestDto requestDto)
        {
            try
            {
                var result = await _exchangeRateService.GetExchangeRates(requestDto);
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}