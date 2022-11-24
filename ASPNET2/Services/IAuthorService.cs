namespace ASPNET2.Services;

public interface IAuthorService
{

    Author FindById(int id);

    Author FindByIdWithInclude(int id);

    List<Author> FindAll();

    Author FindByEmail(string email);

    string FindNickName(int id);

    List<Author> FindByEmailContains(string email);

    List<Author> FindSalGreaterThan(decimal sal);

    List<Author> FindBySalRange(double min, double max);

    Author Create(Author author);

    Author Update(Author author);

    bool Remove(int id);

    // CALC
    AuthorStats CalculateStats();
    void CalculateBonus();
    List<Author> FindAllByAddressCity();
    
}
