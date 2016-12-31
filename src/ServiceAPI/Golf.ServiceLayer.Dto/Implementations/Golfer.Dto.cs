using Golf.Global.Implementations;
using System;

namespace Golf.ServiceLayer.Dto.Implementations
{
    public class GolferDto : Dto<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Class Class { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
