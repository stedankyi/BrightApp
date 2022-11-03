namespace BrightApp.Server.Data
{
    public class BleetContext : DbContext
    {
        public BleetContext(DbContextOptions<BleetContext> options) : base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Bleet> Bleets { get; set; }
        public DbSet<UserData> Users { get; set; }
    }
}
