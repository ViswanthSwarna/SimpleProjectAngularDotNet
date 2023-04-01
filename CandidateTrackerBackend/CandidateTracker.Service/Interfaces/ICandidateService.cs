using CandidateTracker.Models;

namespace CandidateTracker.Service.Interfaces
{
    public interface ICandidateService
    {
        IEnumerable<CandidateModel> GetCandidates();

        CandidateModel GetCandidate(int id);
        int AddCandidate(CandidateModel candidateModel);
        int UpdateCandidate(CandidateModel candidateModel);
        int DeleteCandidate(int id);

    }
}
