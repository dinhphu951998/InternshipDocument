using ConsoleApplicationDemoNancy.Models;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Research.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Modules
{
    public class ProductModule : NancyModule
    {
        private List<Product> products = null;

        public ProductModule()
        {
            products = ListProducts.GetInstance();

            Get["/products"] = _ =>
            {
                return Response.AsJson(products);
            };

            Get["/products/[productId:even]"] = param =>
            {
                int id = (int)param["productId"];
                var product = products.Where(p => p.Id == id).FirstOrDefault();
                if (product == null)
                {
                    return Response.AsText("Not found");
                }
                return Response.AsJson(product, HttpStatusCode.OK);
            };


            Post["/products"] = _ =>
            {
                Product product = this.Bind<Product>();
                object o = Request;
                products.Add(product);
                return new { message = "Success" };
            };

            

            Delete["/products/{productId:int}"] = param =>
            {
                int id = (int)param["productId"];
                var product = products.Where(p => p.Id == id).FirstOrDefault();
                if (product == null)
                {
                    return Response.AsText("Not found");
                }
                products.Remove(product);

                return new { message = "Success" };
            };
        }

    }
}
