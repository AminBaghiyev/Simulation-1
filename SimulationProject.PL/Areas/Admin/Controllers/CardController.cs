using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimulationProject.BL.DTOs;
using SimulationProject.BL.Exceptions;
using SimulationProject.BL.Services.Abstractions;

namespace SimulationProject.PL.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CardController : Controller
{
    readonly ICardService _service;
    readonly IMapper _mapper;

    public CardController(ICardService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(int page = 0, int count = 3)
    {
        IEnumerable<CardListItemDTO> list = await _service.GetAllAsync(page, count);
        ViewData["Page"] = page;
        ViewData["TotalCount"] = _service.Count();

        return View(list);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CardCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _service.CreateAsync(dto, User.Identity.Name);
            await _service.SaveChangesAsync();
        }
        catch (TypeMustBeImageException ex)
        {
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        try
        {
            return View(_mapper.Map<CardUpdateDTO>(await _service.GetByIdAsync(id)));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CardUpdateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _service.UpdateAsync(dto, User.Identity.Name);
            await _service.SaveChangesAsync();
        }
        catch (TypeMustBeImageException ex)
        {
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> HardDelete(int id)
    {
        try
        {
            await _service.HardDeleteAsync(id);
            await _service.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest();
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> SoftDelete(int id)
    {
        try
        {
            await _service.SoftDeleteAsync(id, User.Identity.Name);
            await _service.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest();
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Recover(int id)
    {
        try
        {
            await _service.RecoverAsync(id);
            await _service.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest();
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            return View(await _service.GetByIdAsync(id));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
