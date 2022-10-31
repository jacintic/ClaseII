using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Asociaciones.Models;

[Table("addresses")]
public class Address
{
    // attr
    [Key, Column("id",
    Order = 0)] // defining table column attributes
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }    
}
