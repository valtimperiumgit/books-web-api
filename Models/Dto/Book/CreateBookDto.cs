namespace Books.Models.Dto.Book;

public class CreateBookDto
{
    public string Name { get; set; }
    
    public DateTime PublicationDate { get; set; }
    
    public string Description { get; set; }
    
    public int NumberPages { get; set; }
}