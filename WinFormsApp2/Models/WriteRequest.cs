namespace VoiceHelper.Models
{
    internal class WriteRequest : Request
    {
        public string Message { get; set; } = "";
        public WriteRequest() { }
        public WriteRequest(string path) 
        { 
            Path = path; 
        }
        public WriteRequest(string path, string message) 
        {
            Path = path;
            Message = message;
        }
    }
}
