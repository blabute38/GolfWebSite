using Golf.Global.Implementations;

namespace Golf.Model.Models
{
    public class Hole : Entity<int>
    {
        public int Number { get; set; } 
        public Par Par { get; set; }
        public int BlackTeeDistance { get; set; }
        public int BlackTeeHandicap { get; set; }
        public int WhiteTeeDistance { get; set; }
        public int WhiteTeeHandicap { get; set; }
        public int RedTeeDistance { get; set; }
        public int RedTeeHandicap { get; set; }
    }
}
