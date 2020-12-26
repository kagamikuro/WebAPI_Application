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

namespace WebAPIApp.Controllers
{
    public class BooksController : ApiController
    {


        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tianbai\Desktop\WebAPI_Application\WebAPIApp\mydb.mdf;Integrated Security=True;Connect Timeout=30");
        static List<Book> books = new List<Book>();
        SqlCommand command = new SqlCommand();

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            books.Clear();
            
            command.Connection = connection;
            command.CommandText = "select * from book";


            connection.Open();
            SqlDataAdapter adp = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            connection.Close();

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
        public IHttpActionResult GetBook([FromUri]int id)
        {
            var book = books.FirstOrDefault((p) => p.Id.Equals(id));
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public bool Post(Book book)          
        {

            string sql = "select MAX(Id) from book";
            command.Connection = connection;
            command.CommandText = sql;

            connection.Open();
            int currentMaxId = (int)command.ExecuteScalar();
            connection.Close();


            book.Id = currentMaxId+1;
            sql = "insert into book(Id, Name, Type, Rate, Price) values('" + book.Id + "','" + book.Name + "','" + book.Type + "','" + book.Rate + "','" + book.Price + "' )";
            command.Connection = connection;
            command.CommandText = sql;


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            string sql = "delete from book where Id = "+id;
            command.Connection = connection;
            command.CommandText = sql;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }


        [HttpPut]
         public IHttpActionResult PutOne([FromBody]Book book)
         {
            string sql = "update book set Name = '"+book.Name+"', Type='"+book.Type+ "', Rate=" + book.Rate + ", Price=" + book.Price + "  where Id = " + book.Id;

            command.Connection = connection;
            command.CommandText = sql;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();


            return Ok(true);
         }

}
}
