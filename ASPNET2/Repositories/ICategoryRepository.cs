

namespace ASPNET2.Repositories
{
    public interface ICategoryRepository
    {

        // buscar por Id
        Category FindById(int id);


        // obtener todos
        List<Category> FindAll();

        // guardar
        Category Create(Category category);
    }
}
