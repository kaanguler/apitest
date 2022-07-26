using API.Core.DbModels;

namespace API.Core.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int Id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    }
}
