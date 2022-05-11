using VoiceHelper.Services;

namespace VoiceHelper.Models
{
    class ReadRequest : Request
    {
        public ReadRequest(string path) : base(path) { }
    }
}
