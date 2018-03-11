using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Resources
{
    public class RoundResource
    {
        public int Sequence { get; set; }
        public MoveResource Player1Move { get; set; }
        public MoveResource Player2Move { get; set; }
        public RoundResultResource Result { get; set; }

    }
}
