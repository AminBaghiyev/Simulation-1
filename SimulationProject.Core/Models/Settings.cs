using SimulationProject.Core.Models.Base;

namespace SimulationProject.Core.Models;

public class Settings : BaseEntity
{
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? TwitterURL { get; set; }
    public string? FacebookURL { get; set; }
    public string? InstagramURL { get; set; }
    public string? LinkedinURL { get; set; }
}
