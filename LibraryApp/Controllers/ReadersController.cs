using LibraryApp.Domain.Core;
using LibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        public readonly IReaderService _readerService;
        public readonly ILogger<ReadersController> _logger;

        public ReadersController(IReaderService readerService, ILogger<ReadersController> logger)
        {
            _readerService = readerService;
            _logger = logger;
        }

        /// <summary>
        /// Get all readers
        /// </summary>
        /// <remarks>Sample request: GET /readers</remarks>
        /// <returns>Returns IEnumerable of readers</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Reader not found</response>
        /// <response code="500">Any exception</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllReaders()
        {
            var response = await _readerService.GetReaders();
            if (response.Result.Succeeded)
            {
                return Ok(response.Readers);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Get reader by ID
        /// </summary>
        /// <remarks>Sample request: GET /readers/{5}</remarks>
        /// <returns>Returns reader object</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Reader not found</response>
        /// <response code="422">Bad ID</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = await _readerService.GetReader(id);
            if (response.Result.Succeeded)
            {
                return Ok(response.Reader);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Create reader by object
        /// </summary>
        /// <remarks>Sample request: POST /readers {"firstname": "vlad","lastname": "ivanov"}</remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect data provided</response>
        /// <response code="500">Any exception</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateReader([FromBody] Reader reader)
        {
            var response = await _readerService.CreateReader(reader);
            if (response.Result.Succeeded)
            {
                _logger.LogWarning($"Created reader: {reader.Lastname}");
                return Ok(response.Id);
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Update reader by another
        /// </summary>
        /// <remarks>Sample request: PUT /readers {"id": 3,"firstname": "vlad","lastname": "ivanov"}</remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect data provided</response>
        /// <response code="404">Reader for updating not found</response>
        /// <response code="500">Any exception</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateReader([FromBody] Reader reader)
        {
            var response = await _readerService.UpdateReader(reader);
            if (response.Result.Succeeded)
            {
                _logger.LogWarning($"Updated reader: ID({reader.Id})");
                return Ok();
            }

            return StatusCode((int)response.Result.Error.Key);
        }

        /// <summary>
        /// Delete reader by ID
        /// </summary>
        /// <remarks>Sample request: DELETE /readers/{6}</remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Incorrect data provided</response>
        /// <response code="404">Reader for deletion not found</response>
        /// <response code="500">Any exception</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteReader(int id)
        {
            var response = await _readerService.DeleteReader(id);
            if (response.Result.Succeeded)
            {
                _logger.LogWarning($"Deleted reader: ({id})");
                return Ok();
            }

            return StatusCode((int)response.Result.Error.Key);
        }
    }
}
