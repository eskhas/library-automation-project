namespace library_automation.Models;

public class Member
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Email { get; set; } = "";
    public required string Phone { get; set; }
    public string Address { get; set; } = "";
    public List<Loan>? Loans { get; set; }
}
