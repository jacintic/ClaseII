namespace ASPNET2.Models;

[Table("book")]
public class Book
{
    // attr
    [Key, Column("id")] // defining table column attributes
    public int Id { get; set; }

    [Required(ErrorMessage = "Title required"),
    Column("title"),
    MinLength(3), 
    MaxLength(50, ErrorMessage ="Title too long (50-)")]
    public string Title { get; set; }

    [Required,
    Column("isbn"),
    MinLength(5),
    MaxLength(7, ErrorMessage = "Title too long (50-)")]
    public string Isbn { get; set; }

    
    [Required,
    Column("release_year")]
    public int ReleaseYear { get; set; }

    [Column("description")]
    public string Description { get; set; }
    // associations

    public IList<Category>? Categories { get; set; }

    public Author? Author { get; set; }
    public int? AuthorId { get; set; }
    // consturctor
    // methods
    // tostring
    public override string ToString()
    {
        return $"Id: {Id}, Isbn:{Isbn}, Title: {Title}, Release year: {ReleaseYear}, Description: {Description}";
    }
}
