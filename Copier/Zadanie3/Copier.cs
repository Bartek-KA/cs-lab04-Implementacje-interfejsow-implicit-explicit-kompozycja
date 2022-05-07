using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class Copier : BaseDevice
    {
        int Counter { get; set; } = 0;
        int PrintCounter { get; set; } = 0;
        int ScanCounter { get; set; } = 0;      
    }
}
