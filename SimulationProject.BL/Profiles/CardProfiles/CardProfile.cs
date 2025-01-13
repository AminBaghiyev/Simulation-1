using AutoMapper;
using SimulationProject.BL.DTOs;
using SimulationProject.Core.Models;

namespace SimulationProject.BL.Profiles;

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<CardCreateDTO, Card>().ReverseMap();
        CreateMap<CardUpdateDTO, Card>().ReverseMap();
        CreateMap<CardListItemDTO, Card>().ReverseMap();
    }
}
