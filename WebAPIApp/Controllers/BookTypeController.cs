// <copyright file="BookTypeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebAPIApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebAPIApp.Models;

    /// <summary>
    /// the books Controller for book type.
    /// </summary>
    public class BookTypeController : ApiController
    {
        /// <summary>
        /// get all book types for drop-down box.
        /// </summary>
        /// <returns>IHttpActionResult.</returns>
        [HttpGet]
        public IHttpActionResult GetAllBookTypes()
        {
            return this.Ok(System.Enum.GetNames(typeof(BookType)));
        }
    }
}
