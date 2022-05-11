using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceHelper.Models
{
    internal class WriteRequest
    {
        string request;
        bool a;
        public WriteRequest(string b)
        {
            request = b;
        }
        public void Abrakadabra()
        {
            request = "asdasdasd";
        }
    }
}
