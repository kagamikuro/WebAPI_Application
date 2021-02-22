// <copyright file="BooksDaoEF.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace WebAPIApp.Dao
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using WebAPIApp.Models;

    /// <summary>
    /// The books dao with entity framework.
    /// </summary>
    public class BooksDaoEF
    {
        /// <summary>
        /// create a book.
        /// </summary>
        /// <param name="book"> book object. </param>
        /// <returns>true.</returns>
        public book CreateBook(book book)
        {
            BookDBContext entity = new BookDBContext();

            // int currentMaxId = entity.books.Max(b => b.Id);
            // book.Id = currentMaxId + 1;
            entity.books.Add(book);
            entity.SaveChanges();
            return book;
        }

        /// <summary>
        /// select all books.
        /// </summary>
        /// <returns>query results.</returns>
        public IQueryable QueryAllBooks()
        {
            BookDBContext entity = new BookDBContext();
            return entity.books.AsQueryable();
        }

        /// <summary>
        /// select a book.
        /// </summary>
        /// <param name="id"> book id. </param>
        /// <returns>book object.</returns>
        public book QueryOneBooks(int id)
        {
            BookDBContext entity = new BookDBContext();
            return entity.books.Find(id);
        }

        /// <summary>
        /// delete a book.
        /// </summary>
        /// <param name="id"> book id. </param>
        /// <returns>true.</returns>
        public book DeleteBook(int id)
        {
            BookDBContext entity = new BookDBContext();
            book bookToDelete = entity.books.Find(id);
            entity.books.Remove(bookToDelete);
            entity.SaveChanges();
            return bookToDelete;
        }

        /// <summary>
        /// update a book.
        /// </summary>
        /// <param name="book"> book object.</param>
        /// <returns>true.</returns>
        public book UpdateBook(book book)
        {
            BookDBContext entity = new BookDBContext();
            book bookToUpdate = entity.books.Find(book.Id);
            bookToUpdate.Name = book.Name;
            bookToUpdate.Type = book.Type;
            bookToUpdate.Rate = book.Rate;
            bookToUpdate.Price = book.Price;
            entity.SaveChanges();
            return bookToUpdate;
        }
    }
}