using OrderNow.Blazor.Data;
using System.Linq.Expressions;

namespace Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly DataContext _dataContext;

        public UsersRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<bool> CreateAsync(User entity)
        {
            return base.CreateAsync(entity);
        }

        public Task<bool> EditAsync(User entity)
        {
            return base.EditAsync(entity);
        }

        public Task<User> FindByConditionAsync(Expression<Func<User, bool>> predicate)
        {
            return base.FindByConditionAsync(predicate);
        }

        public Task<List<User>> GetAll()
        {
            return base.GetAll();
        }

        public async Task<List<UserBusiness>> GetBusinessesByUser(User users)
        {
            return await _dataContext.UsersBusinesses.Where(x => x.User.Email == users.Email).ToListAsync();
        }

        public Task<User> GetByIdAsync(Guid Id)
        {
            return base.GetByIdAsync(Id);
        }

        public async Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email)
        {
            return await _dataContext.UsersBusinesses.Where(x => x.User.Email == email).Include(x => x.Business).Include(x => x.User).Where(x => x.IsFavorite == true).ToListAsync();
        }

        public async Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email)
        {
            return await _dataContext.UsersBusinesses.Where(x => x.User.Email == email).Include(x => x.Business).Include(x => x.User).Where(x => x.LastVisit < DateTime.Now.AddDays(15)).ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dataContext.Users?.Include(p => p.Person).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetUserDataForLogin(string email)
        {
            return await _dataContext.Users.Include(x => x.AssosiatedBusiness).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task GetUserProfileData(string email)
        {
            await _dataContext.Users.Include(x => x.Person).Where(x => x.Email == email).AsNoTracking().ToListAsync();
        }

        public Task<List<UserBusiness>> SetFavoriteBusinessesByUserAsync(UserBusiness relation)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUsersRepository.SetFavoriteBusinessesByUserAsync(UserBusiness relation)
        {
            throw new NotImplementedException();
        }
    }
}