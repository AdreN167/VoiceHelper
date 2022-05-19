using VoiceHelper.Models;

namespace VoiceHelper.Services
{
    internal interface ServiceInterface
    {
        bool Write(WriteRequest writeRequest);
        bool Read(ReadRequest readRequest);        
    }
}
