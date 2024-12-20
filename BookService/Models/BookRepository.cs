using BookService.Models;

namespace BookService.Repositories;

public class BookRepository
{
    private readonly List<Book> _books = new()
    {
        new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
        new Book { Id = 2, Title = "Brave New World", Author = "Aldous Huxley", Year = 1932 }
    };

    public IEnumerable<Book> GetAll() => _books;

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book)
    {
        book.Id = _books.Max(b => b.Id) + 1;
        _books.Add(book);
    }

    public void Update(Book book)
    {
        var existing = GetById(book.Id);
        if (existing != null)
        {
            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Year = book.Year;
        }
    }

    public void Delete(int id) => _books.RemoveAll(b => b.Id == id);
}