using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppProj.Models;

namespace WebAppProj.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Announcement>().ToTable("Announcement");
        }

        public DbSet<WebAppProj.Models.Contacts> Contacts { get; set; }
        public DbSet<WebAppProj.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<WebAppProj.Models.ApplicationUser> UserManager { get; set; }
        public DbSet<WebAppProj.Models.Announcement> Announcements { get; set; }
        public DbSet<WebAppProj.Models.Comments> Comments { get; set; }
    }
}

