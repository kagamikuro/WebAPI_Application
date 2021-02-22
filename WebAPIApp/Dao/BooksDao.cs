// <copyright file="BooksDao.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebAPIApp.Dao
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using WebAPIApp.Models;

    /// <summary>
    /// The books dao.
    /// </summary>
    public class BooksDao
    {
        // sql connection String
        private readonly SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=mydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private readonly SqlCommand command = new SqlCommand();

        /// <summary>
        /// create a book.
        /// </summary>
        /// <param name="book"> book object. </param>
        /// <returns>true.</returns>
        public bool CreateBook(book book)
        {
            string sql = "select MAX(Id) from book";
            this.command.Connection = this.connection;
            this.command.CommandText = sql;

            this.connection.Open();
            int currentMaxId = (int)this.command.ExecuteScalar();
            this.connection.Close();

            book.Id = currentMaxId + 1;
            sql = "insert into book(Id, Name, Type, Rate, Price) values('" + book.Id + "','" + book.Name + "','" + book.Type + "','" + book.Rate + "','" + book.Price + "' )";
            this.command.Connection = this.connection;
            this.command.CommandText = sql;

            this.connection.Open();
            this.command.ExecuteNonQuery();
            this.connection.Close();

            return true;
        }

        /// <summary>
        /// select all book.
        /// </summary>
        /// <returns>true.</returns>
        public DataSet QueryAllBooks()
        {
            string sql = "select * from book";
            this.command.Connection = this.connection;
            this.command.CommandText = sql;

            this.connection.Open();
            SqlDataAdapter adp = new SqlDataAdapter(this.command);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            this.connection.Close();
            return ds;
        }

        /// <summary>
        /// query one book.
        /// </summary>
        /// <param name="id"> book id. </param>
        /// <returns>the dataset.</returns>
        public DataSet QueryOneBooks(int id)
        {
            string sql = "select * from book where Id= " + id;
            this.command.Connection = this.connection;
            this.command.CommandText = sql;

            this.connection.Open();
            SqlDataAdapter adp = new SqlDataAdapter(this.command);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            this.connection.Close();
            return ds;
        }

        /// <summary>
        /// delete one book.
        /// </summary>
        /// <param name="id"> book id. </param>
        /// <returns>the dataset.</returns>
        public bool DeleteBook(int id)
        {
            string sql = "delete from book where Id = " + id;
            this.command.Connection = this.connection;
            this.command.CommandText = sql;

            this.connection.Open();
            this.command.ExecuteNonQuery();
            this.connection.Close();

            return true;
        }

        /// <summary>
        /// update one book.
        /// </summary>
        /// <param name="book"> book object. </param>
        /// <returns>the dataset.</returns>
        public bool UpdateBook(book book)
        {
            string sql = "update book set Name = '" + book.Name + "', Type='" + book.Type + "', Rate=" + book.Rate + ", Price=" + book.Price + "  where Id = " + book.Id;

            this.command.Connection = this.connection;
            this.command.CommandText = sql;

            this.connection.Open();
            this.command.ExecuteNonQuery();
            this.connection.Close();

            return true;
        }
    }
}