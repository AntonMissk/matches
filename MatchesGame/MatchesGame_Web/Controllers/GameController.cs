﻿using Microsoft.AspNetCore.Mvc;

namespace MatchesGame_Web.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
