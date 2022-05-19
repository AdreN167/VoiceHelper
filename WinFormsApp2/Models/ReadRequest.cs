using VoiceHelper.Services;

namespace VoiceHelper.Models
{
    class ReadRequest : Request
    {
        public ReadRequest() { }
        public ReadRequest(string path)
        { 
            Path = path;
        }
    }
}
