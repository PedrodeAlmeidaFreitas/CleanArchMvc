using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    interface IProductRepository
    {
        Task<IEnumerable<Product>> GetCategoriesAsync();
        Task<Product> GetByIdAsync(int? id);
        Task<Product> GetProductCategoryAsync(int? id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}
