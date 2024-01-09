namespace Services
{
    public class BusinessesServices : GenericServices<Business>, IBusinessesServices
    {
        private readonly IBusinessesRepository _businessesRepository;
        private readonly IUsersRepository _usersRepository;

        public BusinessesServices(IBusinessesRepository businessesRepository, IUsersRepository usersRepository) : base(businessesRepository)
        {
            _businessesRepository = businessesRepository;
            _usersRepository = usersRepository;
        }

        /// <summary>
        /// Este metodo valida si un comercio existe.
        /// </summary>
        /// <param name="url">La URL del comercio a validar</param>
        /// <returns>True si el comercio existe</returns>
        public async Task<bool> Exists(string url)
        {
            var t = await _businessesRepository.ExistsAsync(url);
            return t;
        }

        public async Task<Business> GetBusinessIfActive(string url)
        {
            return await _businessesRepository.GetByURL(url);
        }

        public async Task<IEnumerable<UserBusiness>> GetCustomersByBusiness(Guid businessId)
        {
            return await _businessesRepository.GetCustomersByBusiness(businessId);
        }

        public async Task<List<Business>> GetSuggestedBusinessesAsync()
        {
            return await _businessesRepository.GetSuggestedBusinessesAsync();
        }
    }
}