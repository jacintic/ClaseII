namespace ASPNET2.Services;

public class AuthorService : IAuthorService
{
    private const decimal BONUS_RATIO = 100.0m;
    private readonly IAuthorRepository _authorRepository;
    private readonly ILogger<AuthorService> _logger;   

    public AuthorService(IAuthorRepository authorRepository, ILogger<AuthorService> logger)
    {
        _authorRepository = authorRepository;
        _logger = logger;   
    }

    public Author Create(Author author)
    {
        return _authorRepository.Create(author);
    }

    public List<Author> FindAll()
    {
        return _authorRepository.FindAll();
    }

    public Author FindByEmail(string email)
    {
        return _authorRepository.FindByEmail(email);
    }

    public List<Author> FindByEmailContains(string email)
    {
        return _authorRepository.FindByEmailContains(email);
    }

    public Author FindById(int id)
    {
        return _authorRepository.FindById(id);
    }

    public Author FindByIdWithInclude(int id)
    {
        return _authorRepository.FindByIdWithInclude(id);
    }

    public List<Author> FindBySalRange(double min, double max)
    {
        if (min > max)
            throw new ArgumentException("min salary is greater than max salary");
        return _authorRepository.FindBySalRange(min, max);
    }

    public string FindNickName(int id)
    {
        return _authorRepository.FindNickName(id);
    }

    public List<Author> FindSalGreaterThan(decimal sal)
    {
        return _authorRepository.FindSalGreaterThan(sal);
    }

    public bool Remove(int id)
    {
        return _authorRepository.Remove(id);
    }

    public Author Update(Author author)
    {
        return _authorRepository.Update(author);
    }

    // CALC
    // asigna un bonus a cada autor en base
    // a sus años de antiguedad
    // 100 € por cada año de antiguedad
    public void CalculateBonus()
    {
        // obtener todos los autores
        List<Author> authors = _authorRepository.FindAll();
        // calcular por cada uno de ellos el bonus
        foreach (Author author in authors)
        {
            if (author.BirthDate != null)
            { 
                author.Bonus = 
                    (DateTime.Now.Year - author.BirthDate.Value.Year) 
                    * BONUS_RATIO;
                Update(author);
            }
        }

        //return _authorRepository.CalculateBonus();
    }

    public AuthorStats CalculateStats()
    {
        List<Author> authors = FindAll();
        decimal totalSalary = 0;
        foreach (Author author in authors)
        {
            if (author.Salary == null || author.Salary == 0)
                continue;
            totalSalary += (decimal)author.Salary;
        }
        decimal avgSalary = totalSalary / authors.Count;

        return new AuthorStats { AvgSalary = avgSalary };
    }

    public List<Author> FindAllByAddressCity()
    {
        //return _authorRepository.FindAllByAddressCity();
        throw new NotImplementedException();
    }

    public bool ExistsById(int id)
    {
        return _authorRepository.ExistsById(id);
    }
}
