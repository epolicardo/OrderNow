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

        public Task<bool> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(User entity)
        {
            return base.EditAsync(entity);
        }

        public Task<User> FindByConditionAsync(Expression<Func<User, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAciveUsersAsync()
        {
            return await _usersRepository.GetAciveUsersAsync();
        }

        public Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return _usersRepository.GetAciveUsersAsync();
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

        public async Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email)
        {
            return await _usersRepository.GetFavoriteBusinessesByUserAsync(email);
        }

        public async Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email)
        {
            return await _usersRepository.GetLastVisitedBusinessesByUserAsync(email);
        }

        public async Task<User> GetUserDataForLogin(string email)
        {
            return await _usersRepository.GetUserDataForLogin(email);
        }

        public async Task<bool> RemoveFavoriteBusiness(string url, Guid userId)
        {
            return false;
        }

        public Task<int> SaveAsync()
        {
            return base.SaveAsync();
        }

        public async Task<bool> SetFavoriteBusinessesByUserAsync(string email, string contractURL)
        {
            return await _usersRepository.SetFavoriteBusinessesByUserAsync(email, contractURL);
        }

        public Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email, Guid businessId)
        {
            //When an User visits a Business, this method is called to update the date of the visit.

            return _usersRepository.UpdateDateOfVisitToBusinessesByUserAsync(email, businessId);
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}