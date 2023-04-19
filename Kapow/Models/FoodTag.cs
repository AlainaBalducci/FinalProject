using System.ComponentModel.DataAnnotations;

namespace Kapow.Models
{
    public class FoodTag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string? Name { get; set; }

        public ICollection<Location>? Locations { get; set; }

        public FoodTag(string name)
        {
            Name = name;
            Locations = new List<Location>();
        }

        public FoodTag() { }
    }
}
