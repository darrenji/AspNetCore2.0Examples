using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Services
{
    public interface IGreeter
    {
        string Greet(string firstname, string surname);
    }

    public class Greeter : IGreeter
    {
        public string Greet(string firstname, string surname)
        {
            return $"Hello {firstname} {surname}";
        }
    }
}
