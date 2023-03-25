using Books.Models.Dto.Book;
using Books.Models.Entities;

namespace Books.Services.Interfaces;

public interface IBooksService
{
    Task<List<Book?>> GetBooks();

    Task<Book> GetBook(Guid id);

    Task<Book> CreateBook(CreateBookDto dto);

    Task EditBook(Book book);

    Task DeleteBook(Guid id);
}