using Microsoft.EntityFrameworkCore;
using SimulationProject.Core.Models.Base;

namespace SimulationProject.DL.Repositories.Implementations;

public interface IWriteRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
    Task CreateAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
    Task<int> SaveChangesAsync();
}
