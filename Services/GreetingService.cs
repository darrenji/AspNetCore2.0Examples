using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Services
{
    public class GreetingService : IGreetingService
    {
        public string Greet(string to)
        {
            return $"Hello {to}";
        }
    }
}
