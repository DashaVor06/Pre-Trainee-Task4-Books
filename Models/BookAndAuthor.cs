namespace Books.Models
{
    public class BookAndAuthor
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
