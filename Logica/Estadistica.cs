using System.Text.RegularExpressions;

namespace Logica
{
    public class Estadistica
    {
        public static Resultado mean(string matriz, int a)
        {
            Resultado resultado = new Resultado();

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
                    var mean_filas = new List<double>();
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
                            resultado.Correcto = false;
                            resultado.Mensaje = "Error 2: La matriz no es cuadrada. Favor ingresar una matriz cuadrada.";
                            return resultado;
                        }
                    }

                    //promedio de cada fila y añadrilo a mean_filas

                    for (int k = 0; k < filasHD.Count; k++)
                    {
                        mean_filas.Add(filasHD[k].Average());
                    }
                    string mean = "";

                    for (int l = 0; l < mean_filas.Count; l++)
                    {
                        mean = mean + (String.Join(" ", mean_filas[l])) + "\n";
                    }

                    resultado.Correcto = true;
                    resultado.Objecto = mean;
                    return resultado;
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
                            resultado.Correcto = false;
                            resultado.Mensaje = "Error 2: La matriz no es cuadrada. Favor ingresar una matriz cuadrada.";
                            return resultado;
                        }

                    }

                    resultado.Correcto = true;
                    resultado.Objecto = String.Join(" ", meanCol);
                    return resultado;
                }
                else
                {
                    resultado.Correcto = false;
                    resultado.Mensaje = "Error";
                    return resultado;
                }
            }
            else
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Error 1: Debe de ingresar una matriz cuadrada.";
                return resultado;
            }
        }
    
        public static Resultado median(string matriz, int a)
        {
            Resultado resultado = new Resultado();

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
                                resultado.Correcto = false;
                                resultado.Mensaje = "Error 2: La matriz no es cuadrada. Favor ingresar una matriz cuadrada.";
                                return resultado;
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

                        resultado.Correcto = true;
                        resultado.Objecto = median;
                        return resultado;
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
                                resultado.Correcto = false;
                                resultado.Mensaje = "Error 2: La matriz no es cuadrada. Favor ingresar una matriz cuadrada.";
                                return resultado;
                            }

                        }

                        resultado.Correcto = true;
                        resultado.Objecto = String.Join(" ", meanCol);
                        return resultado;
                    }
                    else
                    {
                        resultado.Correcto = false;
                        resultado.Mensaje = "Error";
                        return resultado;
                    }
                }
                else
                {
                    resultado.Correcto = false;
                    resultado.Mensaje = "Error 1: Debe de ingresar una matriz cuadrada.";
                    return resultado;
                }
            }
        }
    }
}
