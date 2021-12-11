using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<IEnumerable<OrderResponseModel>> GetOrderByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
