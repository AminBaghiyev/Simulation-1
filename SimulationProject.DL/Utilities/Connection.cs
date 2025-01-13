using Microsoft.Extensions.Configuration;

namespace SimulationProject.DL.Utilities;

public class Connection
{
    public static string GetConnectionString()
    {
        ConfigurationManager manager = new();

        manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "SimulationProject.PL"));
        manager.AddJsonFile("appsettings.json");

        return
            manager.GetConnectionString("MsSql") ?? throw new Exception("Connection string not found!");
    }
}
