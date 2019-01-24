using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Research.Models
{
    public class Product
    {
        public Product(int id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Product()
        {

        }

        public int Id { get; set; }
        public string  Name { get; set; }
        public float Price { get; set; }

    }
}