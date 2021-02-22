// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebAPIApp.Controllers
{
    using System.Web.Http;
    using WebAPIApp.Dao;
    using WebAPIApp.Models;

    /// <summary>
    /// the books Controller for web api.
    /// </summary>
    public class BooksController : ApiController
    {
        // initialize book DAO
        // BooksDao dao = new BooksDao();
        private readonly BooksDaoEF daoEF = new BooksDaoEF();

        /// <summary>
        /// get all book information.
        /// </summary>
        /// <returns>IHttpActionResult.</returns>
        [HttpGet]
        public IHttpActionResult GetAllBooks()
        {
            /*
            List<Book2> books = new List<Book2>();
            DataSet ds = dao.queryAllBooks();

            foreach (DataRow datarow in ds.Tables[0].Rows)
            {

                Book2 book = new Book2();
                book.Id = (int)datarow[0];
                book.Name = (string)datarow[1];
                book.Type = (string)datarow[2];
                book.Rate = (int)datarow[3];
                book.Price = (decimal)datarow[4];

                books.Add(book);
            }
            */

            return this.Ok(this.daoEF.QueryAllBooks());
        }

        /// <summary>
        /// get one book imformation.
        /// </summary>
        /// <param name="id"> book id. </param>
        /// <returns>IHttpActionResult.</returns>
        [HttpGet]
        public IHttpActionResult GetOneBook(int id)
        {
            /*
            DataSet ds = dao.queryOneBooks(id);

            Models.book book = new Models.book();
            book.Id = (int)ds.Tables[0].Rows[0][0];
            book.Name = (string)ds.Tables[0].Rows[0][1];
            book.Type = (string)ds.Tables[0].Rows[0][2];
            book.Rate = (int)ds.Tables[0].Rows[0][3];
            book.Price = (decimal)ds.Tables[0].Rows[0][4];
            return Ok(book);
            */
            return this.Ok(this.daoEF.QueryOneBooks(id));
        }

        /// <summary>
        /// add a book.
        /// </summary>
        /// <param name="book"> book object. </param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] book book)
        {
            return this.Ok(this.daoEF.CreateBook(book));
        }

        /// <summary>
        /// delete a book.
        /// </summary>
        /// <param name="id"> book id. </param>
        /// <returns>IHttpActionResult.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return this.Ok(this.daoEF.DeleteBook(id));
        }

        /// <summary>
        /// edit a book.
        /// </summary>
        /// <param name="book"> book object. </param>
        /// <returns>IHttpActionResult.</returns>
        [HttpPut]
        public IHttpActionResult PutOne([FromBody] book book)
        {
            // return Ok(dao.updateBook(Models.book));
            return this.Ok(this.daoEF.UpdateBook(book));
        }
    }
}
