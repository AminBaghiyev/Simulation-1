using Microsoft.Extensions.Configuration;

namespace SimulationProject.DL.Utilities;

public class Connection
{
    public static string GetConnectionString(string key)
    {
        string? connectionString = Environment.GetEnvironmentVariable(key);

        if (connectionString is not null) return connectionString;

        ConfigurationManager manager = new();

        manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "SimulationProject.PL"));
        manager.AddJsonFile("appsettings.json");

        return
            manager.GetConnectionString(key) ?? throw new Exception("Connection string not found!");
    }
}
