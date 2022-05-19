using System.Diagnostics;
using System.IO;
using VoiceHelper.Models;

namespace VoiceHelper.Services
{
    internal class Service : ServiceInterface
    {
        public bool Read(ReadRequest readRequest)
        {
            if (readRequest == null)
                return false;
            else
            {
                Process.Start(readRequest.Path);
                return true;
            }
        }

        public bool Write(WriteRequest writeRequest)
        {
            if (writeRequest == null)
                return false;
            else
            {
                using (var stream = File.Create(writeRequest.Path))
                {
                    var data = System.Text.Encoding.UTF8.GetBytes(writeRequest.Message);
                    stream.Write(data, 0, data.Length);
                }
                return true;
            }
        }

        public bool Append(WriteRequest writeRequest)
        {
            if (writeRequest == null)
                return false;
            else
            {
                using (var stream = File.AppendText(writeRequest.Path))
                {
                    stream.WriteLine(writeRequest.Message);
                }
                return true;
            }
        }
    }
}
