using Microsoft.AspNetCore.Mvc;
using Logica;
namespace Vista.Controllers
{
    public class Alg_linController : Controller
    {
        public IActionResult mldivide()
        {
            return View();
        }

        [HttpPost]
        public JsonResult mldiv(string m1, string m2)
        {
            Resultado salida = Logica.Alg_Lineal.mldivide(m1, m2);

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
