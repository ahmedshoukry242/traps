using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TrapEmergency
    {
        [Key]
        public int Id { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public DateTime Date { get; set; }
        public DateTime InsertDate { get; set; }
        public bool EmergencyStatus { get; set; } = true;

        // Navigation props
        public int TrapId { get; set; }
        public Trap Trap { get; set; }
    }
}
