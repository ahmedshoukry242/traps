using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap.TrapEmergency
{
    public class EmergencyWrite
    {
        public string SerialNumber { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        public DateTime Date { get; set; }
    }
}
