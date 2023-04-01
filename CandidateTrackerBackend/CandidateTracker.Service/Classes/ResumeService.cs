using AutoMapper;
using CandidateTracker.Entities;
using CandidateTracker.Models;
using CandidateTracker.Repository.Interfaces;
using CandidateTracker.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTracker.Service.Classes
{
    public class ResumeService : IResumeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ResumeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ResumeModel AddResume(ResumeModel resumeModel)
        {
            Resume resume = _mapper.Map<Resume>(resumeModel);
            _unitOfWork.ResumeRepository.Insert(resume);
            _unitOfWork.Save();
            ResumeModel output = _mapper.Map<ResumeModel>(resume);
            return output;
        }

        public int DeleteResume(int id)
        {
            _unitOfWork.ResumeRepository.Delete(id);
            var deleted = _unitOfWork.Save();
            return deleted;
        }

        public ResumeModel GetResume(int id)
        {
            var resume = _unitOfWork.ResumeRepository.Find(id);
            var resumeModel = _mapper.Map<ResumeModel>(resume);
            return resumeModel;
        }

        public ResumeModel UpdateResume(ResumeModel resumeModel)
        {
            Resume resume = _mapper.Map<Resume>(resumeModel);
            _unitOfWork.ResumeRepository.Update(resume);
            _unitOfWork.Save();
            ResumeModel output = _mapper.Map<ResumeModel>(resume);
            return output;
        }
    }
}
