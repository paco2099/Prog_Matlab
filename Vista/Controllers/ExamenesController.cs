using Logica;
using Microsoft.AspNetCore.Mvc;
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
            Resultado salida = Logica.Examenes.examen1(matriz);

            if (salida.Correcto)
            {
                return Json(salida.Objecto);
            }
            else
            {
                return Json(salida.Mensaje);
            }
        }
    }
}
