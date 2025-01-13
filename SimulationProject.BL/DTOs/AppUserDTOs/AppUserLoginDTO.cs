using System.ComponentModel.DataAnnotations;

namespace SimulationProject.BL.DTOs;

public class AppUserLoginDTO
{
    [Display(Prompt = "Username")]
    public string UserName { get; set; }

    [Display(Prompt = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}
