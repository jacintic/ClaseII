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

    List<Author> FindSalGreaterThan(decimal sal);


}
