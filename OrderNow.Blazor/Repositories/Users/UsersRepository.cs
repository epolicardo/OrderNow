using System.Linq.Expressions;

namespace Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly DataContext _dataContext;
        private readonly IDateTimeProvider _timeProvider;

        public UsersRepository(DataContext dataContext, IDateTimeProvider dateTimeProvider) : base(dataContext)
        {
            _dataContext = dataContext;
            _timeProvider = dateTimeProvider;
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

        public async Task<IEnumerable<User>> GetAciveUsersAsync()
        {
            return await _dataContext.Users.Where(x => x.Deleted == null).ToListAsync();
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

        public async Task<bool> SetFavoriteBusinessesByUserAsync(string email, string contractURL)
        {
            //given the two received parameters, set the business as favorite for the user, by creating a new relation if not exists in UsersBusinesses table

            if (_dataContext.UsersBusinesses.Where(x => x.User.Email == email).Select(a => a.Business.ContractURL == contractURL).FirstOrDefault())
            {
                //I need to return the relation found on the database to action on that relation
                var relation = await _dataContext.UsersBusinesses.Where(x => x.User.Email == email).Include(x => x.Business).Include(x => x.User).FirstOrDefaultAsync(x => x.Business.ContractURL == contractURL);
            }
            else
            {
                await _dataContext.UsersBusinesses.AddAsync(new UserBusiness
                {
                    Business = await _dataContext.Businesses.FirstOrDefaultAsync(x => x.ContractURL == contractURL),
                    User = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == email),
                    IsFavorite = true,
                    LastVisit = _timeProvider.UtcNow
                });
                return true;
            }
            await _dataContext.SaveChangesAsync();
            return false;
        }

        public async Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email, Guid businessId)
        {
            //When an User visits a Business, this method is called to update the date of the visit.
            //If the user never visited before this business, this should create a new relation between the user and the business.

            //If the user already visited this business, this should update the date of the last visit.

            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            var userBusiness = await _dataContext.UsersBusinesses.Where(x => x.User.Email == email).ToListAsync();

            if (userBusiness.Count == 0)
            {
                var business = await _dataContext.Businesses.FirstOrDefaultAsync(x => x.Id == businessId);
                var userBusinessRelation = new UserBusiness
                {
                    Business = business,
                    User = user,
                    IsFavorite = false,
                    LastVisit = _timeProvider.UtcNow
                };
                await _dataContext.UsersBusinesses.AddAsync(userBusinessRelation);
                await _dataContext.SaveChangesAsync();
                return userBusiness;
            }
            foreach (var item in userBusiness)
            {
                item.LastVisit = DateTime.Now;
            }
            await _dataContext.SaveChangesAsync();
            return userBusiness;
        }
    }
}