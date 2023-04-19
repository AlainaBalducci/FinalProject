namespace Kapow.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public Location? Location { get; set; }
        public FoodTag? Food { get; set; }

        public Restaurant() { }

    }
}
