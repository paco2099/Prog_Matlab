using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstadisticaController : ControllerBase
    {
        [HttpPost("mat-mean/{matriz}&{a}")]
        public IActionResult mean(string matriz, int a)
        {
            Modelo.Resultado respuesta = Logica.Estadistica.mean(matriz, a);

            if (respuesta.Correcto)
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPost("mat-median/{matriz}&{a}")]
        public IActionResult median(string matriz, int a)
        {
            Modelo.Resultado respuesta = Logica.Estadistica.median(matriz, a);

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
