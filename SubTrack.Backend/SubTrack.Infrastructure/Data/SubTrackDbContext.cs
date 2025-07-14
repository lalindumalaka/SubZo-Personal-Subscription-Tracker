using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubTrack.Domain.Entities;
using SubTrack.Infrastructure.Identity;

namespace SubTrack.Infrastructure.Data
{
    public class SubTrackDbContext : IdentityDbContext<ApplicationUser>
    {
        public SubTrackDbContext(DbContextOptions<SubTrackDbContext> options) : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionCategory> SubscriptionCategories { get; set; }
    }
} 