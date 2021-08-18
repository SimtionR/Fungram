using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    public class FungramContext :  IdentityDbContext<User>
    {

        public FungramContext(DbContextOptions options) :base( options)
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users  { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Reaction> Reactions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Profile)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Profile)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);



            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.Profile)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reaction>()
                .HasOne(r => r.Post)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


        }


    }
}
