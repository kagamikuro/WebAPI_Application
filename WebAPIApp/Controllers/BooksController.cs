using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApp.Models;
//using System.Data.SQLite;

namespace WebAPIApp.Controllers
{
    public class BooksController : ApiController
    {



        static List<Book> books = new List<Book>()
        {
            new Book {Id = 1, Name = "American Dirt", Category = "Fiction",Rate = 4, Price = 125},
            new Book {Id = 2, Name = "The Major of Casterbridge", Category = "Fiction",Rate = 5, Price = 200 },
            new Book {Id = 3, Name = "Douglass", Category = "Fiction",Rate = 3, Price = 150 },
            new Book {Id = 4, Name = "J D ROBB", Category = "Crime",Rate = 5, Price = 230 }
        };


        [HttpGet]
        public IEnumerable<Book> GetAllProducts()
        {
            return books;
        }

        [HttpGet]
        public IHttpActionResult GetProduct([FromUri]int id)
        {
            var product = books.FirstOrDefault((p) => p.Id.Equals(id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public bool Post([FromBody]Book obj)
        {
            int currentMaxId = books.OrderByDescending(t => t.Id).First().Id;
            obj.Id = currentMaxId + 1;
            books.Add(obj);
            return true;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return books.Remove(books.Find(p => p.Id == id));
        }


        [HttpPut]
         public IHttpActionResult PutOne([FromBody]Book model)
         {
            Book editModel = books.Find(p => p.Id == model.Id);
            if (editModel == null)
            {
                return NotFound();
            }
            editModel.Name = model.Name;
            editModel.Category = model.Category;
            editModel.Rate = model.Rate;
            editModel.Price = model.Price;
            return Ok(editModel);
         }

}
}
