namespace Kapow.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public Location? Location { get; set; }
        public ICollection<FoodTag>? FoodTags { get; set; }

        public Restaurant(string? name, string? url, Location? location, FoodTag? food)
        {
            Name = name;
            Url = url;
            Location = location;
            FoodTags = new List<FoodTag>();
        }

        public Restaurant() { }

        public override bool Equals(object? obj)
        {
            return obj is Restaurant restaurant &&
                   Id == restaurant.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
