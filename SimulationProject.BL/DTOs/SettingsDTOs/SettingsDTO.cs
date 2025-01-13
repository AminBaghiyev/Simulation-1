using System.ComponentModel.DataAnnotations;

namespace SimulationProject.BL.DTOs;

public record SettingsDTO
{
    [Display(Prompt = "Address")]
    public string? Address { get; set; }

    [Display(Prompt = "Email")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Display(Prompt = "Phone number")]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    [Display(Prompt = "Twitter URL")]
    public string? TwitterURL { get; set; }

    [Display(Prompt = "Facebook URL")]
    public string? FacebookURL { get; set; }

    [Display(Prompt = "Instagram URL")]
    public string? InstagramURL { get; set; }

    [Display(Prompt = "LinkedIn URL")]
    public string? LinkedinURL { get; set; }
}
