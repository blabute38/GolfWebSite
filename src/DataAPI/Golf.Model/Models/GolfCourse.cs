using System.Collections.Generic;

namespace Golf.Model.Models
{
    public class GolfCourse : Entity<int>
    {
        public string Name { get; set; }
        public virtual Location Location{ get; set; }
        public virtual List<Hole> Holes { get; set; }
    }
}
