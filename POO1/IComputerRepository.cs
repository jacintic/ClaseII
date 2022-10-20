using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public interface IComputerRepository
{
    // get all computers
    List<Computer> FindAll();
    Computer FindOneById(int Id);

    // comprobar si existe por id (bool)
    bool ExistsById(int Id);

    // recuperar varios por ids
    List<Computer> GetByIds(int[] Ids);

    // recuperar por  minimo y maximo de Ram
    List<Computer> FindAllByRamRange(int min, int max);

    // buscar por su Modelo
    Computer FindOneByModel(string model);
    // crear
    bool AddComputersToRepo(List<Computer> computerList);

    // modificar
    bool UpdateComputerRamFromRepo(int id, int ram);

    //borrar por ids
    bool DeleteRange(List<int> IdsList);

    // borrar todos
    bool DeleteAll();
    // print list
    string PrintComputerRepo(List<Computer> computerList);
    // NOTICE: can or should this method be abstracted and overriden? What property would abstract List?
}