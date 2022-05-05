using System;
using ver1;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int PrintCounter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");
                PrintCounter++;
            }
            else return;
        }
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
        public void Scan(out IDocument document)
        {
            Scan(out document, IDocument.FormatType.JPG);
        }
        public void ScanAndPrint()
        {
            Scan(out IDocument document);
            Print(document);
        }
    }
}
