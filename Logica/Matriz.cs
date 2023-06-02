using System;
using System.Text.RegularExpressions;
using MathNet.Numerics.LinearAlgebra;

namespace Logica
{
    public class Matriz
    {
        public static Modelo.Resultado min(string matriz)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

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

                        resultado.Correcto = true;
                        resultado.Objecto = valorMinimo.ToString();
                        return resultado;
                    }
                    catch (Exception)
                    {
                        resultado.Correcto = false;
                        resultado.Mensaje = "Error: Ingrese los datos correctamente.";
                        return resultado;
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
                                resultado.Correcto = false;
                                resultado.Mensaje = "Error: Las matrices tienen que tener el mismo tamaño.";
                                return resultado;
                            }

                        }
                        resultado.Correcto = true;
                        resultado.Objecto = String.Join(" ", minCol);
                        return resultado;
                    }
                    catch (Exception)
                    {
                        resultado.Correcto=false;
                        resultado.Mensaje = "Error: Las matrices tienen que tener el mismo tamaño.";
                        return resultado;
                    }

                }
            }
            else
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Error: Los datos ingresados no son numéricos.";
                return resultado;
            }
        }

        public static Modelo.Resultado mink(string matriz, int k)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

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
                            resultado.Correcto = true;
                            resultado.Objecto = String.Join(" ", val_min);
                            return resultado;
                        }
                        else
                        {
                            resultado.Correcto = false;
                            resultado.Mensaje = "Error: El valor de K excede al tamaño de la matriz";
                            return resultado;
                        }

                    }
                    catch (Exception)
                    {
                        resultado.Correcto= false;
                        resultado.Mensaje = "Error: Ingrese los datos correctamente.";
                        return resultado;
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
                                    resultado.Correcto = false;
                                    resultado.Mensaje = "Error: El valor de K excede al tamaño de la matriz";
                                    return resultado;
                                }
                            }
                        }


                        string val_min = "";

                        for (int i = 0; i < filasHD.Count; i++)
                        {
                            val_min = val_min + (String.Join(" ", filasHD[i])) + "\n";
                        }

                        resultado.Correcto = true;
                        resultado.Objecto = val_min;
                        return resultado;
                    }
                    catch (Exception)
                    {
                        resultado.Correcto =false;
                        resultado.Mensaje = "Error: Ingrese los datos correctamente.";
                        return resultado;
                    }
                }
            }
            else
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Error: Los datos ingresados no son numéricos.";
                return resultado;
            }
        }

        public static Modelo.Resultado max(string matriz) {
            Modelo.Resultado resultado = new Modelo.Resultado();

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

                        resultado.Correcto = true;
                        resultado.Objecto= valorMax.ToString();
                        return resultado;
                    }
                    catch (Exception)
                    {
                        resultado.Correcto = false;
                        resultado.Mensaje = "Error: Ingrese los datos correctamente.";
                        return resultado;
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

                        resultado.Correcto = true;
                        resultado.Objecto = String.Join(" ", maxCol);
                        return resultado;
                    }
                    catch (Exception)
                    {
                        resultado.Correcto= false;
                        resultado.Mensaje = "Error: Ingrese los datos correctamente.";
                        return resultado;
                    }

                }
            }
            else
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Error: Los datos ingresados no son numéricos.";
                return resultado;
            }
        }

        public static Modelo.Resultado maxk(string matriz, int k)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

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

                        resultado.Correcto = true;
                        resultado.Objecto = String.Join(" ", val_max);
                        return resultado;
                    }
                    catch (Exception)
                    {
                        resultado.Correcto = false;
                        resultado.Mensaje = "Error: Ingrese los datos correctamente.";
                        return resultado;
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

                        resultado.Correcto= true;
                        resultado.Objecto = val_max;
                        return resultado;
                    }
                    catch (Exception)
                    {
                        resultado.Correcto = false;
                        resultado.Mensaje = "Error: Ingrese los datos correctamente.";
                        return resultado;
                    }
                }
            }
            else
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Error: Los datos ingresados no son numéricos.";
                return resultado;
            }
        }

        public static Modelo.Resultado randi(int rango, int filas, int col)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
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

                resultado.Correcto = true;
                resultado.Objecto = salida;
            }
            catch (Exception)
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Error: Hay un error.";
            }

            return resultado;
        }
    
        public static Modelo.Resultado vector(string matriz)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            if (Regex.IsMatch(matriz, @"[\s*-?0-9]") && !(Regex.IsMatch(matriz, @"[a-z]+")))
            {
                try
                {
                    if (Regex.IsMatch(matriz, @"^\[") && Regex.IsMatch(matriz, @"\]\z"))
                    {
                        string matriz_2 = matriz.Substring(1, matriz.Length - 2);

                        // Dividir la cadena en filas
                        string[] filas = matriz_2.Split(';');

                        // Crear una matriz vacía con el número correcto de filas y columnas
                        int filasMatriz = filas.Length;
                        int columnasMatriz = filas[0].Split(' ').Length;
                        Matrix<double> matrizHD = Matrix<double>.Build.Dense(filasMatriz, columnasMatriz);

                        // Llenar la matriz con los números de la cadena
                        for (int i = 0; i < filasMatriz; i++)
                        {
                            var fila = new List<String>(Regex.Split(filas[i], @"\s+"));
                            if (String.IsNullOrEmpty(fila[fila.Count - 1]))
                            {
                                fila.RemoveAt(fila.Count - 1);
                            }
                            if (String.IsNullOrEmpty(fila[0]))
                            {
                                fila.RemoveAt(0);
                            }
                            var fila_int = fila.Select(int.Parse).ToList();
                            for (int j = 0; j < columnasMatriz; j++)
                            {
                                matrizHD[i, j] = fila_int[j];
                            }
                        }

                        // Crear Lissta de listas que almacene los datos de salida
                        List<List<double>> salida = new List<List<double>>();

                        var vArray = matrizHD.ToArray();

                        // Convertir matriz a string de salida
                        int f = vArray.GetLength(0);
                        int c = vArray.GetLength(1);

                        for (int i = 0; i < f; i++)
                        {
                            List<double> filaLista = new List<double>();
                            for (int j = 0; j < c; j++)
                            {
                                filaLista.Add(vArray[i, j]);
                            }
                            salida.Add(filaLista);
                        }

                        resultado.Correcto = true;
                        resultado.Objecto = salida;
                    }
                    else
                    {
                        resultado.Correcto= false;
                        resultado.Mensaje = "Error: No hay una matriz declarada.";
                    }
                }
                catch (Exception)
                {
                    resultado.Correcto = false;
                    resultado.Mensaje = "Error: Ocurrió un error.";
                }
            }
            else
            {
                resultado.Correcto= false;
                resultado.Mensaje= "Error: los valores NO son numéricos.";
            }

            return resultado;
        }
    
        public static Modelo.Resultado pascal(int rango)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                // Crear una matriz vacía con el número correcto de filas y columnas
                Matrix<double> matrizHD = Matrix<double>.Build.Dense(rango, rango);

                for (int i = 0; i < rango; i++)
                {
                    for (int j = 0;j < rango; j++)
                    {
                        if (i == 0)
                        {
                            matrizHD[i,j] = 1;
                        }
                        else
                        {
                            if (j == 0)
                            {
                                matrizHD[i, j] = 1;
                            }
                            else
                            {
                                matrizHD[i, j] = (matrizHD[i, j - 1] + matrizHD[i-1,j]);
                            }
                        }
                    }
                }

                // Crear String que almacene los datos de salida
                string salida = "";
                var vArray = matrizHD.ToArray();

                // Convertir matriz a string de salida
                for (int i = 0; i < vArray.GetLength(0); i++)
                {
                    string filaX = "";
                    for (int j = 0; j < vArray.GetLength(1); j++)
                    {
                        filaX = filaX + vArray[i, j] + " ";
                    }
                    salida += filaX + '\n';
                }

                resultado.Correcto = true;
                resultado.Objecto = salida;
            }
            catch (Exception)
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Error: Ha ocurrido un error.";
            }

                return resultado;
        }
    
    }
}