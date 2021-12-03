﻿using Basket.API.Entities;

namespace Basket.API.Repositores
{
    public interface IBasketRepository
    {
        Task<ShoppingCart?> GetBasketAsync(string username);
        Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart basket);
        Task DeleteBasketAsync(string username);
    }
}
