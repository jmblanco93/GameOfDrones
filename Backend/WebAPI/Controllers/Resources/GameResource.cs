using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebAPI.Controllers.Resources
{
    public class GameResource
    {
        public Guid Id { get; set; }
        public PlayerResource Player1 { get; set; }
        public PlayerResource Player2 { get; set; }
        public PlayerResource Winner { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<RoundResource> Rounds { get; set; }

        public GameResource() : base()
        {
            Rounds = new Collection<RoundResource>();
        }
    }
}
