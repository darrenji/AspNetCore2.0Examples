using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Services
{
    public class FlexibleGreetingService : IGreetingService
    {
        private readonly string sayWhat;

        public FlexibleGreetingService(string sayWhat)
        {
            this.sayWhat = sayWhat;
        }
        public string Greet(string to)
        {
            return $"{this.sayWhat} {to}";
        }
    }
}
