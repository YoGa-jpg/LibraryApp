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
        public readonly IBookService _bookService;
        public readonly ILogger<BooksController> _logger;

        public BooksController(DataContext context, IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <remarks>Sample request: GET /books</remarks>
        /// <returns>Returns IEnumerable of books</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        /// <response code="500">Any exception</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await _bookService.GetBooks();
            if (response.Result.Succeeded)
            {
                return Ok(response.Books);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Get book by ID
        /// </summary>
        /// <remarks>Sample request: GET /books/{5}</remarks>
        /// <returns>Returns book object</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        /// <response code="422">Bad ID</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = await _bookService.GetBook(id);
            if (response.Result.Succeeded)
            {
                return Ok(response.Book);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Create book by object
        /// </summary>
        /// <remarks>Sample request: POST /books {"title": "книга","author": "автор"}</remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect data provided</response>
        /// <response code="500">Any exception</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBook([FromBody]Book book)
        {
            var response = await _bookService.CreateBook(book);
            if (response.Result.Succeeded)
            {
                _logger.LogWarning($"Created book: {book.Title}");
                return Ok(response.Id);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Update book by another
        /// </summary>
        /// <remarks>Sample request: PUT /books {"id": 5, "title": "книга","author": "автор"}</remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect data provided</response>
        /// <response code="404">Book for updating not found</response>
        /// <response code="500">Any exception</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBook([FromBody]Book book)
        {
            var response = await _bookService.UpdateBook(book);
            if (response.Result.Succeeded)
            {
                _logger.LogWarning($"Updated book: ID({book.Id})");
                return Ok();
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Delete book by ID
        /// </summary>
        /// <remarks>Sample request: DELETE /books/{6}</remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect data provided</response>
        /// <response code="404">Book for deletion not found</response>
        /// <response code="500">Any exception</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBook(id);
            if (response.Result.Succeeded)
            {
                _logger.LogWarning($"Deleted book: ({id})");
                return Ok();
            }

            return StatusCode((int)response.Result.Error.Key);
        }
    }
}
