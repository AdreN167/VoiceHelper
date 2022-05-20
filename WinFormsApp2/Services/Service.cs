using System.Diagnostics;
using System.IO;
using VoiceHelper.Models;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using VoiceHelper.Data;
using VoiceHelper.Services;
using System.Collections.Generic;

namespace VoiceHelper.Services
{
    internal class Service : ServiceInterface
    {
        static Service service = new Service();

        public void AddToFile(TextBox textBox, SaveFileDialog saveFileDialog)
        {
            using (var context = new RequestContext())
            {
                if (saveFileDialog.ShowDialog() != DialogResult.Cancel && textBox.Text != string.Empty)
                {
                    var request = new WriteRequest();

                    request.Message = textBox.Text;
                    request.Path = saveFileDialog.FileName;

                    if (service.Append(request))
                    {
                        context.Add(request);
                        context.SaveChanges();
                    }
                }
            }
        }
        public void ReWriteInFile(TextBox textBox, SaveFileDialog saveFileDialog)
        {
            using (var context = new RequestContext())
            {
                if (saveFileDialog.ShowDialog() != DialogResult.Cancel && textBox.Text != string.Empty)
                {
                    var request = new WriteRequest();

                    request.Message = textBox.Text;
                    request.Path = saveFileDialog.FileName;

                    if (service.Write(request))
                    {
                        context.Add(request);
                        context.SaveChanges();
                    }
                }
            }
        }

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
