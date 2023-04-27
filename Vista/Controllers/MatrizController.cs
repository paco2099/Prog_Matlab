using Logica;
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
            Resultado rest = Logica.Matriz.min(matriz);

            if (rest.Correcto)
            {
                return Json(rest.Objecto);
            }
            else
            {
                return Json(rest.Mensaje);
            }
                        
        }

        public IActionResult Mink()
        {
            return View();
        }

        [HttpPost]
        public JsonResult mink(string matriz, int k)
        {
            Resultado salida = Logica.Matriz.mink(matriz, k);

            if (salida.Correcto)
            {
                return Json(salida.Objecto);
            } else
            {
                return Json(salida.Mensaje);
            }
        }

        public IActionResult Max()
        {
            return View();
        }

        [HttpPost]
        public JsonResult max(string matriz)
        {
            Resultado salida = Logica.Matriz.max(matriz);

            if (salida.Correcto)
            {
                return Json(salida.Objecto);
            }
            else
            {
                return Json(salida.Mensaje);
            }
        }

        public IActionResult Maxk()
        {
            return View();
        }

        [HttpPost]
        public JsonResult maxk(string matriz, int k)
        {
            Resultado salida = Logica.Matriz.maxk(matriz, k);

            if (salida.Correcto)
            {
                return Json(salida.Objecto);
            }
            else
            {
                return Json(salida.Mensaje);
            }
        }

        public IActionResult Randi()
        {
            return View();
        }

        [HttpPost]
        public JsonResult randi(int rango, int filas, int col)
        {
           Resultado salida = Logica.Matriz.randi(rango, filas, col);
           
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

