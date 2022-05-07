using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;

namespace Zadanie3
{
    public class Faxer : BaseDevice, IFax
    {
        public void Print(in IDocument document)
        {
            throw new NotImplementedException();
        }

        public void RecieveFax(in IDocument document, string sender)
        {
            throw new NotImplementedException();
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            throw new NotImplementedException();
        }

        public void ScanAndFax(string receiver)
        {
            throw new NotImplementedException();
        }

        public void SendFax(in IDocument document, string receiver)
        {
            throw new NotImplementedException();
        }
    }
}
