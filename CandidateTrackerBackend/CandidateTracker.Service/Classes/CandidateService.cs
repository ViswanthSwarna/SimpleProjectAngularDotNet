using AutoMapper;
using CandidateTracker.Entities;
using CandidateTracker.Models;
using CandidateTracker.Repository.Interfaces;
using CandidateTracker.Service.Interfaces;

namespace CandidateTracker.Service.Classes
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public int AddCandidate(CandidateModel candidateModel)
        {
            Candidate candidate  = _mapper.Map<Candidate>(candidateModel);
            _unitOfWork.CandidateRepository.Insert(candidate);
            var inserted =  _unitOfWork.Save();
            return inserted;
        }

        public int DeleteCandidate(int id)
        {

            var resumeId = _unitOfWork.CandidateRepository.Find(id).ResumeId;
            _unitOfWork.CandidateRepository.Delete(id);
            _unitOfWork.ResumeRepository.Delete(resumeId);
            var deleted = _unitOfWork.Save();
            return deleted;
        }

        public CandidateModel GetCandidate(int id)
        {
            var candidate = _unitOfWork.CandidateRepository.Find(id);
            var candidateModel = _mapper.Map<CandidateModel>(candidate);
            return candidateModel;
        }

        public IEnumerable<CandidateModel> GetCandidates()
        {
            var candidates = _unitOfWork.CandidateRepository.GetAll();
            var candidateModels = _mapper.Map<IEnumerable<CandidateModel>>(candidates);
            return candidateModels;
        }

        public int UpdateCandidate(CandidateModel candidateModel)
        {
            var candidate  = _mapper.Map<Candidate>(candidateModel);
            _unitOfWork.CandidateRepository.Update(candidate);
            var updated = _unitOfWork.Save();
            return updated;
        }
    }
}
