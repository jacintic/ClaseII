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
    private ComputerValidaitior ComputerValidaitior;
    // const
    public ComputerListRepository()
    {
        computers = new List<Computer>
        {
            new Computer { Id = 1, Model = "MacBook Pro", Ram = 16},
            new Computer { Id = 2, Model = "MSI Modern", Ram = 32},
            new Computer { Id = 3, Model = "Asus A55A", Ram = 8},
        };
        ComputerValidaitior = new ComputerValidaitior();
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
        if (ExistsById(computer.Id) || !ComputerValidaitior.Validate(computer))
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

    public bool UpdateComputer(Computer computer)
    {
        if (ComputerValidaitior.Validate(computer))
            return false;
        computers.ForEach(c =>
        {
            if(c.Id == computer.Id)
            {
                c.Id = computer.Id;
                c.Model = computer.Model;
                c.Ram = computer.Ram;
                c.Price = computer.Price;
            }
        });
        return true;
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


    public bool DeleteById(int id)
    {
        if (!ExistsById(id))
            return false;
        for (int j = 0; j < computers.Count; j++)
        {
            if (computers[j].Id == id)
            {
                computers.RemoveAt(j);
                return true;
            }   
        }
        return false;
    }

    public int DeleteFromIdList(List<int> IdsList)
    {
        int initialCount = computers.Count;
        int removeCounter = 0;
        foreach (int i in IdsList)
        {
            if (DeleteById(i))
                removeCounter++;
        }
        return removeCounter;
    }

    public bool DeleteAll()
    {
        if (!computers.Any())
            return false;
        computers.Clear();
        return true;
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

    public double CalcPriceOfRepo()
    {
        double total = 0;
        computers.ForEach(c => total += c.Price);
        return total;
    }

    public double CalcAverageRamFromAllRepo()
    {
        double RamSum = 0;
        computers.ForEach(c => RamSum += c.Ram);
        return RamSum / Count();
    }

    public int FindMaxRam()
    {
        int MaxRam = 0;
        computers.ForEach(c =>
        {
            if (MaxRam < c.Ram)
                MaxRam = c.Ram;
        });
        return MaxRam;
    }

    public int FindMinRam()
    {
        int MinRam = 0;
        computers.ForEach(c =>
        {
            if (MinRam == 0 || MinRam > c.Ram)
                MinRam = c.Ram;
        });
        return MinRam;
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
}
