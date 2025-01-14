using Microsoft.AspNetCore.Mvc;
using SimulationProject.BL.Services.Abstractions;
using SimulationProject.PL.ViewModels;

namespace SimulationProject.PL.Controllers;

public class HomeController : Controller
{
    readonly ISettingService _settingService;
    readonly ICardService _cardService;

    public HomeController(ISettingService settingService, ICardService cardService)
    {
        _settingService = settingService;
        _cardService = cardService;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM VM = new()
        {
            Settings = await _settingService.GetSettingsAsync(),
            Cards = await _cardService.GetAllActiveAsync()
        };

        return View(VM);
    }
}
