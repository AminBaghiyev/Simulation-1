namespace SimulationProject.BL.DTOs;

public record CardListItemDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
}
