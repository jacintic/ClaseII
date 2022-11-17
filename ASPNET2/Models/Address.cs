using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET2.Models;

[Table("address")]
public class Address
{

    // attr
    [Key, Column("id",
    Order = 0)]
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }


    // associations

    [JsonIgnore]
    [InverseProperty("Address")]
    public Author? Author { get; set; }

    // FK
    // constructor

    // ToString
    public override string ToString()
    {
        return $"Id: {Id}, Street: {Street}, City: {City}";
    }
}
