
namespace EFC_Asociaciones.Repositories;

public interface IAddressRepository
{

    // buscar por Id
    Address FindById(int id);

    
    // obtener todos
    List<Address> FindAll();

    // guardar
    Address Create(Address address);



}
