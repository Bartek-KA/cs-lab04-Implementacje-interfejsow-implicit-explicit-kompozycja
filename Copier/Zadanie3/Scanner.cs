using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class Scanner : BaseDevice, IScanner
    {
        int ScanCounter { get; set; } = 0;
        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            switch (formatType)
            {
                default:
                    ScanCounter++;
                    document = new ImageDocument($"ImageScan{ScanCounter}.jpg");
                    break;
                case IDocument.FormatType.TXT:
                    ScanCounter++;
                    document = new TextDocument($"TextScan{ScanCounter}.txt");
                    break;
                case IDocument.FormatType.PDF:
                    ScanCounter++;
                    document = new PDFDocument($"PDFScan{ScanCounter}.pdf");
                    break;
            }
            if (state == IDevice.State.on) Console.WriteLine($"{DateTime.Now} {document.GetFileName()}");
            else if (state == IDevice.State.off) Console.WriteLine("Urządzenie jest wyłączone");
        }
    }
}
