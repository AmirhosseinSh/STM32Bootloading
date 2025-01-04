using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EosBootloading.Helpers
{
    public class IntensityHelper
    {
        public static int GetIntensityValue(int index)
        {
            int value = 0;

            switch (index)
            {
                case 0: //---low
                    value = 0x00;
                    break;
                case 1: //--- medium
                    value = 0x40;
                    break;
                case 2: //--- high
                    value = 0x80;
                    break;
            }

            return value;
        }
    }
}
