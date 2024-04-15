using BooksProject.API.Models;
using BooksProject.API.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BooksProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            if(books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllBookByBookId([FromRoute] int id)
        {
            var book = await _bookRepository.GetAllBooksByIDAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewBooks([FromBody]BookModel bookModel)
        {
            var id = await _bookRepository.AddbooksAsync(bookModel);
            return CreatedAtAction(nameof(GetAllBookByBookId), new { id = id, controller = "books" }, id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooks([FromBody] BookModel bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookAsync(id, bookModel);
            return Ok();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUpdateBooks([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBooksPatch(id, bookModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooksRecord([FromRoute] int id)
        {
            await _bookRepository.DeleteBooksRecord(id);
            return Ok();
        }


    }
}
