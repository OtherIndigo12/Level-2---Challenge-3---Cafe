using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class ResponseItemsDTO
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public int Category_id {get; set;}
        public double Price {get; set;}
        public string Description {get; set;} = string.Empty;
        public string Tag {get; set;} = string.Empty;
    }
}