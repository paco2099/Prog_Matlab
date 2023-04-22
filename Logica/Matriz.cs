﻿using System.Text.RegularExpressions;
using MathNet.Numerics.LinearAlgebra;

namespace Logica
{
    public class Matriz
    {
        public static string min(string matriz)
        {
            if (Regex.IsMatch(matriz, @"^[\s*-?0-9]") && !(Regex.IsMatch(matriz, @"[a-z]+")))
            {
                var filas = new List<String>(matriz.Split('\n'));

                if (filas.Count == 1)
                {
                    try
                    {
                        var fila = new List<String>(Regex.Split(filas[0], @"\s+"));
                        if (String.IsNullOrEmpty(fila[fila.Count - 1]))
                        {
                            fila.RemoveAt(fila.Count - 1);
                        }
                        if (String.IsNullOrEmpty(fila[0]))
                        {
                            fila.RemoveAt(0);
                        }
                        var fila_int = fila.Select(int.Parse).ToList();
                        int valorMinimo = fila_int.Min();

                        return valorMinimo.ToString();
                    }
                    catch (Exception)
                    {
                        return "Error: Ingrese los datos correctamente.";
                    }
                }
                else
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

                    var filasHDT = filasHD.SelectMany(inner => inner.Select((item, index) => new { item, index })).GroupBy(i => i.index, i => i.item).Select(g => g.ToList()).ToList();
                    var minCol = new List<int>();
                    try
                    {

                        for (int i = 0; i < filasHDT.Count; i++)
                        {
                            if (minCol.Count == 0)
                            {
                                minCol.Add(filasHDT[i].Min());
                            }
                            else if (filasHDT[i - 1].Count == filasHDT[i].Count)
                            {
                                minCol.Add(filasHDT[i].Min());
                            }
                            else
                            {
                                return "Error: Las matrices tienen que tener el mismo tamaño.";
                            }

                        }

                        return String.Join(" ", minCol);
                    }
                    catch (Exception)
                    {
                        return "Error: Las matrices tienen que tener el mismo tamaño.";
                    }

                }
            }
            else
            {
                return "Error: Los datos ingresados no son numéricos.";
            }
        }

        public static string mink(string matriz, int k)
        {
            if (Regex.IsMatch(matriz, @"^[\s*-?0-9]") && !(Regex.IsMatch(matriz, @"[a-z]+")))
            {
                var filas = new List<String>(matriz.Split('\n'));

                if (filas.Count == 1)
                {
                    try
                    {
                        var fila = new List<String>(Regex.Split(filas[0], @"\s+"));
                        if (String.IsNullOrEmpty(fila[fila.Count - 1]))
                        {
                            fila.RemoveAt(fila.Count - 1);
                        }
                        if (String.IsNullOrEmpty(fila[0]))
                        {
                            fila.RemoveAt(0);
                        }
                        var fila_int = fila.Select(int.Parse).ToList();
                        fila_int = fila_int.OrderBy(number => number).ToList();
                        var val_min = new List<int>();
                        if (fila_int.Count > k)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                val_min.Add(fila_int[i]);
                            }
                            return String.Join(" ", val_min);
                        }
                        else
                        {
                            return "Error: El valor de K excede al tamaño de la matriz";
                        }

                    }
                    catch (Exception)
                    {
                        return "Error: Ingrese los datos correctamente.";
                    }
                }
                else
                {
                    try
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
                            if (filasHD.Count == 0)
                            {//aaaaaaaaaaaaaaaaaaaaaaaaa
                                var fs_int = fs.Select(int.Parse).ToList();
                                fs_int = fs_int.OrderBy(number => number).ToList();
                                var min = new List<int>();
                                if (fs_int.Count > k)
                                {
                                    for (int j = 0; j < k; j++)
                                    {
                                        min.Add(fs_int[j]);
                                    }
                                    filasHD.Add(min);
                                }
                                else
                                {
                                    return "Error: El valor de K excede al tamaño de la matriz";
                                }
                            }
                        }


                        string val_min = "";

                        for (int i = 0; i < filasHD.Count; i++)
                        {
                            val_min = val_min + (String.Join(" ", filasHD[i])) + "\n";
                        }

                        return val_min;
                    }
                    catch (Exception)
                    {
                        return "Error: Ingrese los datos correctamente.";
                    }
                }
            }
            else
            {
                return "Error: Los datos ingresados no son numéricos.";
            }
        }

        public static string max(string matriz) {
            if (Regex.IsMatch(matriz, @"^[\s*-?0-9]") && !(Regex.IsMatch(matriz, @"[a-z]+")))
            {
                var filas = new List<String>(matriz.Split('\n'));

                if (filas.Count == 1)
                {
                    try
                    {
                        var fila = new List<String>(filas[0].Split(' '));
                        var fila_int = fila.Select(int.Parse).ToList();
                        int valorMax = fila_int.Max();

                        return valorMax.ToString();
                    }
                    catch (Exception)
                    {
                        return "Error: Ingrese los datos correctamente.";
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
                        var maxCol = new List<int>();

                        for (int i = 0; i < filasHDT.Count; i++)
                        {
                            maxCol.Add(filasHDT[i].Max());
                        }

                        return String.Join(" ", maxCol);
                    }
                    catch (Exception)
                    {
                        return "Error: Ingrese los datos correctamente.";
                    }

                }
            }
            else
            {
                return "Error: Los datos ingresados no son numéricos.";
            }
        }

        public static string maxk(string matriz, int k)
        {
            if (Regex.IsMatch(matriz, @"^[\s*-?0-9]") && !(Regex.IsMatch(matriz, @"[a-z]+")))
            {
                var filas = new List<String>(matriz.Split('\n'));

                if (filas.Count == 1)
                {
                    try
                    {
                        var fila = new List<String>(filas[0].Split(' '));
                        var fila_int = fila.Select(int.Parse).ToList();
                        fila_int = fila_int.OrderByDescending(number => number).ToList();
                        var val_max = new List<int>();

                        for (int i = 0; i < k; i++)
                        {
                            val_max.Add(fila_int[i]);
                        }
                        return String.Join(" ", val_max);
                    }
                    catch (Exception)
                    {
                        return "Error: Ingrese los datos correctamente.";
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
                            fs_int = fs_int.OrderByDescending(number => number).ToList();

                            var max = new List<int>();
                            for (int j = 0; j < k; j++)
                            {
                                max.Add(fs_int[j]);
                            }
                            filasHD.Add(max);
                        }


                        string val_max = "";

                        for (int i = 0; i < filasHD.Count; i++)
                        {
                            val_max = val_max + (String.Join(" ", filasHD[i])) + "\n";
                        }

                        return val_max;
                    }
                    catch (Exception)
                    {
                        return "Error: Ingrese los datos correctamente.";
                    }
                }
            }
            else
            {
                return "Error: Los datos ingresados no son numéricos.";
            }
        }

        public static string randi(int rango, int filas, int col)
        {
            Matrix<double> matriz = Matrix<double>.Build.Dense(filas, col);
            Random rnd = new Random();
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matriz[i, j] = rnd.Next(rango);
                }
            }

            var vArray = matriz.ToArray();

            // Convertir matriz a string de salida

            string salida = "";
            for (int i = 0; i < vArray.GetLength(0); i++)
            {
                string filaX = "";
                for (int j = 0; j < vArray.GetLength(1); j++)
                {
                    filaX = filaX + vArray[i, j] + " ";
                }
                salida += filaX + '\n';
            }

            return salida;
        }
    }
}