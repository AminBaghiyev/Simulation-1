using AutoMapper;
using SimulationProject.BL.DTOs;
using SimulationProject.BL.Services.Abstractions;
using SimulationProject.Core.Models;
using SimulationProject.DL.Repositories.Implementations;

namespace SimulationProject.BL.Services.Concretes;

public class SettingService : ISettingService
{
    readonly IReadRepository<Settings> _readRepository;
    readonly IWriteRepository<Settings> _writeRepository;
    readonly IMapper _mapper;

    public SettingService(IWriteRepository<Settings> writeRepository, IReadRepository<Settings> readRepository, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<SettingsDTO> GetSettingsAsync()
    {
        return _mapper.Map<SettingsDTO>(await _readRepository.GetByIdAsync(1));
    }

    public void UpdateSettings(SettingsDTO dto)
    {
        Settings settings = _mapper.Map<Settings>(dto);
        settings.Id = 1;

        _writeRepository.Update(settings);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _writeRepository.SaveChangesAsync();
    }
}
