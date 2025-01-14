using Microsoft.EntityFrameworkCore;
using SimulationProject.Core.Models.Base;
using System.Linq.Expressions;

namespace SimulationProject.DL.Repositories.Implementations;

public interface IReadRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
    Task<T?> GetByIdAsync(int Id, bool Tracking = false, params string[] Includes);
    Task<T?> GetOneWithExpressionAsync(Expression<Func<T, bool>> expression, bool Tracking = false, params string[] Includes);
    Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, int page = 0, int count = 5, bool orderAsc = true, params string[] Includes);
}
