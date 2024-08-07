namespace library_automation.Models
{
    public class BookAuthorViewModel
    {
        public Book Book { get; set; } = new Book { Title = "", Genre = "" };
        public Author Author { get; set; } = new Author { FirstName = "" };
    }
}
