using Books.Database;
using Books.Models;

namespace Books.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        public List<Book> GetAll()
        {
            return DatabaseClass.BooksTable;
        }
        public Book? GetById(int id)
        {
            foreach (Book book in DatabaseClass.BooksTable)
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
            DatabaseClass.BooksTable.Add(book);
            return true;
        }
        public bool Update(Book book)
        {   
            for (int i = 0; i < DatabaseClass.BooksTable.Count; i++)
            {
                if (DatabaseClass.BooksTable[i].Id == book.Id)
                {
                    DatabaseClass.BooksTable[i] = book;
                    return true;
                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            for (int i = 0; i < DatabaseClass.BooksTable.Count; i++)
            {
                if (DatabaseClass.BooksTable[i].Id == id)
                {
                    DatabaseClass.BooksTable.Remove(DatabaseClass.BooksTable[i]);
                    return true;
                }
            }
            return false;
        }
    }
}
