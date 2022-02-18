using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEngine.Models
{
    public class DB_Engine
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int launched { get; set; }
        public string developer { get; set; }
    }
}
