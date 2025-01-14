using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimulationProject.BL.DTOs;
using SimulationProject.BL.Services.Abstractions;

namespace SimulationProject.PL.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class SettingsController : Controller
{
    readonly ISettingService _service;

    public SettingsController(ISettingService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _service.GetSettingsAsync());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(SettingsDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            _service.UpdateSettings(dto);
            await _service.SaveChangesAsync();
        }
        catch (Exception)
        {
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }

        return View(dto);
    }
}
