﻿using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Vista.Controllers
{
    public class ExamenesController : Controller
    {
        public IActionResult Exam1()
        {
            return View();
        }

        [HttpPost]
        public JsonResult examen1(string matriz)
        {
            string salida = Logica.Examenes.examen1(matriz);
            return Json(salida);
        }
    }
}
