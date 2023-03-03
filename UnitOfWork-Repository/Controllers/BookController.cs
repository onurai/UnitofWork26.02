using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Repository;
using Task.Services.Interface;
using Task.Data.Entities;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book, int> _bookService;
        private readonly IRepository<Author, int> _authorService;


        public BookController(IRepository<Book, int> bookService, IRepository<Author, int> authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _bookService.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(string bookName, decimal price, string category, int authorId)
        {
            await _bookService.Add(new Book
            {
                BookName = bookName,
                Price = price,
                Category = category,
                AuthorId = authorId
            });
            await _bookService.Commit();

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, string bookName, decimal price, string category, int AuthorId)
        {

            await _bookService.Update(new Book
            {
                Id = id,
                BookName = bookName,
                Price = price,
                Category = category,
                AuthorId = AuthorId
            });
            await _bookService.Commit();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var book = await _bookService.Find(id);
            await _bookService.Delete(book);
            await _bookService.Commit();
            return Ok(book);
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetId(int id)
        {
            var result = await _bookService.Find(id);
            return Ok(result);
        }
    }
}

