using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogModel>> GetCatalogAsync();
        Task<IEnumerable<CatalogModel>> GetCatalogByCategpryAsync(string category);
        Task<CatalogModel> GetCatalogByIdAsync(string id);
        Task<CatalogModel> CreateCatalogAsync(CatalogModel model);
    }
}
