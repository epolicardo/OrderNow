namespace Repositories
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAciveUsersAsync();

        Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email);

        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetUserDataForLogin(string email);

        Task GetUserProfileData(string email);

        Task<bool> SetFavoriteBusinessesByUserAsync(string email, string contractURL);

        Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email, Guid businessId);
    }
}