using Nancy;
using Nancy.ModelBinding;
using Research.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Modules
{
    public class ProductModule : NancyModule
    {
        private List<Product> products = null;

        public ProductModule()
        {
            products = Product.GetProducts();

            Get["/products"] = param =>
            {
                int? index = Request.Query["index"];
                int? size = Request.Query["size"];

                IEnumerable<Product> result = products;
                if (index != null && size != null)
                {
                    result = result.OrderBy(p => p.Id)
                                        .Skip(index.Value * size.Value)
                                        .Take(size.Value);
                }
                return Response.AsJson(result);
            };

            Get["/products/{productId:int}"] = param =>
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
                var entity = products.Where(p => p.Id == product.Id).FirstOrDefault();
                if (entity != null)
                {
                    var res = new { mesasge = "Fail" };
                    return Response.AsJson(res, HttpStatusCode.BadRequest);
                }
                products.Add(product);

                return Response.AsJson(new { message = "Success" })
                               .WithHeader("Location", "/products/" + product.Id);
            };


            Put["/products"] = param =>
            {
                Product productParam = this.Bind<Product>();
                Product product = products.Where(p => p.Id == productParam.Id).FirstOrDefault();
                if (product != null)
                {
                    product.Name = productParam.Name;
                    product.Price = productParam.Price;
                    return new { message = "Success" };
                }
                return Response.AsJson(new { message = "Not found" }, HttpStatusCode.NotFound);
            };


            Delete["/products/{productId:int}"] = param =>
            {
                int id = (int)param["productId"];
                var product = products.Where(p => p.Id == id).FirstOrDefault();
                if (product == null)
                {
                    return Response.AsJson(new { message = "Not found" }, HttpStatusCode.NotFound);
                }
                products.Remove(product);

                return new { message = "Success" };
            };
        }

    }
}
