using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class Printer : BaseDevice, IPrinter
    {
        int PrintCounter { get; set; } = 0;
        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");
                PrintCounter++;
            }
            else if (state == IDevice.State.off) Console.WriteLine("Urządzenie jest wyłączone");
        }
    }
}
