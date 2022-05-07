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
        int PrintCounter { get; set; } = 0;
        int ScanCounter { get; set; } = 0;
        Printer printer;
        Scanner scanner;
        public Copier(Printer printer, Scanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }    
    }
}
