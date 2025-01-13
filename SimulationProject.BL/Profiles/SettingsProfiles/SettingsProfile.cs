using AutoMapper;
using SimulationProject.BL.DTOs;
using SimulationProject.Core.Models;

namespace SimulationProject.BL.Profiles;

public class SettingsProfile : Profile
{
    public SettingsProfile()
    {
        CreateMap<SettingsDTO, Settings>().ReverseMap();
    }
}
