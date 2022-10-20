using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    public  interface IComputerRepository
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

        // crear

        // modificar

        // borrar

        //borrar por ids

        // borrar todos

        /*List<Computer> FindAllById(List<int> IdList);
        Computer Create(Computer computer);
        Computer CreateMany(List<Computer> computers);*/
    }
}
