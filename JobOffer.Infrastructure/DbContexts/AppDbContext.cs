using System.Reflection;
using JobOffer.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobOffer.Infrastructure.DbContexts
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }



        public DbSet<JobApplicated> JobApplicateds { get; set; }
        public DbSet<JobOffered> JobOffereds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Types> Typess { get; set; }
        public DbSet<City> Cities { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



            builder.Entity<JobOffered>(X =>
            {
                X.HasOne(K => K.type)
                 .WithMany()
                 .HasForeignKey(K => K.TypeId);


                X.HasOne(K => K.category)
                 .WithMany()
                 .HasForeignKey(K => K.CategoryId);


                X.HasKey(K => K.Id);

                X.Property(K=>K.Name)
                 .IsRequired()
                 .HasMaxLength(150);

                X.Property(K => K.Salary)
                 .HasPrecision(18, 2);
            });


            builder.Entity<JobApplicated>(X =>
            {

                X.HasOne(K => K.jobOffered)
                 .WithMany(M=>M.Applicateds)
                 .HasForeignKey(K => K.JobOfferId);



                X.HasOne(K=>K.user)
                 .WithMany()
                 .HasForeignKey(k=>k.UserId);



                X.HasKey(K=>K.Id);


            });


            builder.Entity<User>(X =>
            {

                X.HasOne(K => K.city)
                 .WithMany()
                 .HasForeignKey(K => K.CityId);


                X.Property(K => K.FullName)
                 .IsRequired()
                 .HasMaxLength(150);


            });

        }
        


    }
}
