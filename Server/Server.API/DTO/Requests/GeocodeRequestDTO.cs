using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.DTO
{
    public class GeocodeRequestDTO
    {
        public string address { get; set; }
        public string benchmark { get; set; } = "2020";
        public string format { get; set; } = "json";
    }
}
