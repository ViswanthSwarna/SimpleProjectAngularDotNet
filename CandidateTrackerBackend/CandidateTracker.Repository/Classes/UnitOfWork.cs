using CandidateTracker.DataAccess;
using CandidateTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTracker.Repository.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CandidateTrackerContext _context;

        public UnitOfWork(CandidateTrackerContext context)
        {
            _context = context;
            CandidateRepository = new CandidateRepository(_context);
            ResumeRepository = new ResumeRepository(_context);
        }

        public ICandidateRepository CandidateRepository { get; private set; }
        public IResumeRepository ResumeRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
