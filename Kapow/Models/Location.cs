namespace Kapow.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Location(string? name)
        {
            Name = name;
        }

        public Location() { }

        public override bool Equals(object? obj)
        {
            return obj is Location location &&
                   Id == location.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
