using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Vista.Controllers
{
    public class estadistica : Controller
    {
        public IActionResult Mean()
        {
            return View();
        }

        //https://www.youtube.com/watch?v=YDRFeAAfPLs&ab_channel=JohnOrtizOrdo%C3%B1ez

        [HttpPost]
        public JsonResult mean(string matriz, int a)
        {
            if (Regex.IsMatch(matriz, @"[\n]")) {
                var filas = new List<String>(matriz.Split('\n'));
                if (a == 2)
                {
                    var filasHD = new List<List<int>>();
                    for (int i = 0; i < filas.Count; i++)
                    {
                        var fs = new List<String>(Regex.Split(filas[i], @"\s+"));
                        if (String.IsNullOrEmpty(fs[fs.Count - 1]))
                        {
                            fs.RemoveAt(fs.Count - 1);
                        }
                        if (String.IsNullOrEmpty(fs[0]))
                        {
                            fs.RemoveAt(0);
                        }
                        var fs_int = fs.Select(int.Parse).ToList();
                        filasHD.Add(fs_int);
                    }
                    var mean_filas = new List<int>();
                    for (int j = 0;j < filasHD.Count; j++)
                    {
                        if (j == 0)
                        {
                            continue;
                        }else if (filasHD[j].Count == filasHD[j - 1].Count)
                        {
                            return Json("Error 2: La matriz no es cuadrada. Favor ingresar una matriz cuadrada.");
                        }
                    }
                    return Json("XD");
                }
                else
                {
                    return Json("Aqui sale pero con columnas XD");
                }
            }
            else
            {
                return Json("Error 1: Debe de ingresar una matrz cuadrada.");
            }
        }
    }
}
