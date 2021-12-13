using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AZC.Model
{
    public class Petron
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string AmountOfFuel { get; set; }
        public string Station_ID { get; set; }
    }
}
