using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
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
        foreach (Computer c in computers)
            if (c.Id == Id) return c;
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
        foreach (int id in Ids)
        {
            if (ExistsById(id))
                computers.Add(FindOneById(id));
        }
        return computers;
    }

    public List<Computer> FindAllByRamRange(int min, int max)
    {
        List<Computer> cl = new List<Computer>();
        foreach (Computer c in computers)
            if (c.Ram >= min && c.Ram <= max)
                cl.Add(c);
        return cl;
    }

    public Computer FindOneByModel(string model)
    {
        foreach (Computer c in computers)
            if (c.Model.ToLower().Equals(model.ToLower()))
                return c;
        return null;
    }
    public bool Save(Computer computer)
    {
        if (ExistsById(computer.Id) || !IsValidComputer(computer))
            return false;
        computers.Add(computer);
        return true;
    }

    // add a list of computers to repo
    public int AddComputersToRepo(List<Computer> computerList)
    {
        int counter = 0;
        computerList.ForEach(c => { if (Save(c)) counter++; });
        // NOTICE: this method counts ONLY the registers added by this transaction alone
        // and ONLY when they're successful
        return counter;
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

    public List<Computer> ComputerModelIsLike(string model)
    {
        string pattern = @".*(" + model.ToLower() + ").*";
        Regex rg = new Regex(pattern);
        List<Computer> computersLike = new List<Computer>();
        computers.ForEach(c => 
        {
            MatchCollection matchedAuthors = rg.Matches(c.Model.ToLower());
            if (matchedAuthors.Count > 0)
                computersLike.Add(c);
        });
        return computersLike;
    }

    // NOTICE: deleting computers by this 
    public bool DeleteRange(List<int> IdsList)
    {
        int initialCount = computers.Count;
        int removeCounter = 0;
        foreach (int i in IdsList)
        {
            if (ExistsById(i) && computers.Remove(FindOneById(i)))
            {
                removeCounter++;
            }
        }
        return removeCounter == IdsList.Count();
    }

    public bool DeleteAll()
    {
        int count = computers.Count;
        computers.Clear();
        return count > 0 && computers.Count == 0;
    }

    public void AddPrices(double[] PriceList)
    { 
        try
        {
            if (PriceList.Length != computers.Count)
                throw new AuthenticationException("Lists do not match in length");
        } 
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
        int index = 0;
        computers.ForEach(c => { c.Price = PriceList[index]; index++; });
    }

    // new methods
    public int Count()
    {
        int counter = 0;
        computers.ForEach(c => counter++);
        return counter;
    }


    // -- UTILITIES -- //
    public string PrintComputerList(List<Computer> list)
    {
        return string.Join("", list);
    }

    public string PrintAll()
    {
        return string.Join("", computers);
    }

    public bool IsValidComputer(Computer computer)
    {
        return
        // devuelva true o false si cumple una serie de condiciones:
        // Id mayor que 0 
        computer.Id > 0 &&
        // RAM mayor que 2 y menor que 256
        computer.Ram > 2 && computer.Ram < 256 &&
        // Model no puede ser nulo ni estar vacío y tiene que tener una longitud superior a 3 letras
        !(computer.Model is null) && !"".Equals(computer.Model) && computer.Model.Length > 3;

    }
}
