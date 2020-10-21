using MeLi_Topsecret_split.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MeLi_Topsecret_split.Persistence
{
    public class AlianzaRebeldeContext : DbContext
    {
        public AlianzaRebeldeContext(DbContextOptions<AlianzaRebeldeContext> options) : base(options) { }

        public DbSet<SqlSatellites> Satellites { get; set; }
    }
}
