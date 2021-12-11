using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasketAsync(string UserName);
        Task<BasketModel> UpdateBasketAsync(BasketModel model);
        Task CheckoutBasketAsync(BasketCheckoutModel model);

    }
}
