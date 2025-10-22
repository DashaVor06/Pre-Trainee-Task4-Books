using Books.Database;
using Books.Models;

namespace Books.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private DatabaseClass _database = new DatabaseClass();
        public List<Book> GetAll()
        {
            return _database.BooksTable;
        }
        public Book? GetById(int id)
        {
            foreach (Book book in _database.BooksTable)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }
        public bool Create(Book book)
        {
            _database.BooksTable.Add(book);
            return true;
        }
        public bool Update(Book book)
        {
            for (int i = 0; i < _database.BooksTable.Count; i++)
            {
                if (_database.BooksTable[i].Id == book.Id)
                {
                    _database.BooksTable[i] = book;
                    return true;
                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            for (int i = 0; i < _database.BooksTable.Count; i++)
            {
                if (_database.BooksTable[i].Id == id)
                {
                    _database.BooksTable.Remove(_database.BooksTable[i]);
                    return true;
                }
            }
            return false;
        }
    }
}
