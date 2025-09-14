using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap
{
    public class TrapFilters
    {

        public class TrapFilter
        {
            public int? PageSize { get; set; }
            public int? PageNumber { get; set; }
            public string? Name { get; set; }
            public string? SerialNumber { get; set; }
        }

        public class trapAllFilter
        {
            public int? TrapId { get; set; }
            public string? SerialNumber { get; set; }
            public string? UserId { get; set; }
            public int categoryId { get; set; } = 0;
        }
    }
}
