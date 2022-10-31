using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet1.Repositories;

public interface IAuthorRepository
{
    Author FindById(int id);

    List<Author> FindAll();

    Author FindByEmail(string email);

    List<Author> FindByEmailContains(string email);

    List<Author> FindSalGreaterThan(decimal sal);

    Author Create(Author author);

    Author Update(Author author);

    bool Remove(int id);


}
