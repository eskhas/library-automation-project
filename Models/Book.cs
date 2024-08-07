namespace library_automation.Models;

public class Book
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
    public required string Title { get; set; }
    public string Publisher { get; set; } = "";
    public DateTime PublicationYear { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    public required string Genre { get; set; }
    public Loan? Loan { get; set; }
}