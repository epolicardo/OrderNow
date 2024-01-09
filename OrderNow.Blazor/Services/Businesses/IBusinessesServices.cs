namespace Services
{
    public interface IBusinessesServices : IGenericServices<Business>
    {
        Task<Business> GetBusinessIfActive(string url);

        Task<IEnumerable<UserBusiness>> GetCustomersByBusiness(Guid businessId);

        Task<List<Business>> GetSuggestedBusinessesAsync();
    }
}