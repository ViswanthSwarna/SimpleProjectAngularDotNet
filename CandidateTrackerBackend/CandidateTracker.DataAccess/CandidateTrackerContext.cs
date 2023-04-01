using CandidateTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateTracker.DataAccess
{
    public class CandidateTrackerContext:DbContext
    {
        public DbSet<Candidate> Candidate { get; set; }

        public DbSet<Resume> Resume { get; set; }


        public CandidateTrackerContext(DbContextOptions<CandidateTrackerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


    }
}
