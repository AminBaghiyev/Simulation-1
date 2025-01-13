using Microsoft.EntityFrameworkCore;
using SimulationProject.Core.Models.Base;
using SimulationProject.DL.Contexts;
using SimulationProject.DL.Repositories.Implementations;
using System.Linq.Expressions;

namespace SimulationProject.DL.Repositories.Abstractions;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
    protected readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, int page = 0, int count = 5, params string[] Includes)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (Includes.Length > 0)
        {
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }
        }

        if (expression is not null) query = query.Where(expression);

        return await query.Skip(count * page).Take(page).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int Id, params string[] Includes)
    {
        IQueryable<T> query = Table.AsQueryable();
        
        if (Includes.Length > 0)
        {
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }
        }

        return await query.SingleOrDefaultAsync(e => e.Id == Id);
    }

    public async Task<T?> GetOneWithExpressionAsync(Expression<Func<T, bool>> expression, params string[] Includes)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (Includes.Length > 0)
        {
            foreach (var include in Includes)
            {
                query = query.Include(include);
            }
        }

        return await query.SingleOrDefaultAsync(expression);
    }
}
