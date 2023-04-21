using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Vista.Controllers
{
    public class Alg_lin : Controller
    {
        public IActionResult mldivide()
        {
            return View();
        }

        [HttpPost]
        public JsonResult mldiv(string m1, string m2)
        {
            if (Regex.IsMatch(m1, @"^[\s*-?0-9]") && (Regex.IsMatch(m2, @"^[\s*-?0-9]"))) {

                AlgLin al = new AlgLin();

                string vector_final = al.mldivide(m1, m2);
                return Json(vector_final);

            } else
            {
                return Json("Error de back: Los datos tienen que ser numéricos.");
            }
        }
    }
}
