namespace Services
{
    public interface IUsersServices : IGenericServices<User>
    {
        Task<bool> DeleteUser(User user);

        Task<IEnumerable<User>> GetActiveUsersAsync();

        Task<IEnumerable<User>> GetAll();

        Task<User> GetByIdAsync(Guid Id);

        Task<User> GetByMailAsync(string email);

        Task<List<UserBusiness>> GetFavoriteBusinessesByUserAsync(string email);

        Task<List<UserBusiness>> GetLastVisitedBusinessesByUserAsync(string email);

        Task<User> GetUserDataForLogin(string email);

        Task<bool> SetFavoriteBusinessesByUserAsync(string email, string contractURL);

        Task<List<UserBusiness>> UpdateDateOfVisitToBusinessesByUserAsync(string email, Guid businessId);

        Task<bool> UpdateUser(User user);
    }
}