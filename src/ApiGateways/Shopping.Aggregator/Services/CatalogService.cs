using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CatalogModel>?> GetCatalogAsync()
        {
            var response = await _client.GetAsync("/api/v1/Catalog");
            return await response.ReadContentAsAsync<IEnumerable<CatalogModel>>();
        }

        public async Task<CatalogModel?> GetCatalogByIdAsync(string id)
        {
            var response = await _client.GetAsync($"/api/v1/Catalog/GetProduct/{id}");
            return await response.ReadContentAsAsync<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>?> GetCatalogByCategoryAsync(string category)
        {
            var response = await _client.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");
            return await response.ReadContentAsAsync<IEnumerable<CatalogModel>>();
        }
    }
}
