namespace Books.Models.Entities;

public class Book
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime PublicationDate { get; set; }
    
    public string Description { get; set; }
    
    public int NumberPages { get; set; }
}