﻿namespace library_automation.Models;

public class Author
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
    public List<Book> Books { get; set; } = [];
}
