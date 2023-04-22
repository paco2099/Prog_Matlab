using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

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
            string salida = Logica.Alg_Lineal.mldivide(m1, m2);
            return Json(salida);
        }
    }
}
