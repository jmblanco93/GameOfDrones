using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApplicationCore.Entities
{
    public class Game : BaseEntity
    {
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }
        public Guid? WinnerId { get; set; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player Winner { get; set; }

        public ICollection<Round> Rounds { get; set; }

        public Game() : base()
        {
            Rounds = new Collection<Round>();
        }
    }
}
