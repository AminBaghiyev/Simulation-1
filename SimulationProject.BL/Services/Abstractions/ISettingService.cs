using SimulationProject.BL.DTOs;

namespace SimulationProject.BL.Services.Abstractions;

public interface ISettingService
{
    Task<SettingsDTO> GetSettingsAsync();
    void UpdateSettings(SettingsDTO dto);
    Task<int> SaveChangesAsync();
}
