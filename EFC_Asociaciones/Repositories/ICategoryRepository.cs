using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Asociaciones.Repositories
{
    internal interface ICategoryRepository
    {

        // buscar por Id
        Category FindById(int id);


        // obtener todos
        List<Category> FindAll();

        // guardar
        Category Create(Category category);
    }
}
