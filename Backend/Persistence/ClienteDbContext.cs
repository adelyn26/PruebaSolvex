using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class ClienteDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public ClienteDbContext(DbContextOptions<ClienteDbContext> options)
            : base(options)
        { }
    }
}
