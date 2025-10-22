using Books.Models;
using Books.Database;

namespace Books.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private DatabaseClass _database = new DatabaseClass();
        public List<Author> GetAll()
        {
            return _database.AuthorsTable;
        }
        public Author? GetById(int id)
        {
            foreach (Author author in _database.AuthorsTable)
            {
                if (author.Id == id)
                {
                    return author;
                }
            }
            return null;
        }
        public bool Create(Author author)
        {
            _database.AuthorsTable.Add(author);
            return true;
        }
        public bool Update(Author author)
        {
            for (int i = 0; i < _database.AuthorsTable.Count; i++)
            {
                if (_database.AuthorsTable[i].Id == author.Id)
                {
                    _database.AuthorsTable[i] = author;
                    return true; 
                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            for (int i = 0; i < _database.AuthorsTable.Count; i++)
            {
                if (_database.AuthorsTable[i].Id == id)
                {
                    _database.AuthorsTable.Remove(_database.AuthorsTable[i]);
                    return true;
                }
            }
            return false;
        }
    }
}
