using Microsoft.AspNetCore.Identity;

namespace OrderNow.Common.Data.Entities
{
    public enum UserType
    {
        Administrator,
        Manager,
        Colaborator,
        User
    }

    public class User : IdentityUser
    {
        public Business? AssosiatedBusiness { get; set; }

        public DateTime? Deleted { get; set; } = null;
        public IList<Business>? FavoriteBusiness { get; set; }
        public IList<Product>? FavoriteProducts { get; set; }

        [NotMapped]
        public string Password { get; set; }

        public Person? Person { get; set; }
        public UserType? UserType { get; set; }
    }
}