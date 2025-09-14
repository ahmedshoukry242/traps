using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Trap
{
    public class ConfigurationsRead
    {
        public string Serial { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Co2 { get; set; }
        public int Fan { get; set; }
        public bool Read { get; set; }
        public string File { get; set; }
        public string? FileDate { get; set; }
    }
}
