using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Resources
{
    public class PlayerResource
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
    }
}
