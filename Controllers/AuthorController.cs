using Microsoft.AspNetCore.Mvc;
using Books.Models;
using Books.Services;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService = new AuthorService();

        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return Ok(_authorService.GetAllAuthors());
        }

        [HttpGet("{id}")]
        public ActionResult<BookAndAuthor> Get(int id)
        {
            Author? author = _authorService.GetById(id);
            if (author != null)
                return Ok(author);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Author author)
        {
            if (_authorService.Create(author))
                return Ok();
            else
                return NotFound();

        }

        [HttpPut]
        public ActionResult Put(Author author)
        {
            if (_authorService.Update(author))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_authorService.Delete(id))
                return Ok();
            else
                return NotFound();
        }
    }
}
