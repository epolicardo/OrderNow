using OrderNow.Blazor.Data;
using System.Linq.Expressions;

namespace Services
{
    public class UsersServices : GenericServices<User>, IUsersServices
    {
        private readonly IUsersRepository _usersRepository;

        public UsersServices(IUsersRepository usersRepository, UserManager<User> userManager) : base(usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public bool AddProductToOrder(User user, Order order, Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetFavoriteBusinessesByUserAsync(UserBusiness relation)
        {
            if (relation.User == null) { return false; }

            if (relation.Business == null) { return false; }

            return await _usersRepository.SetFavoriteBusinessesByUserAsync(relation);
        }

        public async Task<bool> RemoveFavoriteBusiness(string url, Guid userId)
        {
            return false;
        }

        public bool AssignFavoriteProductsToUsers(User user, Product product)
        {
            if (user == null) { return false; }

            if (product == null) { return false; }

            if (user.FavoriteProducts == null)
            {
                user.FavoriteProducts = new List<Product>();
            }
            user.FavoriteProducts.Add(product);
            return true;
        }

        public async Task<User> GetUserDataForLogin(string email)
        {
            return await _usersRepository.GetUserDataForLogin(email);
        }

        public Task<bool> EditAsync(User entity)
        {
            return base.EditAsync(entity);
        }

        public Task<User> FindByConditionAsync(Expression<Func<User, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return base.GetAll();
        }

        public Task<User> GetByIdAsync(Guid Id)
        {
            return base.GetByIdAsync(Id);
        }

        public async Task<User> GetByMailAsync(string email)
        {
            return await _usersRepository.GetUserByEmailAsync(email);
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }

        public async Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email)
        {
            return await _usersRepository.GetLastVisitedBusinessesByUserAsync(email);
        }

        public async Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email)
        {
            return await _usersRepository.GetFavoriteBusinessesByUserAsync(email);
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}