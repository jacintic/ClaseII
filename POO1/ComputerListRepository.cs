using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class ComputerListRepository : IComputerRepository
{
    // attr
    private List<Computer> computers;
    // const
    public ComputerListRepository()
    {
        computers = new List<Computer>
        {
            new Computer { Id = 1, Model = "MacBook Pro", Ram = 16},
            new Computer { Id = 2, Model = "MSI Modern", Ram = 32},
            new Computer { Id = 3, Model = "Asus A55A", Ram = 8},
        };
    }
    public List<Computer> FindAll()
    {
        return computers;
    }

    public Computer FindOneById(int Id)
    {
        /*Computer found = null;
        computers.ForEach( c => { if (c.Id == Id) { found = c; } });
        return found;*/
        foreach(Computer c in computers)
            if(c.Id == Id) return c;
        return null;
        // proper way would be to throw an exception
        // for computer not found and handle it
    }

    // method from Interface
    public bool ExistsById(int Id)
    {
        return FindOneById(Id) != null;
        // undesirable since you would be 
        // fetching data from DB without 
        // using it
        //
        // desirable: SQL equivalent of Count > 0
    }

    public List<Computer> GetByIds(int[] Ids)
    {
        List<Computer> computers = new List<Computer>();
        foreach(int id in Ids)
        {
            if(ExistsById(id))
                computers.Add(FindOneById(id));
        }
        return computers;
    }

    public List<Computer> FindAllByRamRange(int min, int max)
    {
        List<Computer> cl = new List<Computer>();
        foreach ( Computer c in computers)
            if (c.Ram >= min && c.Ram <= max)
                cl.Add(c);
        return cl;       
    }

    public Computer FindOneByModel(string model)
    {
        List<Computer> cl = new List<Computer>();
        foreach (Computer c in computers)
            if (c.Model == model)
                return c;
        return null;
    }

    // add a list of computers to repo
    public bool AddComputersToRepo(List<Computer> computerList)
    {
        int count =  computers.Count;
        computers.AddRange(computerList);
        return computers.Count > count;
    }
    public bool UpdateComputerRamFromRepo(int id, int ram)
    {
        if (ExistsById(id) && FindOneById(id).Ram != ram)
        {
            FindOneById(id).Ram = ram;
            return true;
        }
        return false;
    }

    public bool DeleteRange(List<int> IdsList)
    {
        int initialCount = computers.Count;
        foreach (int i in IdsList)
        {
            if (ExistsById(i))
            {
                computers.Remove(FindOneById(i));
            }
        }
        return computers.Count < initialCount;
    }

    public bool DeleteAll()
    {
        int count = computers.Count;
        computers.Clear();
        return count > 0 && computers.Count == 0;
    }

    // I
    // print computer repo
    public string PrintComputerRepo(List<Computer> computerList)
    {
        StringBuilder sb = new StringBuilder("");
        computerList.ForEach(mov => sb.Append("." + mov + "\n"));
        return sb.ToString();
    }
}
