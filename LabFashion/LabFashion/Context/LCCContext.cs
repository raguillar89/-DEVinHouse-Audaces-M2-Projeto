using Microsoft.EntityFrameworkCore;

namespace LabFashion.Context
{
    public class LCCContext : DbContext
    {
        public LCCContext() { }

        public LCCContext(DbContextOptions<LCCContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
    }
}
