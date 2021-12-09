﻿using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderResponseModel>?> GetOrderByUserNameAsync(string userName)
        {
            var response = await _client.GetAsync($"/api/v1/Order/GetOrder/{userName}");
            return await response.ReadContentAsAsync<IEnumerable<OrderResponseModel>>();
        }
    }
}
