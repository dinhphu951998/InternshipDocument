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


        private static List<Product> products = null;

        public static List<Product> GetProducts()
        {
            if (products == null)
            {
                products = new List<Product>();

                products.Add(new Product(1, "Suzuki", 10));
                products.Add(new Product(2, "Honda", 20));
                products.Add(new Product(3, "Yamaha", 30));
                products.Add(new Product(4, "Winner", 40));
                products.Add(new Product(5, "Exciter", 450));
            }
            return products;
        }

    }
}