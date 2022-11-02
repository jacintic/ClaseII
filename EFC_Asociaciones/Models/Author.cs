

using System.Text.Json.Serialization;

namespace EFC_Asociaciones.Models;

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
    public decimal Salary { get; set; }

    [Column("birth_date")]
    public DateTime BirthDate { get; set; }
    
    // associations
    // One To One
    public Address Address { get; set; }

    public int? AddressId { get; set; }

    // One To Many
    public List<Book> Books { get; set; }

    // consturctor
    // methods
    // tostring
    public override string ToString()
    {
        return $"Id: {Id}, FullName: {FullName}, Email: {Email}, Salary: {Salary}, Birth Date: {BirthDate} \n Address: {Address}";
    }
}
