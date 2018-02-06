using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seminar.Model;

namespace Seminar.DAL
{
    public class MovieDbContext : IdentityDbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        { }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<LeadingActor> LeadingActor { get; set; }
        public DbSet<Seminar.Model.Type> Type { get; set; }
        public DbSet<MovieLeadingActor> MovieLeadingActor { get; set; }
        public DbSet<MovieType> MovieType { get; set; }
        public DbSet<Studio> Studio { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>().
                Property(e => e.DateCreated).
                HasDefaultValueSql("GETDATE()");                
            
            builder.Entity<Movie>().
                Property(e => e.DateUpdated).
                HasDefaultValueSql("GETDATE()");                            

            builder.Entity<LeadingActor>().
                Property(e => e.DateCreated).
                HasDefaultValueSql("GETDATE()");                

            builder.Entity<LeadingActor>().
                Property(e => e.DateUpdated).
                HasDefaultValueSql("GETDATE()");                            

            builder.Entity<Model.Type>().
                Property(e => e.DateCreated).
                HasDefaultValueSql("GETDATE()");

            builder.Entity<Model.Type>().
                Property(e => e.DateUpdated).
                HasDefaultValueSql("GETDATE()");            

            builder.Entity<Studio>().
                Property(e => e.DateCreated).
                HasDefaultValueSql("GETDATE()");                
            
            builder.Entity<Studio>().
                Property(e => e.DateUpdated).
                HasDefaultValueSql("GETDATE()");                            

            builder.Entity<MovieType>().
                Property(e => e.DateCreated).
                HasDefaultValueSql("GETDATE()");            
            builder.Entity<MovieType>().
                HasKey(e => new { e.TypeId, e.MovieId});

            builder.Entity<MovieLeadingActor>().
                Property(e => e.DateCreated).
                HasDefaultValueSql("GETDATE()");
            builder.Entity<MovieLeadingActor>().
                HasKey(e => new { e.MovieId, e.LeadingActorId});
        }
    }
}
