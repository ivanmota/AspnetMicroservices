using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed>? logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                if (logger != null)
                {
                    logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContextSeed));
                }
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {
                    UserName = "swn",
                    FirstName = "Ivan",
                    LastName = "Mota",
                    EmailAddress = "admin@gmail.com",
                    AddressLine = "Lisbon",
                    Country = "Portugal",
                    TotalPrice = 350
                }
            };
        }
    }
}
