namespace ASPNET2.Services;

public class AuthorService : IAuthorService
{
    

    public Author Create(Author author)
    {
        throw new NotImplementedException();
    }

    public List<Author> FindAll()
    {
        throw new NotImplementedException();
    }

    public Author FindByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public List<Author> FindByEmailContains(string email)
    {
        throw new NotImplementedException();
    }

    public Author FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Author FindByIdWithInclude(int id)
    {
        throw new NotImplementedException();
    }

    public List<Author> FindBySalRange(double min, double max)
    {
        throw new NotImplementedException();
    }

    public string FindNickName(int id)
    {
        throw new NotImplementedException();
    }

    public List<Author> FindSalGreaterThan(decimal sal)
    {
        throw new NotImplementedException();
    }

    public bool Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Author Update(Author author)
    {
        throw new NotImplementedException();
    }

    // CALC
    public void CalculateBonus()
    {
        throw new NotImplementedException();
    }

    public AuthorStats CalculateStats()
    {
        throw new NotImplementedException();
    }

    public List<Author> FindAllByAddressCity()
    {
        throw new NotImplementedException();
    }
}
