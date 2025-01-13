using Microsoft.AspNetCore.Http;

namespace SimulationProject.BL.DTOs;

public record CardUpdateDTO
{
    public int Id { get; set; }
    public IFormFile Image { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
