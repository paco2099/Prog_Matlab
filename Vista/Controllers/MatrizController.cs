using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            if (Regex.IsMatch(matriz, @"\d[^a-z]+\s+") && !(Regex.IsMatch(matriz, @"[a-z]+")))
            {
                var filas = new List<String>(matriz.Split('\n'));

                if (filas.Count == 1)
                {
                    try
                    {
                        var fila = new List<String>(filas[0].Split(' '));
                        var fila_int = fila.Select(int.Parse).ToList();
                        int valorMinimo = fila_int.Min();

                        return Json(valorMinimo.ToString());
                    }
                    catch (Exception)
                    {
                        return Json("Error: Ingrese los datos correctamente.");
                    }
                }
                else
                {
                    try
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
                    catch (Exception)
                    {
                        return Json("Error: Ingrese los datos correctamente.");
                    }
                    
                }
            } else
            {
                return Json("Error: Los datos ingresados no son numéricos.");
            }
        }

        public IActionResult Mink()
        {
            return View();
        }

        [HttpPost]
        public JsonResult mink(string matriz, int k)
        {
            if (Regex.IsMatch(matriz, @"\d[^a-z]+\s+") && !(Regex.IsMatch(matriz, @"[a-z]+")))
            {
                var filas = new List<String>(matriz.Split('\n'));

                if (filas.Count == 1)
                {
                    try
                    {
                        var fila = new List<String>(filas[0].Split(' '));
                        var fila_int = fila.Select(int.Parse).ToList();
                        fila_int = fila_int.OrderBy(number => number).ToList();
                        var val_min = new List<int>();

                        for (int i = 0; i < k; i++)
                        {
                            val_min.Add(fila_int[i]);
                        }
                        return Json(String.Join(" ", val_min));
                    }
                    catch (Exception)
                    {
                        return Json("Error: Ingrese los datos correctamente.");
                    }
                }
                else
                {
                    try
                    {
                        var filasHD = new List<List<int>>();

                        for (int i = 0; i < filas.Count; i++)
                        {
                            var fs = new List<String>(filas[i].Split(' '));
                            var fs_int = fs.Select(int.Parse).ToList();
                            fs_int = fs_int.OrderBy(number => number).ToList();

                            var min = new List<int>();
                            for (int j = 0; j < k; j++)
                            {
                                min.Add(fs_int[j]);
                            }
                            filasHD.Add(min);
                        }


                        string val_min = "";

                        for (int i = 0; i < filasHD.Count; i++)
                        {
                            val_min = val_min + (String.Join(" ", filasHD[i])) + "\n";
                        }

                        return Json(val_min);
                    }
                    catch (Exception)
                    {
                        return Json("Error: Ingrese los datos correctamente.");
                    }
                }
            }
            else
            {
                return Json("Error: Los datos ingresados no son numéricos.");
            }
        }
    }
}
