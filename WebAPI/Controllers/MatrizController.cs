using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MathNet.Numerics.LinearAlgebra;
using System;

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

        [HttpPost("mat-examen2/{n}&{m}&{i}&{j}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult examen2(int n, int m, int i, int j)
        {   
            if (!(n >= 2) & !(m >= 2))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error: Los valores de N y M tienen que ser mayores a 2");
            }

            // Crear una matriz vacía con el número correcto de filas y columnas
            Matrix<double> matrizHD = Matrix<double>.Build.Dense(n, m);

            var aa = new List<List<int>>();
            Random rnd = new Random();

            for (int k = 0; k < n; k++)
            {
                var bb = new List<int>();
                for (int l = 0; l < m; j++)
                {
                    int v_rand = rnd.Next(0, 50);
                    if (bb.Count == 0)
                    {
                        bb.Add(v_rand);
                    }
                    else
                    {
                        while (!(bb.Contains(v_rand)))
                        {
                            bb.Add(v_rand);
                        }
                    }
                }

                aa.Add(bb);
            }

            return Ok("Siiuuuu");


        }
    }
}
