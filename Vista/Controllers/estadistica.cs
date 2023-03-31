using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Vista.Controllers

//https://platzi.com/tutoriales/1352-ia/1313-calcular-cualquier-promedio-media-y-moda-de-una-lista-de-datos/
{
    public class Estadistica : Controller
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
            if (Regex.IsMatch(matriz, @"[\n]")) {
                var filas = new List<String>(matriz.Split('\n'));
                if (a == 1) {
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
                    var mean_filas = new List<double>();
                    for (int j = 0;j < filasHD.Count; j++)
                    {
                        if (j == 0)
                        {
                            continue;
                        }else if (filasHD[j].Count == filasHD[j - 1].Count)
                        {
                            continue;
                        }
                        else
                        {
                            return Json("Error 2: La matriz no es cuadrada. Favor ingresar una matriz cuadrada.");
                        }
                    }

                    //promedio de cada fila y añadrilo a mean_filas

                    for (int k = 0; k < filasHD.Count; k++) {
                        mean_filas.Add(filasHD[k].Average());
                    }
                    string mean = "";

                    for (int l = 0; l<mean_filas.Count; l++)
                    {
                        mean = mean + (String.Join(" ", mean_filas[l])) + "\n";
                    }
                    return Json(mean);
                }
                else if (a == 2)
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
                    //Transponer Matriz
                    var filasHDT = filasHD.SelectMany(inner => inner.Select((item, index) => new { item, index })).GroupBy(i => i.index, i => i.item).Select(g => g.ToList()).ToList();
                    var meanCol = new List<double>();

                    for (int i = 0; i < filasHDT.Count; i++)
                    {
                        if (meanCol.Count == 0)
                        {
                            meanCol.Add(filasHDT[i].Average());
                        }
                        else if (filasHDT[i - 1].Count == filasHDT[i].Count)
                        {
                            meanCol.Add(filasHDT[i].Average());
                        }
                        else
                        {
                            return Json("Error 2: La matriz no es cuadrada. Favor ingresar una matriz cuadrada.");
                        }

                    }

                    return Json(String.Join(" ", meanCol));
                }
                else
                {
                    return Json("Error");
                }
            }
            else
            {
                return Json("Error 1: Debe de ingresar una matriz cuadrada.");
            }
        }

        [HttpPost]
        public JsonResult median(string matriz, int a)
            //NO ESTÁ TERMINADO, FALTA CALCULAR LAS MEDIANA
        {
            if (Regex.IsMatch(matriz, @"[\n]"))
            {
                var filas = new List<String>(matriz.Split('\n'));
                if (a == 1)
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
                    var median_filas = new List<double>();
                    for (int j = 0; j < filasHD.Count; j++)
                    {
                        if (j == 0)
                        {
                            continue;
                        }
                        else if (filasHD[j].Count == filasHD[j - 1].Count)
                        {
                            continue;
                        }
                        else
                        {
                            return Json("Error 2: La matriz no es cuadrada. Favor ingresar una matriz cuadrada.");
                        }
                    }

                    //promedio de cada fila y añadrilo a mean_filas

                    for (int k = 0; k < filasHD.Count; k++)
                    {
                        median_filas.Add(filasHD[k].Average());
                    }
                    string median = "";

                    for (int l = 0; l < median_filas.Count; l++)
                    {
                        median = median + (String.Join(" ", median_filas[l])) + "\n";
                    }
                    return Json(median);
                }
                else if (a == 2)
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
                    //Transponer Matriz
                    var filasHDT = filasHD.SelectMany(inner => inner.Select((item, index) => new { item, index })).GroupBy(i => i.index, i => i.item).Select(g => g.ToList()).ToList();
                    var meanCol = new List<double>();

                    for (int i = 0; i < filasHDT.Count; i++)
                    {
                        if (meanCol.Count == 0)
                        {
                            meanCol.Add(filasHDT[i].Average());
                        }
                        else if (filasHDT[i - 1].Count == filasHDT[i].Count)
                        {
                            meanCol.Add(filasHDT[i].Average());
                        }
                        else
                        {
                            return Json("Error 2: La matriz no es cuadrada. Favor ingresar una matriz cuadrada.");
                        }

                    }

                    return Json(String.Join(" ", meanCol));
                }
                else
                {
                    return Json("Error");
                }
            }
            else
            {
                return Json("Error 1: Debe de ingresar una matriz cuadrada.");
            }
        }
    }
}
