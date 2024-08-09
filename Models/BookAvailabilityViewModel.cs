namespace library_automation.Models;
public class BookAvailabilityViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public bool IsAvailable { get; set; }
}
