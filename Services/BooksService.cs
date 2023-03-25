using Books.Exceptions;
using Books.Models.Dto.Book;
using Books.Models.Entities;
using Books.Repositories.Interfaces;
using Books.Services.Interfaces;

namespace Books.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<List<Book?>> GetBooks()
    {
        return await _booksRepository.GetBooks();
    }

    public async Task<Book> GetBook(Guid id)
    {
        var book = await _booksRepository.GetBook(id);

        if (book == null)
            throw CustomExceptions.Book.BookNotFound;

        return book;
    }

    public async Task<Book> CreateBook(CreateBookDto dto)
    {
        Book book = new Book
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            PublicationDate = dto.PublicationDate,
            NumberPages = dto.NumberPages
        };

        await _booksRepository.CreateBook(book);

        return book;
    }

    public async Task EditBook(Book book)
    {
        var existingBook = await GetBook(book.Id);

        if (existingBook == null)
            throw CustomExceptions.Book.BookNotFound;

        await _booksRepository.EditBook(book);
    }

    public async Task DeleteBook(Guid id)
    {
        var existingBook = await GetBook(id);

        if (existingBook == null)
            throw CustomExceptions.Book.BookNotFound;

        await _booksRepository.DeleteBook(id);
    }
}