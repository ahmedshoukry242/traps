using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.TrapRead
{
    public class ReadRequestDto
    {
        [Required]
        public int TrapId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
