namespace Task.Data.Entities;

public class Book : BaseEntity<int>
{
    public string BookName { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public int AuthorId { get; set; }

    public Author? Author { get; set; }
}
