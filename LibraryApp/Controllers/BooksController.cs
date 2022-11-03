using Microsoft.AspNetCore.Mvc;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Domain.Core;
using LibraryApp.Services.Interfaces;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        UnitOfWork unit;
        public readonly IBookService _bookService;

        public BooksController(DataContext context, IBookService bookService)
        {
            unit = new UnitOfWork(context);
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var response = _bookService.GetBooks();
            if (response.Result.Succeeded)
            {
                return Ok(response.Books);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var response = _bookService.GetBook(id);
            if (response.Result.Succeeded)
            {
                return Ok(response.Book);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult CreateBook([FromBody]Book book)
        {
            var response = _bookService.CreateBook(book);
            if (response.Result.Succeeded)
            {
                return Ok(response.Id);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        // PUT api/<BooksController>/5
        [HttpPut]
        public IActionResult UpdateBook([FromBody]Book book)
        {
            var response = _bookService.UpdateBook(book);
            if (response.Result.Succeeded)
            {
                return Ok();
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var response = _bookService.DeleteBook(id);
            if (response.Result.Succeeded)
            {
                return Ok();
            }

            return StatusCode((int)response.Result.Error.Key);
        }
    }
}
