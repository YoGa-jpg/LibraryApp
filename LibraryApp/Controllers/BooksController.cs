using Microsoft.AspNetCore.Mvc;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Domain.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        UnitOfWork unit;
        public BooksController(DataContext context)
        {
            unit = new UnitOfWork(context);
        }
        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(unit.Books.GetBooks());
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            return Ok(unit.Books.GetBook(id));
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult CreateBook([FromBody]Book book)
        {
            unit.Books.Create(book);
            unit.Save();
            return Ok();
        }

        // PUT api/<BooksController>/5
        [HttpPut]
        public IActionResult UpdateBook([FromBody]Book book)
        {
            unit.Books.Update(book);
            unit.Save();
            return Ok();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            unit.Books.Delete(id);
            unit.Save();
        }
    }
}
