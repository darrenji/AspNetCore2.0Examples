using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Services
{
    public class MetaService : IMetaService
    {
        public Dictionary<string, string> GetMetadata()
        {
            return new Dictionary<string, string> {
                { "description","this is a post on taghelpercomponent"},
                {"keywords", "asp.net core, tag helpers" }
            };
        }
    }
}
