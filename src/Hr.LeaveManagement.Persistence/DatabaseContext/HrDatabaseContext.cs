using Hr.LeaveManagement.Domain;
using Hr.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Hr.LeaveManagement.Persistence.DatabaseContext
{
    public class HrDatabaseContext:DbContext
    {
        public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options): base(options)
        {            
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
            //if we wrote below line then we need to register everything abvove line is dynmically identifies and apply
            //modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
            //move to LeaveTypeConfiguration file for single responsibility
            //modelBuilder.Entity<LeaveType>().HasData(
            //    new LeaveType()
            //    {
            //        Id = 1,
            //        Name = "Vacation",
            //        DefaultDays = 10,
            //        DateCreated= DateTime.UtcNow
            //    }
            //    );
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(x=>x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.UtcNow;
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated=DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
