﻿namespace VCC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}
