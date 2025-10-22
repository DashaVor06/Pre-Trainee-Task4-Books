using Books.Models;
using Books.Database;

namespace Books.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        public List<Author> GetAll()
        {
            return DatabaseClass.AuthorsTable;
        }
        public Author? GetById(int id)
        {
            foreach (Author author in DatabaseClass.AuthorsTable)
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
            DatabaseClass.AuthorsTable.Add(author);
            return true;
        }
        public bool Update(Author author)
        {
            for (int i = 0; i < DatabaseClass.AuthorsTable.Count; i++)
            {
                if (DatabaseClass.AuthorsTable[i].Id == author.Id)
                {
                    DatabaseClass.AuthorsTable[i] = author;
                    return true; 
                }
            }
            return false;
        }
        public bool Delete(int id)
        {
            for (int i = 0; i < DatabaseClass.AuthorsTable.Count; i++)
            {
                if (DatabaseClass.AuthorsTable[i].Id == id)
                {
                    DatabaseClass.AuthorsTable.Remove(DatabaseClass.AuthorsTable[i]);
                    return true;
                }
            }
            return false;
        }
    }
}
