using Books.Models;
using Books.Repositories;
using Books.Validators;

namespace Books.Services
{
    public class AuthorService
    {
        private IRepository<Author> _reposAuthor = new AuthorRepository();
        private IRepository<Book> _reposBook = new BookRepository();
        public List<Author> GetAllAuthors()
        {
            return _reposAuthor.GetAll();
        }
        public Author? GetById(int id)
        {
            return _reposAuthor.GetById(id);
        }
        public bool Create(Author author)
        {
            if (AuthorValidator.CheckAuthorForCreate(_reposAuthor.GetAll(), author))
            {
                return _reposAuthor.Create(author);
            }
            return false;
        }

        public bool Update(Author author)
        {
            if (AuthorValidator.CheckAuthorForUpdateDelete(_reposAuthor.GetAll(), author))
            {
                return _reposAuthor.Update(author);
            }
            return false;
        }
        
        public bool Delete(int id)
        {
            Author? author = _reposAuthor.GetById(id);
            if (AuthorValidator.CheckAuthorForUpdateDelete(_reposAuthor.GetAll(), author))
            {
                if (_reposAuthor.Delete(id))
                {
                    foreach (Book book in _reposBook.GetAll().ToList())
                    {
                        if (book.AuthorId == id)
                        {
                            _reposBook.Delete(book.Id);
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
