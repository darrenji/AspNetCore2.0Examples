using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Services
{
    public interface IMessageService
    {
        string FormatMessage(string message);
    }
}
