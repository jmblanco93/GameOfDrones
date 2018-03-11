using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApplicationCore.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public Player() : base()
        {
        }
    }
}
