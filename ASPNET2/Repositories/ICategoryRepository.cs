

namespace ASPNET2.Repositories
{
    public interface ICategoryRepository
    {

        // buscar por Id
        Category FindById(int id);


        // obtener todos
        List<Category> FindAll();
        List<Category> FindAllByIdIn(List<int> ids);

        // guardar
        Category Create(Category category);

        Category Update(Category category);
    }
}
