using Books.Data.EFCore;
using Books.Models.Entities;
using Books.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly AppDbContext _dbContext;

    public BooksRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _dbContext.Books.AsNoTracking().ToListAsync();
    }

    public async Task<Book?> GetBook(Guid id)
    {
        return await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(book => book.Id == id);
    }

    public async Task CreateBook(Book book)
    {
        await _dbContext.Books.AddAsync(book);

        await _dbContext.SaveChangesAsync();
    }

    public async Task EditBook(Book book)
    {
        var existingBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == book.Id);

        _dbContext.Entry(existingBook).CurrentValues.SetValues(book);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteBook(Guid id)
    {
        var existingBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

        _dbContext.Books.Remove(existingBook);

        await _dbContext.SaveChangesAsync();
    }
}