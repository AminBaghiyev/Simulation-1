using Microsoft.AspNetCore.Mvc;
using SimulationProject.BL.DTOs;
using SimulationProject.BL.Services.Abstractions;

namespace SimulationProject.PL.Areas.Admin.Controllers;

[Area("Admin")]
public class AccountController : Controller
{
    readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(AppUserLoginDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _accountService.LoginAsync(dto);
        }
        catch (Exception)
        {
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }

        return RedirectToAction("Index", "Dashboard");
    }

    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();

        return RedirectToAction(nameof(Login));
    }
}
