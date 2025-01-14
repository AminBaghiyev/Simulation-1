using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace SimulationProject.BL.DTOs;

public record CardUpdateDTO
{
    public int Id { get; set; }

    [AllowNull]
    public IFormFile? Image { get; set; }

    [AllowNull]
    public string? ImagePath { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
