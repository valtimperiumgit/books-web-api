using Books.Models.Dto.Book;
using Books.Models.Entities;
using Books.Services;
using Books.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers;
[Route("api/books/")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _booksService.GetBooks();

        return Ok(books);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        var book = await _booksService.GetBook(id);

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDto dto)
    {
        var createdBook = await _booksService.CreateBook(dto);

        return Ok(createdBook);
    }
    
    [HttpPut]
    public async Task<IActionResult> EditBook([FromBody] Book book)
    {
        await _booksService.EditBook(book);

        return Ok(book);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        await _booksService.DeleteBook(id);

        return Ok();
    }
}