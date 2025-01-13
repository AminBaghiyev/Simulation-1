using Microsoft.AspNetCore.Http;

namespace SimulationProject.BL.DTOs;

public record CardListItemDTO
{
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
}
