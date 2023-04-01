using Microsoft.EntityFrameworkCore;
using CandidateTracker.Repository.Interfaces;
using CandidateTracker.DataAccess;

namespace CandidateTracker.Repository.Classes
{

    public class GenericCandidateTrackerRepository<TEntity> : IGenericCandidateTrackerRepository<TEntity> where TEntity : class
    {
        private CandidateTrackerContext _context;
        private DbSet<TEntity> _dbSet;
        public GenericCandidateTrackerRepository(CandidateTrackerContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Delete(object id)
        {
            TEntity? entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public TEntity? Find(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Insert(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}

