
namespace DotNet1.Models;

public class Book
{
    // attr
    [Key] // defining table column attributes
    public int Id { get; set; }

    public string Title { get; set; }
    public string Isbn { get; set; }
    // associations
    // consturctor
    // methods
    // tostring
}
