using Microsoft.EntityFrameworkCore;
using SimulationProject.Core.Models.Base;
using SimulationProject.DL.Contexts;
using SimulationProject.DL.Repositories.Implementations;

namespace SimulationProject.DL.Repositories.Abstractions;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{
    protected readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public void Update(T entity)
    {
        Table.Update(entity);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
