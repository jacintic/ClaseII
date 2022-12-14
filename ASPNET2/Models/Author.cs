

using System.Text.Json.Serialization;

namespace ASPNET2.Models;
[Index(nameof(Email), IsUnique = true)]
[Table("author")]
public class Author
{
    // attr
    [Key, Column("id",
    Order = 0)] // defining table column attributes
    public int Id { get; set; }

    [Column("full_name",
    TypeName = "varchar(100)",
    Order = 2)]
    public string FullName { get; set; }

    [Column("email", TypeName = "varchar(100)", Order = 1)]
    public string Email { get; set; }

    [Column("salary"), Precision(14,2)]
    public decimal? Salary { get; set; }

    [Column("bonus"), Precision(14, 2)]
    public decimal? Bonus { get; set; }

    [Column("birth_date")]
    public DateTime? BirthDate { get; set; }



    // associations
    [JsonIgnore]
    public ICollection<Book>? Books { get; set; }
    [ForeignKey("AddressId")]
    public Address? Address { get; set; }
    public int? AddressId { get; set; }
    // consturctor
    // methods
    // tostring
    public override string ToString()
    {
        return $"Id: {Id}, FullName: {FullName}, Email: {Email}, Salary: {Salary}, Birth Date: {BirthDate}";
    }
}
