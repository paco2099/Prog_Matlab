using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MathNet.Numerics;
using Modelo;
using Logica;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MathNet.Numerics.LinearAlgebra;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatrizController : ControllerBase
    {
        [HttpPost("mat-min/{matriz}")]
        public IActionResult min(string matriz)
        {
            Modelo.Resultado respuesta = Logica.Matriz.min(matriz);

            if (respuesta.Correcto)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("mat-mink/{matriz}&{k}")]
        public IActionResult mink(string matriz, int k)
        {
            Modelo.Resultado respuesta = Logica.Matriz.mink(matriz, k);

            if (respuesta.Correcto)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("mat-max/{matriz}")]
        public IActionResult max(string matriz)
        {
            Modelo.Resultado respuesta = Logica.Matriz.max(matriz);

            if (respuesta.Correcto)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("mat-maxk/{matriz}&{k}")]
        public IActionResult maxk(string matriz, int k)
        {
            Modelo.Resultado respuesta = Logica.Matriz.maxk(matriz, k);

            if (respuesta.Correcto)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("mat-randi/{rango}&{filas}&{col}")]
        public IActionResult randi(int rango, int filas, int col)
        {
            Modelo.Resultado respuesta = Logica.Matriz.randi(rango, filas, col);

            if (respuesta.Correcto)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("mat-vector/{matriz}")]
        public IActionResult vector(string matriz)
        {
            Modelo.Resultado respuesta = Logica.Matriz.vector(matriz);

            if (respuesta.Correcto)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("mat-pascal/{rango}")]
        public IActionResult pascal(int rango)
        {
            Modelo.Resultado respuesta = Logica.Matriz.pascal(rango);

            if (respuesta.Correcto)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("mat-examen2")]
        [ServiceFilter(typeof(CustomExceptionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult examen2([FromBody] MatrizExa2 mat)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errors);
            }

            //    // Puedes formatear los mensajes de error según tus necesidades
            //    var errorMessage = string.Join(", ", errors);

            //    return BadRequest(errorMessage);
            //}

            // Crear una instancia de la clase Random
            Random random = new Random();

            // Crear una matriz nxm
            int[,] matrix = new int[mat.n, mat.m];

            // Crear una lista para rastrear los números generados
            List<int> generatedNumbers = new List<int>();

            // Generar números aleatorios para llenar la matriz
            for (int k = 0; k < mat.n; k++)
            {
                for (int l = 0; l < mat.m; l++)
                {
                    int randomNumber;
                    do
                    {
                        // Generar un número aleatorio dentro del rango deseado
                        randomNumber = random.Next(1, mat.n * mat.m + 1);
                    }
                    while (generatedNumbers.Contains(randomNumber));

                    matrix[k, l] = randomNumber;
                    generatedNumbers.Add(randomNumber);
                }
            }

            // Crear String que almacene los datos de salida
            string salida = "";

            // Convertir matriz a string de salida
            for (int k = 0; k < mat.n; k++)
            {
                string filaX = "";
                for (int l = 0; l < mat.m; l++)
                {
                    if (l == mat.m-1)
                    {
                        filaX = filaX + matrix[k, l];
                    }
                    else
                    {
                        filaX = filaX + matrix[k, l] + " ";
                    }
                }
                if (k == mat.n-1)
                {
                    salida += filaX;
                }
                else
                {
                    salida += filaX + '\n';
                }
            }

            //var responseEntity = new ResponseEntity<object>
            //{
            //    Code = 200,
            //    Message = "Éxito",
            //    Data = "ssiiuuuu"
            //};

            //return new ObjectResult(responseEntity)
            //{
            //    StatusCode = 200
            //};
            return Ok(salida);
        }

        [HttpPost("mat-coord")]
        [ServiceFilter(typeof(CustomExceptionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult coord([FromBody] CoordenadasMatriz coord_mat)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errors);
            }

            if (!((Regex.IsMatch(coord_mat.matriz, @"^[\s*-?0-9]")) && !(Regex.IsMatch(coord_mat.matriz, @"[a-z]+"))))
            {
                return BadRequest("Error: La matriz no es numérica.");
            }

            // Dividir la cadena en filas
            string[] filas = coord_mat.matriz.Split('\n');


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
                    var fila_int = fila.Select(int.Parse).ToList();
                    for (int j = 0; j < columnasMatriz; j++)
                    {
                        matriz[i, j] = fila_int[j];
                    }
                }

                int valor = (int)matriz[coord_mat.i - 1, coord_mat.j - 1];

                return Ok(valor);
            }
            catch (Exception)
            {
                return BadRequest("Error: Los valores dados no concuerdan con las dimensiones de la matriz.");
            }

           
        }

    }       

    public class MatrizExa2: IValidatableObject
    {
        [Required(ErrorMessage = "aaaaa")]
        public int n { get; set; }
        [Required(ErrorMessage ="bbbbbbbbbb")]
        public int m { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!(n >= 2) || !(m >= 2))
            {
                yield return new ValidationResult("El tamaño de la matriz debe ser mayor o igual a 2.");
            }
        }
    }

    public class CoordenadasMatriz
    {
        public int i { get; set; }
        public int j { get; set; }
        public string matriz { get; set; }
    }

    public class ResponseEntity<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
