using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET2.Repositories;

public interface IAuthorRepository
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


}
