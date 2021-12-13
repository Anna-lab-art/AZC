using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AZC.Model
{
    public class Station
    {
        [Key]
        public int id { get; set; }
        public string Address { get; set; }
    }
}
