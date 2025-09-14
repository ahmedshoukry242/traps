using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TrapRead
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly ServerCreationDate { get; set; }


        // Navigation Props
        public Trap Trap { get; set; }
        public int TrapId { get; set; }

        public IEnumerable<ReadDetails> readDetails { get; set; }
    }
}
