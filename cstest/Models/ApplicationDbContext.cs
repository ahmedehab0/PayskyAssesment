using Microsoft.EntityFrameworkCore;
using cstest.Models;

namespace cstest.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor used by application runtime
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Parameterless constructor for design-time migrations
        public ApplicationDbContext()
        { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>()
        .Property(e => e.AccountType)
        .HasConversion<string>();

            // Configure the relationship between Transaction and Account for SourceAccount
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.SourceAccount)
                .WithMany(a => a.SourceTransactions)
                .HasForeignKey(t => t.SourceAccountId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Configure the relationship between Transaction and Account for DestinationAccount
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.DestinationAccount)
                .WithMany(a => a.DestinationTransactions)
                .HasForeignKey(t => t.DestinationAccountId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
