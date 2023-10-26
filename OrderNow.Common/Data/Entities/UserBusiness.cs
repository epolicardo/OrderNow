namespace OrderNow.Common.Data.Entities
{
    public class UserBusiness : EntityBase
    {
        public User User { get; set; }
        public Business Business { get; set; }
        public DateTime LastVisit { get; set; }
        public bool IsFavorite { get; set; }
    }

    public class FavoriteProducts : EntityBase
    {
        public Product Product { get; set; }
        public User User { get; set; }
        public DateTime Added { get; set; } = DateTime.Now;
    }
}