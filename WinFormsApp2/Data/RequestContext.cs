using Microsoft.EntityFrameworkCore;

namespace VoiceHelper.Data
{
    internal class RequestContext : DbContext
    {
        public RequestContext()
        {
            Database.EnsureCreated();
        }
    }
}
