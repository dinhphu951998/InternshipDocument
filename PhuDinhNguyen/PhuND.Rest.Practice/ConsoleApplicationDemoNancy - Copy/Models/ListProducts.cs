using Research.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationDemoNancy.Models
{
    public class ListProducts
    {
        private static List<Product> products = null;

        public static List<Product> GetInstance()
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
