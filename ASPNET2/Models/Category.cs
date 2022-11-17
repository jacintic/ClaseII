using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace ASPNET2.Models;

[Table("category")]
public class Category
{
    [Key, Column("id",
    Order = 0)]
    public int Id { get; set; }

    [Column("name",
    TypeName = "varchar(100)",
    Order = 1)]
    public string Name { get; set; }

    [Column("min_age",
    TypeName = "int",
    Order = 2)]
    public int MinAge { get; set; }

    [JsonIgnore]
    // association Many To Many with Book
    public IList<Book>? Books { get; set; }

    
}
