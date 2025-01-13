using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SimulationProject.BL.Services.Abstractions;
using SimulationProject.BL.Services.Concretes;
using System.Reflection;

namespace SimulationProject.BL;

public static class ConfigurationServices
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ISettingService, SettingService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
    }
}
