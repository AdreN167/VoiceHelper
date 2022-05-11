namespace VoiceHelper.Models
{
    internal class WriteRequest : Request
    {
        public string Message { get; set; } = "";
        public WriteRequest(string path) : base(path) { }
        public WriteRequest(string path, string message) : base(path)
        {
            Message = message;
        }
    }
}
