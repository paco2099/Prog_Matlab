﻿using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Text.RegularExpressions;

namespace Vista {
    public class AlgLin {
        public string mldivide (string a, string b) {
            // Dividir la cadena en filas
            string[] filas = b.Split('\n');

            // Crear una matriz vacía con el número correcto de filas y columnas
            int filasMatriz = filas.Length;
            int columnasMatriz = filas[0].Split(' ').Length;
            Matrix<double> matriz = Matrix<double>.Build.Dense(filasMatriz, columnasMatriz);

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
                    matriz[i, j] = fila_int[j];
                }
            }

            // Crear String que almacene los datos de salida
            string salida = "";

            // Crear vector O matriz a
            var filasA = a.Split("\n");

            if (filasA.Length == 1)
            {
                // Dividir cadena en columnas y convertir los datos a double
                var fila = new List<String>(Regex.Split(filasA[0], @"\s+"));

                for (int i = 0; i < filasA.Length; i++)
                {
                    if (String.IsNullOrEmpty(fila[fila.Count - 1]))
                    {
                        fila.RemoveAt(fila.Count - 1);
                    }
                    if (String.IsNullOrEmpty(fila[0]))
                    {
                        fila.RemoveAt(0);
                    }
                }

                if (fila.Count == 1)
                {
                    // Como A es un escalar

                    // Limpiamos los datos

                    // Convertimos el escalar a un valor de tipo double
                    double aHD = Convert.ToDouble(fila[0]);

                    // Dividimosss la matriz entre el escalar
                    Matrix<double> x = matriz/aHD;

                    var vArray = x.ToArray();

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
                }
                else
                {
                    // Convertir A a vector
                    Vector<double> aHD = DenseVector.OfArray(Array.ConvertAll(fila.ToArray(), Double.Parse));
                    // Resolver la ecuación Ax = B para x
                    Vector<double> x = matriz.Solve(aHD);

                    var vArray = x.ToArray();

                    // Convertir vector a string de salida
                    for (int i = 0; i < vArray.GetLength(0); i++)
                    {
                        salida = vArray[i] + "\n";
                    }
                }
            }
            else
            {
                // Crear una matriz vacía con el número correcto de filas y columnas
                int filasMatriza = filasA.Length;
                int columnasMatriza = filasA[0].Split(' ').Length;
                Matrix<double> aHD = Matrix<double>.Build.Dense(filasMatriza, columnasMatriza);

                // Llenar la matriz con los números de la cadena
                for (int i = 0; i < filasMatriz; i++)
                {
                    var fila = new List<String>(Regex.Split(filasA[i], @"\s+"));
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
                        aHD[i, j] = fila_int[j];
                    }
                }

                // Resolver la ecuación Ax = B para x
                Matrix<double> x = matriz.Solve(aHD);

                var vArray = x.ToArray();

                // Convertir matriz a string de salida
                for (int i = 0; i < vArray.GetLength(0); i++)
                {
                    string filaX = "";
                    for (int j = 0;j < vArray.GetLength(1); j++)
                    {
                        filaX = filaX + vArray[i,j] + " ";
                    }
                    salida += filaX + '\n';
                }
            }

            return salida;
        }

    }
}