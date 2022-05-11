using System;

namespace VoiceHelper.Models
{
    abstract internal class Request
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = "";

        public Request(string path)
        {
            Id = Guid.NewGuid();
            Path = path;
        }
    }
}
