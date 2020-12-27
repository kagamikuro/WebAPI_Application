using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApp.Models;
using System.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebAPIApp.Dao;

namespace WebAPIApp.Controllers
{
    public class BooksController : ApiController
    {

        BooksDao dao = new BooksDao();           

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            DataSet ds = dao.queryAllBooks();

            foreach (DataRow datarow in ds.Tables[0].Rows)
            {

                Book book = new Book();
                book.Id = (int)datarow[0];
                book.Name = (string)datarow[1];
                book.Type = (string)datarow[2];
                book.Rate = (int)datarow[3];
                book.Price = (decimal)datarow[4];

                books.Add(book);
            }     
             
            return books;
        }

        [HttpGet]
        public IHttpActionResult GetOneBook(int id)
        {
            DataSet ds = dao.queryOneBooks(id);


            Book book = new Book();
            book.Id = (int)ds.Tables[0].Rows[0][0];
            book.Name = (string)ds.Tables[0].Rows[0][1];
            book.Type = (string)ds.Tables[0].Rows[0][2];
            book.Rate = (int)ds.Tables[0].Rows[0][3];
            book.Price = (decimal)ds.Tables[0].Rows[0][4];        

            return Ok(book);
        }

        [HttpPost]
        public IHttpActionResult Post(Book book)          
        {
            return Ok(dao.createBook(book));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(dao.deleteBook(id));
        }


        [HttpPut]
         public IHttpActionResult PutOne([FromBody]Book book)
         {
            return Ok(dao.updateBook(book));
         }

}
}
