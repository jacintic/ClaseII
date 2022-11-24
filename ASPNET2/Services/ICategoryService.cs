namespace ASPNET2.Services;

public interface ICategoryService
{
    // buscar por Id
    Category FindById(int id);


    // obtener todos
    List<Category> FindAll();
    List<Category> FindAllByIdIn(List<int> ids);

    // guardar
    Category Create(Category category);

    Category Update(Category category);

    // CALC
    CategoryStats CalculateStats();
}
