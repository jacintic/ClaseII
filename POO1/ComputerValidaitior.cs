using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class ComputerValidaitior
{
    public bool Validate(Computer computer)
    {
        return ObjectIsValid(computer) && RamIsValid(computer) && ModelIsValid(computer);
    }

    private bool ObjectIsValid(Computer computer)
    {
        return computer != null && computer.Id != 0;
    }

    private bool RamIsValid(Computer computer)
    {
        return computer.Ram > 2 && computer.Ram < 256;
    }

    private bool ModelIsValid(Computer computer)
    {
        return computer.Model != null && !"".Equals(computer.Model) && computer.Model.Length > 3;
    }
}
