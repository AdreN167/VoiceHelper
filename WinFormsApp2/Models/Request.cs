using System;

namespace VoiceHelper.Models
{
    abstract internal class Request
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Path { get; set; } = "";
    }
}
