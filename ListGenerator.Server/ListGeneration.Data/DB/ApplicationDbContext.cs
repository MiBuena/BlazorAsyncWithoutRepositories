using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ListGenerator.Data.Entities;

namespace ListGeneratorListGenerator.Data.DB
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Purchase> Purchases { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Purchase>()
                .HasOne(p => p.Item)
                .WithMany(b => b.Purchases)
                .HasForeignKey(p => p.ItemId);

            builder.Entity<Item>()
                .HasOne(p => p.User)
                .WithMany(b => b.Items)
                .HasForeignKey(p => p.UserId);
        }
    }
}
