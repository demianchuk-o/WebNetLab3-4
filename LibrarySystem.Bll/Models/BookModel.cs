using LibrarySystem.Bll.Models.Abstract;

namespace LibrarySystem.Bll.Models;

public class BookModel : IModel
{
    public Guid Id { get; init; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Subject { get; set; }
    public bool Availability { get; set; } = true;
    
    public bool IsAvailable() => Availability;
}