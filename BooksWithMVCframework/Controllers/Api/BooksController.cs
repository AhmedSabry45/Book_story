using BooksWithMVCframework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksWithMVCframework.Controllers.Api
{
    public class BooksController : ApiController
    {
        private readonly AppDbContext _context;

        public BooksController()
        {
            _context = new AppDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return NotFound();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

    }
}
