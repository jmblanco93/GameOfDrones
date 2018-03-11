using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Rounds")]
    public class Round : BaseEntity
    {
        public int Sequence { get; set; }
        public Move Player1Move { get; set; }
        public Move Player2Move { get; set; }
        public RoundResult Result { get; set; }
    }
}
