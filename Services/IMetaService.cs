using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Services
{
    public interface IMetaService
    {
        Dictionary<string, string> GetMetadata();
    }
}
