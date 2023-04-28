using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
