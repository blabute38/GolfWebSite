using Golf.Global.Implementations;
using System;

namespace Golf.Model.Models
{
    public class Golfer : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Class Class { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
