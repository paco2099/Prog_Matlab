using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
