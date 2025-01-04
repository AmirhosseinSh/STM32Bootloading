using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EosBootloading.Models
{
    public class MemoryEventRecord
    {
        public DateTime TimeStamp { get; set; }
        public int Count { get; set; }

        public string EventInfo { get; set; }
    }
}
