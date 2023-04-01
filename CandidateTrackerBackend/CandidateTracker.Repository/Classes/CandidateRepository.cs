using CandidateTracker.DataAccess;
using CandidateTracker.Entities;
using CandidateTracker.Repository.Interfaces;

namespace CandidateTracker.Repository.Classes
{
    public class CandidateRepository : GenericCandidateTrackerRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(CandidateTrackerContext context) : base(context)
        {
        }
    }
}
