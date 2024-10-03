using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Interfaces;

namespace WordWave.Presentation.Interfaces
{
    public interface IService<TEntity, TId> where TEntity : IEntity<TId>
    {
        Task<TEntity> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity, int id);
        Task DeleteAsync(TId id);
    }
}
