namespace Services
{
    public interface IUsersServices : IGenericServices<User>
    {
        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(User user);

        Task<User> GetByIdAsync(Guid Id);

        Task<IEnumerable<User>> GetAll();

        Task<User> GetByMailAsync(string email);

        Task<bool> SetFavoriteBusinessesByUserAsync(UserBusiness business);

        Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email);

        Task<User> GetUserDataForLogin(string email);
    }
}