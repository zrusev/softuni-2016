namespace FDMC.Data.Context
{
    using FDMC.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FdmcContext : DbContext
    {
        public FdmcContext(DbContextOptions<FdmcContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}
