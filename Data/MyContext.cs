using ApiGames.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiGames.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Game> games { get; set; }

        public DbSet<Tag> tags { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Library> libraries { get; set; }

        public DbSet<Wishlist> wishlists { get; set; }

        public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Games").HasKey(gms => gms.Id);
            modelBuilder.Entity<Tag>().ToTable("Tags").HasKey(tgs => tgs.Id);
            modelBuilder.Entity<User>().ToTable("Users").HasKey(usr => usr.Id);
            modelBuilder.Entity<Library>().ToTable("Libraries").HasKey(lbs => lbs.Id);
            modelBuilder.Entity<Wishlist>().ToTable("Wishlists").HasKey(wsh => wsh.Id);

            modelBuilder.Entity<User>(usr => {
                usr.Property(u => u.Id).HasColumnType("bigint");
                usr.Property(u => u.Name).HasColumnType("varchar(75)");
                usr.Property(u => u.Mail).HasColumnType("varchar(75)");
            });

            modelBuilder.Entity<Game>(gms => {
                gms.Property(g => g.Id).HasColumnType("bigint");
                gms.Property(g => g.Name).HasColumnType("varchar(75)");
            });

            modelBuilder.Entity<Tag>(tgs => {
                tgs.Property(t => t.Id).HasColumnType("bigint");
                tgs.Property(t => t.Name).HasColumnType("varchar(75)");
            });

            //==================== RELATIONS============================
            modelBuilder.Entity<User>()
                .HasOne(usr => usr.Library)
                .WithOne(lbr => lbr.User)
                .HasForeignKey<Library>(lbr => lbr.Id)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(usr => usr.Wishlist)
                .WithOne(whl => whl.User)
                .HasForeignKey<Wishlist>(whl => whl.Id)
                .IsRequired();

            modelBuilder.Entity<Library>()
                .HasMany(lbs => lbs.Games)
                .WithMany();

            modelBuilder.Entity<Wishlist>()
                .HasMany(wsh => wsh.Games)
                .WithMany();

            modelBuilder.Entity<Game>()
                .HasMany(gms => gms.Tags)
                .WithMany(tgs => tgs.Games);
        }
    }
}
