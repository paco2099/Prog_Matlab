using Microsoft.AspNetCore.Mvc;


namespace Vista.Controllers
{
    public class MatrizController : Controller
    {
        public IActionResult Tarea1()
        {
            return View();
        }

        [HttpPost]
        public JsonResult min(string matriz)
        {
            string respuesta = Logica.Matriz.min(matriz);

            return Json(respuesta);
        }

        public IActionResult Mink()
        {
            return View();
        }

        [HttpPost]
        public JsonResult mink(string matriz, int k)
        {
            string salida = Logica.Matriz.mink(matriz, k);

            return Json(salida);
        }

        public IActionResult Max()
        {
            return View();
        }

        [HttpPost]
        public JsonResult max(string matriz)
        {
            string salida = Logica.Matriz.max(matriz);

            return Json(salida);
        }

        public IActionResult Maxk()
        {
            return View();
        }

        [HttpPost]
        public JsonResult maxk(string matriz, int k)
        {
            string salida = Logica.Matriz.maxk(matriz, k);
            return Json(salida);
        }

        public IActionResult Randi()
        {
            return View();
        }

        [HttpPost]
        public JsonResult randi(int rango, int filas, int col)
        {
           string salida = Logica.Matriz.randi(rango, filas, col);
            return Json(salida);
        }
    }
}

