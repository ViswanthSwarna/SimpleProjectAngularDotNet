using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTracker.Repository.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        ICandidateRepository CandidateRepository { get; }
        IResumeRepository ResumeRepository { get; }
        int Save();
    }
}
