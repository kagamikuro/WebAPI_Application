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


        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=mydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

            foreach (DataRow datarow in ds.Tables[0].Rows)
            {

                var Id = datarow[0];
                var Name = datarow[1];
                var Type = datarow[2];
                var Rate = datarow[3];
                var Price = datarow[4];

                Book book = new Book((int)Id, (string)Name, (string)Type, (int)Rate, (decimal)Price);

                Console.WriteLine(book);
                books.Add(book);

            }
            connection.Close();
             
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
        public bool Post([FromBody] int Id, string Name, String Type, int Rate, decimal Price)
            
        {
            //int currentMaxId = books.OrderByDescending(t => t.Id).First().Id;
            //obj.Id = currentMaxId + 1;
            string sql = "insert into book(Id, Name, Type, Rate, Price) values('" + Id + "','" + Name + "','" + Type + "','" + Rate + "','" + Price + "' )";
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
            editModel.Type = model.Type;
            editModel.Rate = model.Rate;
            editModel.Price = model.Price;

            

            return Ok(editModel);
         }

}
}
