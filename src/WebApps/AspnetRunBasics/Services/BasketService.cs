using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task CheckoutBasketAsync(BasketCheckoutModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BasketModel> GetBasketAsync(string UserName)
        {
            throw new NotImplementedException();
        }

        public Task<BasketModel> UpdateBasketAsync(BasketModel model)
        {
            throw new NotImplementedException();
        }
    }
}
