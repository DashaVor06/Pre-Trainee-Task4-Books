using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService = new BookService();

        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        public ActionResult<BookAndAuthor> Get(int id)
        {
            BookAndAuthor? book = _bookService.GetById(id);
            if (book != null)
                return Ok(book);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Book book)
        {
            if (_bookService.Create(book))
                return Ok();
            else
                return NotFound();
            
        }

        [HttpPut]
        public ActionResult Put(Book book)
        {
            if (_bookService.Update(book))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_bookService.Delete(id))
                return Ok();
            else
                return NotFound();
        }
    }
}
