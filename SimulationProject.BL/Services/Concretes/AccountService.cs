using Microsoft.AspNetCore.Identity;
using SimulationProject.BL.DTOs;
using SimulationProject.BL.Exceptions;
using SimulationProject.BL.Services.Abstractions;
using SimulationProject.Core.Models;

namespace SimulationProject.BL.Services.Concretes;

public class AccountService : IAccountService
{
    readonly UserManager<AppUser> _userManager;
    readonly SignInManager<AppUser> _signInManager;

    public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task LoginAsync(AppUserLoginDTO dto)
    {
        AppUser user = await _userManager.FindByNameAsync(dto.UserName) ?? throw new EntityNotFoundException();

        SignInResult res = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, true);

        if (!res.Succeeded) throw new Exception();
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
