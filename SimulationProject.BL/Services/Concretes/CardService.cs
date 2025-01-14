using AutoMapper;
using SimulationProject.BL.DTOs;
using SimulationProject.BL.Exceptions;
using SimulationProject.BL.Services.Abstractions;
using SimulationProject.BL.Utilities;
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
        if (!dto.Image.CheckType("image")) throw new TypeMustBeImageException();

        Card card = _mapper.Map<Card>(dto);
        card.CreatedBy = username;
        card.CreatedAt = DateTime.UtcNow.AddHours(4);
        card.ImagePath = await dto.Image.SaveAsync(Path.GetFullPath("wwwroot"), "cards");

        await _writeRepository.CreateAsync(card);
    }

    public int Count() => _readRepository.Table.Count();

    public async Task<ICollection<CardListItemDTO>> GetAllAsync(int page, int count = 5)
    {
        return _mapper.Map<ICollection<CardListItemDTO>>(await _readRepository.GetAllAsync(page: page, count: count));
    }

    public async Task<ICollection<CardViewItem>> GetAllActiveAsync(int page = 0, int count = 3)
    {
        return _mapper.Map<ICollection<CardViewItem>>(await _readRepository.GetAllAsync(e => !e.IsDeleted, page, count, false));
    }

    public async Task<Card> GetByIdAsync(int id)
    {
        return await _readRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException();
    }

    public async Task HardDeleteAsync(int id)
    {
        Card card = await GetByIdAsync(id);

        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "cards", card.ImagePath));

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

    public async Task UpdateAsync(CardUpdateDTO dto, string username)
    {
        if (dto.Image is not null && !dto.Image.CheckType("image")) throw new TypeMustBeImageException();

        Card oldCard = await GetByIdAsync(dto.Id);
        Card card = _mapper.Map<Card>(dto);
        card.CreatedBy = oldCard.CreatedBy;
        card.CreatedAt = oldCard.CreatedAt;
        card.UpdatedBy = username;
        card.UpdatedAt = DateTime.UtcNow.AddHours(4);
        card.DeletedBy = oldCard.DeletedBy;
        card.DeletedAt = oldCard.DeletedAt;

        card.ImagePath = dto.Image is not null ?
            await dto.Image.SaveAsync(Path.GetFullPath("wwwroot"), "cards") :
            oldCard.ImagePath;

        _writeRepository.Update(card);

        if (dto.Image is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "cards", oldCard.ImagePath));
    }

    public async Task<int> SaveChangesAsync() => await _writeRepository.SaveChangesAsync();
}
