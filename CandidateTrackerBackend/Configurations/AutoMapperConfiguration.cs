using AutoMapper;
using CandidateTracker.Entities;
using CandidateTracker.Models;

namespace CandidateTracker.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Candidate, CandidateModel>().ReverseMap();
            CreateMap<Resume,ResumeModel>().ReverseMap();
        }
    }
}