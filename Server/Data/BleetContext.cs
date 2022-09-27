namespace BrightApp.Server.Data
{
    public class BleetContext : DbContext
    {
        public BleetContext(DbContextOptions<BleetContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bleet>().HasData(
                new Bleet
                {
                    Id = 1,
                    BleetTitle = "First Bleet",
                    BleetText = "Que sera sera",
                    CreatedAt = DateTime.Now,
                    CreatorUsername = "@stephen_krogger"
                },
                new Bleet
                {
                    Id = 2,
                    BleetTitle = "The doom of mankind",
                    BleetText = "And so the robots spared humanity",
                    CreatedAt = DateTime.Now,
                    CreatorUsername = "@elon_musk"
                },
                new Bleet
                {
                    Id = 3,
                    BleetTitle = "Sometime in the future...",
                    BleetText = "My Model X is the greatest thing I have ever purchased. Period.",
                    CreatedAt = DateTime.Now,
                    CreatorUsername = "@stephen_krogger"
                },
                new Bleet
                {
                    Id = 4,
                    BleetTitle = "Avenge me, Gamora!",
                    BleetText = "It cost me everything to balance the world but, the Avengers thwarted my plan by going back in time and killing me. Gamora these are my last words for you, Avenge me!!!",
                    CreatedAt = DateTime.Now,
                    CreatorUsername = "@probably_thanos"
                }
            );
        }

        public DbSet<Bleet> Bleets { get; set; }
    }
}
