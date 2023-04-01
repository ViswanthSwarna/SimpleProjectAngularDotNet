using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTracker.Repository.Interfaces
{
    public interface IGenericCandidateTrackerRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? Find(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
    }
}
