

namespace Kapow.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        //public string? Email { get; set; }
        public string? Location { get; set; }
        public List<Restaurant>? Restaurants { get; set; }
        public ICollection<FoodTag>? FoodTags { get; set; }

        public Profile(int id, string? userName, string? firstName, string? location)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            //Email = email;
            Location = location;
            Restaurants = new List <Restaurant>();
            FoodTags = new List<FoodTag>();
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
