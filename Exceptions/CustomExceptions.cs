namespace Books.Exceptions;

public class CustomExceptions
{
    public class Book
    {
        public static readonly CustomException BookNotFound = new
            (StatusCodes.Status404NotFound, "Book not found.");
    }
}