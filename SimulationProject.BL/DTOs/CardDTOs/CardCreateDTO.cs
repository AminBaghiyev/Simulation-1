using Microsoft.AspNetCore.Http;

namespace SimulationProject.BL.DTOs;

public record CardCreateDTO
{
    public IFormFile Image { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
