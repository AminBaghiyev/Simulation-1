using SimulationProject.BL.DTOs;

namespace SimulationProject.BL.Services.Abstractions;

public interface IAccountService
{
    Task LoginAsync(AppUserLoginDTO dto);

    Task LogoutAsync();
}
