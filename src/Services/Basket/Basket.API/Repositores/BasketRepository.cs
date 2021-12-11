using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Repositores
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<ShoppingCart?> GetBasketAsync(string userName)
        {
            var jsonString = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrWhiteSpace(jsonString)) return null;

            var serilalizerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<ShoppingCart>(jsonString, serilalizerOptions);
        }

        public async Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart basket)
        {
            //var serilalizerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            //var jsonString = JsonSerializer.Serialize(basket, serilalizerOptions);

            var jsonString = JsonSerializer.Serialize(basket);

            await _redisCache.SetStringAsync(basket.UserName, jsonString);

            return await GetBasketAsync(basket.UserName);
        }

        public async Task DeleteBasketAsync(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}
