

namespace Kapow.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? HomeBase { get; set; }
        public string? ImageUrl { get; set; }
        public string? Restaurant1 { get; set; }
        public string? Restaurant2 { get; set; }
        public string? Restaurant3 { get; set; }
        public string? Restaurant4 { get; set; }
        public string? Restaurant5 { get; set; }



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

        public List<string> MakeRestaurantList()
        {
            List<string> list = new List<string>();
            list.Add(Restaurant1);
            list.Add(Restaurant2);
            list.Add(Restaurant3);
            list.Add(Restaurant4);
            list.Add(Restaurant5);
            return list;
        }
    }
}
