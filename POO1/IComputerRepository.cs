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

    // // modificar II
    bool UpdateComputer(Computer computer);

    //borrar por ids
    int DeleteFromIdList(List<int> IdsList);

    // borrar todos
    bool DeleteAll();
    // print list
    string PrintComputerList(List<Computer> list);
    // note in ComputerListRepository this method
        // uses DeleteById(id) method inside the ID loop

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
    public bool IsValidComputer(Computer computer);


    // comprovar el modelo con regex
    public List<Computer> ComputerModelIsLike(string model);

    // añadir attribute 
    public void AddPrices(double[] PriceList);

    // calcular precio total de lista
    double CalcPriceOfRepo();

    // ram media de todos los ordenadores
    double CalcAverageRamFromAllRepo();

    // ram maxima de todos los ordenadores
    double GetMaxRamFromRepo();

    // Recomendación: programar
    // poner github modo publico

}