namespace ApplicationCore.Entities
{
    public class Log : BaseEntity
    {
        public LogLevel Level { get; set; }
        public string Description { get; set; }

        public Log() : base()
        {
        }
    }
}
