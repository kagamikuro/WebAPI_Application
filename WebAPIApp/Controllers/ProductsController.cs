using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    public class ProductsController : ApiController
    {

        static List<Product> products = new List<Product>()
        {
            new Product { Name = "American Dirt", Category = "Fiction",Rate = 4, Price = 125},
            new Product { Name = "The Major of Casterbridge", Category = "Fiction",Rate = 5, Price = 200 },
            new Product { Name = "Douglass", Category = "Fiction",Rate = 3, Price = 150 },
            new Product { Name = "J.D.ROBB", Category = "Crime",Rate = 5, Price = 230 }
        };


        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            Console.WriteLine("get all products called");
            Product product = new Product();
            products.Add(product);

            return products;
        }

        [HttpGet]
        public IHttpActionResult GetProduct(String name)
        {
            var product = products.FirstOrDefault((p) => p.Name == name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public bool Post([FromBody]Product obj)
        {
            Product product = new Product();
            product.Name = obj.Name;
            product.Category = obj.Category;
            product.Rate = obj.Rate;
            product.Price = obj.Price;
            products.Add(obj);
            Console.WriteLine("add called");
            Console.WriteLine(product);

            return true;
        }

        [HttpDelete]
        public bool Delete(String Name)
        {
            return products.Remove(products.Find(p => p.Name == Name));
        }


        [HttpPut]
         public bool PutOne(Product model)
         {
             Product editModel = products.Find(p => p.Name == model.Name);
             editModel.Name = model.Name;
             editModel.Category = model.Category;
             editModel.Rate = model.Rate;
             editModel.Price = model.Price;
             return true;
         }

}
}
