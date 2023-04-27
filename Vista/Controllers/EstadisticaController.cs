using Logica;
using Microsoft.AspNetCore.Mvc;
namespace Vista.Controllers

//https://platzi.com/tutoriales/1352-ia/1313-calcular-cualquier-promedio-media-y-moda-de-una-lista-de-datos/
{
    public class EstadisticaController : Controller
    {
        public IActionResult Mean()
        {
            return View();
        }

        public IActionResult Median()
        {
            return View();
        }

        [HttpPost]
        public JsonResult mean(string matriz, int a) {
            Resultado salida = Logica.Estadistica.mean(matriz, a);
            
            if (salida.Correcto)
            {
                return Json(salida.Objecto);
            }
            else
            {
                return Json(salida.Mensaje);
            }
        }

        [HttpPost]
        public JsonResult median(string matriz, int a)
        {
            Resultado salida = Logica.Estadistica.median(matriz, a);

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
