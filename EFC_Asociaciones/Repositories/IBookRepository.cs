
namespace EFC_Asociaciones.Repositories;

public interface IBookRepository
{

    // buscar por Id
    Book FindById(int id);

    // buscar por Id incluyendo asociaciones: Author y Categories
    Book FindByIdWithAssociations(int id);

    // buscar por otro titulo que incluya el termino de busqueda
    List<Book> FindByTitleContains(string title);

    // buscar por precio menor que
    List<Book> FindByPriceLowerThan(double price);

    // buscar libros por ID de author
    List<Book> FindByAuthorId(int id);

    // obtener todos
    List<Book> FindAll();

    // guardar
    Book Create(Book book);

    // actualizar restringiendo campos
    Book Update(Book book);

    // borrar
    bool Delete(int id); 


}
