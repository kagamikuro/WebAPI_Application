using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPIApp.Models;

namespace WebAPIApp.Dao
{

    public class BooksDao
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tianbai\Desktop\WebAPI_Application\WebAPIApp\mydb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand command = new SqlCommand();

        public bool createBook(Book book)
        {
            string sql = "select MAX(Id) from book";
            command.Connection = connection;
            command.CommandText = sql;

            connection.Open();
            int currentMaxId = (int)command.ExecuteScalar();
            connection.Close();


            book.Id = currentMaxId + 1;
            sql = "insert into book(Id, Name, Type, Rate, Price) values('" + book.Id + "','" + book.Name + "','" + book.Type + "','" + book.Rate + "','" + book.Price + "' )";
            command.Connection = connection;
            command.CommandText = sql;


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        public DataSet queryAllBooks()
        {

            String sql = "select * from book";
            command.Connection = connection;
            command.CommandText = sql;

            connection.Open();
            SqlDataAdapter adp = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            connection.Close();
            return ds;
        }

        public DataSet queryOneBooks(int id)
        {

            String sql = "select * from book where Id= " + id;
            command.Connection = connection;
            command.CommandText = sql;

            connection.Open();
            SqlDataAdapter adp = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            connection.Close();
            return ds;
        }

        

        public bool deleteBook(int id)
        {
            string sql = "delete from book where Id = " + id;
            command.Connection = connection;
            command.CommandText = sql;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        public bool updateBook(Book book)
        {
            string sql = "update book set Name = '" + book.Name + "', Type='" + book.Type + "', Rate=" + book.Rate + ", Price=" + book.Price + "  where Id = " + book.Id;

            command.Connection = connection;
            command.CommandText = sql;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }
    }
}