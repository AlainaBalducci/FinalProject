﻿namespace Kapow.Models
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
    }
}
