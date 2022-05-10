using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceHelper.Models
{
    class ReadRequest
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = "";
    }
}
