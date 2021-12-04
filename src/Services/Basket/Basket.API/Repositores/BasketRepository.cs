using Basket.API.Entities;
using Basket.API.Parsing;
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

            var serilalizerOptions = SerializerOptionsFactory.GetSerializerOptions();
            return JsonSerializer.Deserialize<ShoppingCart?>(jsonString, serilalizerOptions);
        }

        public async Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart basket)
        {
            var serilalizerOptions = SerializerOptionsFactory.GetSerializerOptions();
            var jsonString = JsonSerializer.Serialize(basket, serilalizerOptions);

            await _redisCache.SetStringAsync(basket.Username, jsonString);

            return await GetBasketAsync(basket.Username);
        }

        public async Task DeleteBasketAsync(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}
