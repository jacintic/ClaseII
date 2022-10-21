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
    
    // add one
    public bool Save(Computer computer);
    
    // crear
    int AddComputersToRepo(List<Computer> computerList);

    // modificar
    bool UpdateComputerRamFromRepo(int id, int ram);

    //borrar por ids
    bool DeleteRange(List<int> IdsList);

    // borrar todos
    bool DeleteAll();
    // print list
    string PrintComputerList(List<Computer> list);

    // print all
    string PrintAll();

    // NOTICE: can or should this method be abstracted and overriden? What property would abstract List?


    // TODO: 

    //  recuperar el numero de ordenadores en lista (count)
    // metodo count existe y esto es redundante
    public int Count();
    // refactorizar codigo implementando Count() en los metodos necesarios

    // -- // crear una clase ComputerValidator con un método validate que reciba un Computer
    // devuelva true o false si cumple una serie de condiciones:
    // Id mayor que 0 
    // RAM mayor que 2 y menor que 256
    // Model no puede ser nulo ni estar vacío y tiene que tener una longitud superior a 3 letras
    // Utilizar este validador antes de guardar un ordenador

    // comprovar el modelo con regex
    // añadir attribute precio
    // calcular precio total de lista
    // ram media de todos los ordenadores
    // ram maxima de todos los ordenadores

    // Recomendación: programar
    // poner github modo publico

}