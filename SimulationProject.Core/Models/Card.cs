using SimulationProject.Core.Models.Base;

namespace SimulationProject.Core.Models;

public class Card : BaseAuditableEntity
{
    public string ImagePath { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
