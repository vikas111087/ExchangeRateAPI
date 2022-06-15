
using ExchangeRate.Business.Models.Requests;
using System.Threading.Tasks;

namespace ExchangeRate.Business
{
    public interface IExchangeRateService
    {
        Task<string> GetExchangeRates(ExchangeRateRequestDto requestDto);
    }
}