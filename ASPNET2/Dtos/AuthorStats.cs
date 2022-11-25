namespace ASPNET2.Dtos;

public class AuthorStats
{
    public int? TotalAuthros { get; set; }
    public decimal? MaxSalary { get; set; }
    public decimal? AvgSalary { get; set; }
    public decimal? MinSalary { get; set; }  
    public decimal? AvgBonus { get; set; }
    public string? MostFrequentCity { get; set; }
}
