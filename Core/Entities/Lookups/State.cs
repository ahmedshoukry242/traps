using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Lookups
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string NameEn { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public IEnumerable<Trap> Traps { get; set; }
    }
}
