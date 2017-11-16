using Examples.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Models
{
    public class MovieInputModel
    {
        [ProtectedId]
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
