using Microsoft.EntityFrameworkCore;
using VoiceHelper.Models;

namespace VoiceHelper.Data
{
    internal class RequestContext : DbContext
    {
        public RequestContext()
        {
            Database.EnsureCreated();
        }

        DbSet<WriteRequest> writeRequests { get; set; }
        DbSet<ReadRequest> readRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost; Database=requestsdb; Trusted_Connection=True;");
        }
    }
}
