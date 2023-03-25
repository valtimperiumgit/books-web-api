using Books.Models.Entities;

namespace Books.Repositories.Interfaces;

public interface IBooksRepository
{
    Task<List<Book?>> GetBooks();

    Task<Book?> GetBook(Guid id);

    Task CreateBook(Book book);

    Task EditBook(Book book);

    Task DeleteBook(Guid id);
}