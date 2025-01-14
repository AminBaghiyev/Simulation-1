using SimulationProject.BL.DTOs;
using SimulationProject.Core.Models;

namespace SimulationProject.BL.Services.Abstractions;

public interface ICardService
{
    int Count();
    Task<Card> GetByIdAsync(int id);
    Task<ICollection<CardListItemDTO>> GetAllAsync(int page, int count = 5);
    Task<ICollection<CardViewItem>> GetAllActiveAsync(int page= 0, int count = 3);
    Task CreateAsync(CardCreateDTO dto, string username);
    Task UpdateAsync(CardUpdateDTO dto, string username);
    Task SoftDeleteAsync(int id, string username);
    Task RecoverAsync(int id);
    Task HardDeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
