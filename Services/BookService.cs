using Books.Models;
using Books.Repositories;
using Books.Validators;

namespace Books.Services
{
    public class BookService
    {
        private IRepository<Book> _reposBook = new BookRepository();
        private IRepository<Author> _reposAuthor = new AuthorRepository();

        private BookAndAuthor GetBookAndAuthorClass(Book book, Author author)
        {
            BookAndAuthor bookAndAuthor = new BookAndAuthor();
            bookAndAuthor.Id = book.Id;
            bookAndAuthor.Title = book.Title;
            bookAndAuthor.PublishedYear = book.PublishedYear;
            bookAndAuthor.AuthorId = book.AuthorId;
            bookAndAuthor.Name = author.Name;
            bookAndAuthor.DateOfBirth = author.DateOfBirth;
            return bookAndAuthor;      
        }

        public List<BookAndAuthor> GetAllBooks()
        {
            List<Book> listBooks = _reposBook.GetAll();
            var listBookAndAuthor = new List<BookAndAuthor>();
            Author? author = null;

            foreach (Book book in listBooks) 
            {
                author = _reposAuthor.GetById(book.AuthorId);
                if (author != null)
                {
                    listBookAndAuthor.Add(GetBookAndAuthorClass(book, author));
                }

            }
            return listBookAndAuthor;
        }

        public BookAndAuthor? GetById(int id)
        {
            Book? book = _reposBook.GetById(id);
            if (book != null)
            {
                Author? author = _reposAuthor.GetById(book.AuthorId);
                if (book != null && author != null)
                {
                    return GetBookAndAuthorClass(book, author);
                }
            }
            return null;
        }

        public bool Create(Book book)
        {
            if (BookValidator.CheckBookForCreate(_reposBook.GetAll(), _reposAuthor.GetAll(), book))
            {
                return _reposBook.Create(book);
            }
            return false;    
        }

        public bool Update(Book book)
        {
            if (BookValidator.CheckBookForUpdateDelete(_reposBook.GetAll(), _reposAuthor.GetAll(), book))
            {
                return _reposBook.Update(book);
            }
            return false;
        }

        public bool Delete(int id)
        {
            Book? book = _reposBook.GetById(id);
            if (BookValidator.CheckBookForUpdateDelete(_reposBook.GetAll(), _reposAuthor.GetAll(), book))
            {
                return _reposBook.Delete(id);
            }
            return false;
        }
    }
}
