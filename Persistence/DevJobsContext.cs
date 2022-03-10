using DevJobs.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.API.Persistence
{
    public class DevJobsContext : DbContext
    {
        public DevJobsContext(DbContextOptions<DevJobsContext> options): base(options)
        {
        }

        public DbSet<JobVacancy> JobVacancies { get; set; }
    }
}