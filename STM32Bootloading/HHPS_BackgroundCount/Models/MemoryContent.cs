using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EosBootloading.Models
{
    public class MemoryContent
    {
        public string DevUID { get; set; }
        public string Firmware_Version { get; set; }
        public int Number_Of_Events { get; set; }

        public int Number_Of_Errors { get; set; }
        public int BatteryLevel { get; set; }

        //public DateTime BoardLastSetTime { get; set; }

        //public DateTime BoardReportTime { get; set; }
        public string BeaconID { get; set; }
        public List<MemoryEventRecord> EventRecords { get; set; }

        public MemoryContent()
        {
            EventRecords = new List<MemoryEventRecord>();
        }
    }
}
