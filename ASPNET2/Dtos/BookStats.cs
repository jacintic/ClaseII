

namespace ASPNET2.Dtos;

public class BookStats
{
    public int? TotalBooks { get; set; } 
    public decimal? MaxPrice { get; set; } 
    public decimal? AvgPrice { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? AvgBooksByAuthor { get; set; }

}
