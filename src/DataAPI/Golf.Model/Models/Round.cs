using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golf.Model.Models
{
    public class Round
    {
        public GolfCourse GolfCourse { get; set; }
        public DateTime Date { get; set; }
        public List<Golfer> Golfers { get; set; }
        public List<Score> Scores { get; set; }
    }
}
