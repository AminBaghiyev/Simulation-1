﻿using Microsoft.AspNetCore.Mvc;

namespace SimulationProject.PL.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
