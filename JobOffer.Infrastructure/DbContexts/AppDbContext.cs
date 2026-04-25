using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JobOffer.Infrastructure.DbContexts
{
    public class AppDbContext : IdentityDbContext<User>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        public DbSet<JobApplicated> JobApplicateds { get; set; }
        public DbSet<JobOffered> JobOffereds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Typess> Typess { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Audit> Audits { get; set; }



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

                X.Property(K => K.Name)
                 .IsRequired()
                 .HasMaxLength(150);

                X.Property(K => K.Salary)
                 .HasPrecision(18, 2);
            });


            builder.Entity<JobApplicated>(X =>
            {

                X.HasOne(K => K.jobOffered)
                 .WithMany(M => M.Applicateds)
                 .HasForeignKey(K => K.JobOfferId);



                X.HasOne(K => K.user)
                 .WithMany()
                 .HasForeignKey(k => k.UserId);



                X.HasKey(K => K.Id);


            });


            builder.Entity<User>(X =>
            {

                X.HasOne(K => K.city)
                 .WithMany()
                 .HasForeignKey(K => K.CityId);


                X.Property(K => K.FullName)
                 .IsRequired()
                 .HasMaxLength(150);


                X.Property(K => K.Gender)
                 .HasConversion<string>();


            });

        }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var userName = _httpContextAccessor.HttpContext?.User?.FindFirst("name")?.Value;


            var entries = ChangeTracker.Entries()
                                       .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
                                       .ToList();

            foreach (var entry in entries)
            {
                if (entry.Entity is Audit) continue;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
                    entry.Property("CreatedBy").CurrentValue = userName;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("EditedOn").CurrentValue = DateTime.UtcNow;
                    entry.Property("EditedBy").CurrentValue = userName;
                }

                var auditLog = new Audit
                {
                    EntityName = entry.Entity.GetType().Name,
                    Action = entry.State.ToString(),
                    UserName = userName,
                    OldValues = entry.State == EntityState.Added ? null : JsonSerializer.Serialize(entry.OriginalValues.ToObject()),
                    NewValues = entry.State == EntityState.Deleted ? null : JsonSerializer.Serialize(entry.CurrentValues.ToObject()),
                    CreatedBy = userName ,
                    IsDeleted = entry.State == EntityState.Deleted,
                    DeletedBy = entry.State == EntityState.Deleted ? userName : null,
                    DeletedOn = entry.State == EntityState.Deleted ? DateTime.UtcNow : null,
                };

                await Set<Audit>().AddAsync(auditLog, cancellationToken);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}