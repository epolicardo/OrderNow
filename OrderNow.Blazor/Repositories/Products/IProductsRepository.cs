using System.Linq.Expressions;

namespace Repositories
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        Task<bool> CreateAsync(Product entity);

        Task<bool> EditAsync(Product entity);

        Task<Product> FindByConditionAsync(Expression<Func<Product, bool>> predicate);

        Task<List<Product>> GetAll();

        Task<Product> GetByIdAsync(Guid Id);

        Task<List<FavoriteProducts>> GetFavoriteProductsByUserAsync(string email);

        Task<Product> GetFullProductById(Guid id);

        List<Product> ProductByName(string name);

        Task<IEnumerable<Product>> ProductsByBusiness(Guid businessId);

        Task<IEnumerable<Product>> ProductsByContractURLAsync(string contractURL);

        Task<int> SaveAsync();

        Task<IEnumerable<Product>> SugestedProductsByBusiness(string ContractURL);
    }
}