using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class ResponseMenuDTO
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Tagline {get; set;} = string.Empty;
        public string Address {get; set;} = string.Empty;
        public string Hours {get; set;} = string.Empty;
        public string Phone {get; set;} = string.Empty;
    }
}