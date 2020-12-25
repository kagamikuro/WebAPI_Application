using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    public class BookTypeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllBookTypes()
        {
            return Ok(System.Enum.GetNames(typeof(BookType)));
        }
    }
}
