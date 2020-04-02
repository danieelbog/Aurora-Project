using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuroraProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<BasicPackage> BasicPackages { get; set; }
        public DbSet<AdvancedPackage> AdvancedPackages { get; set; }
        public DbSet<PremiumPackage> PremiumPackages { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<SpecificIndustry> SpecificIndustries { get; set; }
        public DbSet<Influencer> Influencers { get; set; }
        public DbSet<FavouriteGig> FavouriteGigs { get; set; }
        public DbSet<FavouriteInfluencer> FavouriteInfluencers { get; set; }
        //public DbSet<Wallet> Wallets { get; set; }

        public ApplicationDbContext()
            : base("AuroraProjectDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Influencer>()
            //   .HasRequired(n => n.User)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Influencer>()
            //   .HasRequired(n => n.User)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Gigs)
                .WithRequired(f => f.Actioner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gig>()
                .HasMany(u => u.Actioners)
                .WithRequired(f => f.Gig)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}