using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

/*
 * Interfaces are abstract types,
 * they do not implement methods, they merely declare them
 */
public interface IGreeting
{
    void Greet();
    string Greet(string name);
    //void SayGoodBye();
}
