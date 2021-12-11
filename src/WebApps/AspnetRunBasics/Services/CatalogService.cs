using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<CatalogModel> CreateCatalogAsync(CatalogModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogModel>> GetCatalogAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogModel>> GetCatalogByCategpryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogModel> GetCatalogByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
