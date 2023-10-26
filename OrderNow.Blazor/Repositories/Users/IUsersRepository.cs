namespace Repositories
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<bool> SetFavoriteBusinessesByUserAsync(UserBusiness relation);

        Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email);

        Task<User> GetUserDataForLogin(string email);

        Task GetUserProfileData(string email);
    }
}