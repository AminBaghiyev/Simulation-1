using SimulationProject.BL.DTOs;

namespace SimulationProject.PL.ViewModels;

public class HomeVM
{
    public SettingsDTO Settings { get; set; }

    public IEnumerable<CardViewItem> Cards { get; set; }
}
