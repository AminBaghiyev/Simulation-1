using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimulationProject.Core.Models;
using SimulationProject.DL.Contexts;
using SimulationProject.DL.Repositories.Abstractions;
using SimulationProject.DL.Repositories.Implementations;
using SimulationProject.DL.Utilities;

namespace SimulationProject.DL;

public static class ConfigurationServices
{
    public static void AddDLServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Connection.GetConnectionString()));

        services.AddScoped<IReadRepository<Card>, ReadRepository<Card>>();
        services.AddScoped<IWriteRepository<Card>, WriteRepository<Card>>();

        services.AddScoped<IReadRepository<Settings>, ReadRepository<Settings>>();
        services.AddScoped<IWriteRepository<Settings>, WriteRepository<Settings>>();
    }
}
