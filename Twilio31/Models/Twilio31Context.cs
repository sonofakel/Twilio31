using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Twilio31.Models
{

    public class Twilio31Context : IdentityDbContext<ApplicationUser>
    {
        public Twilio31Context(DbContextOptions options) : base(options)
        {

        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder
			.UseMySql(@"Server=localhost;Port=8889;database=twilio31;uid=root;pwd=root;");

        public virtual DbSet<Contact> Contacts { get; set; }
		public virtual DbSet<Message> Messages { get; set; }


		public Twilio31Context() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail)
                .HasMaxLength(255));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName)
                .HasMaxLength(255));

            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName)
                .HasMaxLength(255));

            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)
                .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)
                .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));

            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)
                .HasMaxLength(255));

            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)
                .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)
                .HasMaxLength(255));

            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)
                .HasMaxLength(255));
        }
    }
}