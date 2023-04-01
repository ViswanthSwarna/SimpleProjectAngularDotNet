using CandidateTracker.DataAccess;
using CandidateTracker.Entities;
using CandidateTracker.Repository.Interfaces;

namespace CandidateTracker.Repository.Classes
{
    public class ResumeRepository : GenericCandidateTrackerRepository<Resume>, IResumeRepository
    {
        public ResumeRepository(CandidateTrackerContext context) : base(context)
        {
        }
    }
}
