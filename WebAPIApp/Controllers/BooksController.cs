using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    public class BooksController : ApiController
    {

        static List<Book> books = new List<Book>()
        {
            new Book { Name = "American Dirt", Category = "Fiction",Rate = 4, Price = 125},
            new Book { Name = "The Major of Casterbridge", Category = "Fiction",Rate = 5, Price = 200 },
            new Book { Name = "Douglass", Category = "Fiction",Rate = 3, Price = 150 },
            new Book { Name = "J.D.ROBB", Category = "Crime",Rate = 5, Price = 230 }
        };


        [HttpGet]
        public IEnumerable<Book> GetAllProducts()
        {
            return books;
        }

        [HttpGet]
        public IHttpActionResult GetProduct([FromUri]String id)
        {
            var product = books.FirstOrDefault((p) => p.Name.Equals(id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
            //return NotFound();
        }

        [HttpPost]
        public bool Post([FromBody]Book obj)
        {
            books.Add(obj);
            return true;
        }

        [HttpDelete]
        public bool Delete(String id)
        {
            return books.Remove(books.Find(p => p.Name == id));
        }


        [HttpPut]
         public bool PutOne([FromBody]Book model)
         {
             Book editModel = books.Find(p => p.Name == model.Name);
             if (editModel == null)
             {
                return false;
             }
            editModel.Name = model.Name;
             editModel.Category = model.Category;
             editModel.Rate = model.Rate;
             editModel.Price = model.Price;
             return true;
         }

}
}
