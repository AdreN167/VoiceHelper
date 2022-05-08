using System;

namespace VoiceHelper.Models
{
    abstract internal class Request
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = "";
    }
}
