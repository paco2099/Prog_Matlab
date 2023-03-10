using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Vista.Controllers
{
    public class MatrizController : Controller
    {
        public IActionResult Tarea1(){
            return View();
        }
        [HttpPost]
        public JsonResult min(string matriz)
        {
            var filas = new List<String>(matriz.Split('\n'));

            if (filas.Count == 1) {
                var fila = new List<String>(filas[0].Split(' '));
                var fila_int = fila.Select(int.Parse).ToList();
                int valorMinimo = fila_int.Min();
                return Json(valorMinimo.ToString());
            }
            else
            {
                var filasHD = new List<List<int>>();

                for (int i = 0; i < filas.Count; i++)
                {
                    var fs = new List<String>(filas[i].Split(' '));
                    var fs_int = fs.Select(int.Parse).ToList();
                    filasHD.Add(fs_int);
                }

                var filasHDT = filasHD.SelectMany(inner => inner.Select((item, index) => new { item, index })).GroupBy(i => i.index, i => i.item).Select(g => g.ToList()).ToList();
                var minCol = new List<int>();

                for (int i = 0; i < filasHDT.Count; i++)
                {
                    minCol.Add(filasHDT[i].Min());
                }

                return Json(String.Join(" ", minCol));
            }
        }

        
    }
}
