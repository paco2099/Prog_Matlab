using Logica;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExamenesController : ControllerBase
    {
        [HttpPost("mat-exam1/{matriz}")]
        public IActionResult examen1(string matriz)
        {
            Modelo.Resultado respuesta = Logica.Examenes.examen1(matriz);

            if (respuesta.Correcto)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("mat-ordi")]
        [ServiceFilter(typeof(CustomExceptionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ordi([FromBody] Textoentrada entrada)
        {
            string matriz_2 = entrada.entrada.Substring(1, entrada.entrada.Length - 2);

            // Dividir la cadena en filas
            var filas = matriz_2.Split(';');
            // Crear una matriz vacía con el número correcto de filas y columnas
            int filasMatriz = filas.Length;
            int columnasMatriz = filas[0].Split(',').Length;

            string[,] matrizHD = new string[filasMatriz, columnasMatriz];
            try
            {


                //Matrix<string> matrizHD = Matrix<string>.Build.Dense(filasMatriz, columnasMatriz);

                //Llenar la matriz con los elementos de la cadena
                for (int i = 0; i < filasMatriz; i++)
                {
                    var fila = new List<String>(filas[i].Split(","));
                    for (int j = 0; j < columnasMatriz; j++)
                    {
                        string vf = "";
                        var v = new List<String>(Regex.Split(fila[j], @"\s+"));
                        for (int k = 0; k < v.Count; k++)
                        {
                            if (!(String.IsNullOrEmpty(v[k])))
                            {
                                vf += v[k];
                            }
                        }
                        matrizHD[i, j] = vf;
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("Error al crear la matriz. Por favor revise sus datos.");
            }

            // Crear String que almacene los datos de salida
            string salida = "";

            // Convertir matriz a string de salida
            for (int k = 0; k < filasMatriz; k++)
            {
                string filaX = "";
                for (int l = 0; l < columnasMatriz; l++)
                {
                    if (l == columnasMatriz - 1)
                    {
                        filaX = filaX + matrizHD[k, l];
                    }
                    else
                    {
                        filaX = filaX + matrizHD[k, l] + " ";
                    }
                }
                if (k == filasMatriz - 1)
                {
                    salida += filaX;
                }
                else
                {
                    salida += filaX + '\n';
                }
            }

            return Ok(salida);

        }

        [HttpPost("mat-ordi-strlength")]
        [ServiceFilter(typeof(CustomExceptionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult strlength([FromBody] Matrizentrada mat)
        {
            if (!((Regex.IsMatch(mat.mat, @"\\[\s*[a-z]+(\s*[,;]\s*[a-z]+)\s\\]"))))
            {
                return BadRequest("Error: Ingrese los valores en el formato adecuado.");
            }
                // Dividir la cadena en filas
                string[] filas = mat.mat.Split('\n');


            // Crear una matriz vacía con el número correcto de filas y columnas
            int filasMatriz = filas.Length;
            int columnasMatriz = filas[0].Split(' ').Length;
            Matrix<double> matriz = Matrix<double>.Build.Dense(filasMatriz, columnasMatriz);

            try
            {
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
                    for (int j = 0; j < columnasMatriz; j++)
                    {
                        matriz[i, j] = fila[j].Length;
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("Error: Los valores dados no concuerdan con las dimensiones de la matriz.");
            }

            // Crear String que almacene los datos de salida
            string salida = "";

            // Convertir matriz a string de salida
            for (int k = 0; k < filasMatriz; k++)
            {
                string filaX = "";
                for (int l = 0; l < columnasMatriz; l++)
                {
                    if (l == columnasMatriz - 1)
                    {
                        filaX = filaX + matriz[k, l];
                    }
                    else
                    {
                        filaX = filaX + matriz[k, l] + " ";
                    }
                }
                if (k == filasMatriz - 1)
                {
                    salida += filaX;
                }
                else
                {
                    salida += filaX + '\n';
                }
            }

            return Ok(salida);
        }
    }

    public class Textoentrada
    {
        [Required]
        public string entrada { get; set; }
    }

    public class Matrizentrada
    {
        [Required]
        public string mat { get; set; }
    }
}
