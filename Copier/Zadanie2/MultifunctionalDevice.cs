using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie2
{
    public class MultifunctionalDevice : BaseDevice, IPrinter, IScanner, IFax
    {
        public int PrintCounter { get; set; } = 0;
        public int ScanCounter { get; set; } = 0;
        public int FaxCounter   { get; set; } = 0;

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
        public void ScanAndFax(string receiver)
        {
            if (state == IDevice.State.on)
            {
                Scan(out IDocument document, IDocument.FormatType.JPG);
                SendFax(document, receiver);
            }
            else if (state == IDevice.State.off) Console.WriteLine("Urządzenie jest wyłączone");
        }
        public void SendFax(in IDocument document, string receiver)
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"Wysłano fax do {receiver}");
                FaxCounter++;
            }
            else if (state == IDevice.State.off) Console.WriteLine("Urządzenie jest wyłączone");
        }

        public void RecieveFax(in IDocument document, string sender)
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine($"Nowa wiadomość {document.GetFileName()} od {sender}");
                Print(document);
                FaxCounter++;
            }
            else if (state == IDevice.State.off) Console.WriteLine("Urządzenie wyłączone");
        }
    }
}
