

namespace Kapow.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? HomeBase { get; set; }
        public string? ImageUrl { get; set; }
        public List<RestaurantDto>? Restaurants { get; set; }

        public Profile(string? userName, string? firstName, string? homeBase, string? imageUrl)
        {
            UserName = userName;
            FirstName = firstName;
            HomeBase = homeBase;
            ImageUrl = imageUrl;
            Restaurants = new List <RestaurantDto>();
        }

        public Profile() { }

        //public override string ToString()
        //{
        //    return UserName;
        //}

        public override bool Equals(object? obj)
        {
            return obj is Profile profile &&
                   Id == profile.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
