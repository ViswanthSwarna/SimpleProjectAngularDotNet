using CandidateTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTracker.Service.Interfaces
{
    public interface IResumeService
    {
        ResumeModel GetResume(int id);
        ResumeModel AddResume(ResumeModel resumeModel);
        ResumeModel UpdateResume(ResumeModel resumeModel);
        int DeleteResume(int id);
    }
}
