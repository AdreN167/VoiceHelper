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

        public DbSet<WriteRequest> writeRequests { get; set; }
        public DbSet<ReadRequest> readRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; Database=requestsdb; Trusted_Connection=True;");
        }
    }
}
