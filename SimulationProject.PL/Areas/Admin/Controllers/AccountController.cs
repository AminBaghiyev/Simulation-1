using Microsoft.AspNetCore.Mvc;
using SimulationProject.BL.DTOs;
using SimulationProject.BL.Services.Abstractions;
using SimulationProject.Core.Enums;

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
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            return Redirect(User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/");
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AppUserLoginDTO dto, string? returnUrl = null)
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
        
        return Redirect(returnUrl ?? (User.IsInRole(Roles.Admin.ToString()) ? "/admin" : "/"));
    }

    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();

        return RedirectToAction(nameof(Login));
    }
}
