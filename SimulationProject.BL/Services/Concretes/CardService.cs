using AutoMapper;
using SimulationProject.BL.DTOs;
using SimulationProject.BL.Exceptions;
using SimulationProject.BL.Services.Abstractions;
using SimulationProject.Core.Models;
using SimulationProject.DL.Repositories.Implementations;

namespace SimulationProject.BL.Services.Concretes;

public class CardService : ICardService
{
    readonly IReadRepository<Card> _readRepository;
    readonly IWriteRepository<Card> _writeRepository;
    readonly IMapper _mapper;

    public CardService(IReadRepository<Card> readRepository, IWriteRepository<Card> writeRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CardCreateDTO dto, string username)
    {
        Card card = _mapper.Map<Card>(dto);
        card.CreatedBy = username;
        card.CreatedAt = DateTime.UtcNow.AddHours(4);

        await _writeRepository.CreateAsync(card);
    }

    public async Task<ICollection<CardListItemDTO>> GetAllAsync(int page, int count = 5)
    {
        return _mapper.Map<ICollection<CardListItemDTO>>(await _readRepository.GetAllAsync(page: page, count: count));
    }

    public async Task<Card> GetByIdAsync(int id)
    {
        return await _readRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException();
    }

    public async Task HardDeleteAsync(int id)
    {
        Card card = await GetByIdAsync(id);

        _writeRepository.Delete(card);
    }

    public async Task RecoverAsync(int id)
    {
        Card card = await GetByIdAsync(id);
        card.IsDeleted = false;
        card.DeletedAt = null;
        card.DeletedBy = null;

        _writeRepository.Update(card);
    }

    public async Task SoftDeleteAsync(int id, string username)
    {
        Card card = await GetByIdAsync(id);
        card.IsDeleted = true;
        card.DeletedAt = DateTime.UtcNow.AddHours(4);
        card.DeletedBy = username;

        _writeRepository.Update(card);
    }

    public Task UpdateAsync(CardUpdateDTO dto, string username)
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveChangesAsync() => await _writeRepository.SaveChangesAsync();
}
