using AutoMapper;
using SimulationProject.BL.DTOs;
using SimulationProject.Core.Models;

namespace SimulationProject.BL.Profiles;

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<CardViewItem, Card>().ReverseMap();
        CreateMap<CardCreateDTO, Card>().ReverseMap();
        CreateMap<CardUpdateDTO, Card>().ReverseMap();
        CreateMap<CardListItemDTO, Card>().ReverseMap();
    }
}
