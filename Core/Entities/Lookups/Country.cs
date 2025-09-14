using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Lookups
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string NameAr { get; set; }
        public string TimeZoneName { get; set; }
        public int UtcOffsetMinutes { get; set; }

        public IEnumerable<State> States { get; set; }
        public IEnumerable<Trap> Traps { get; set; }
    }
}
