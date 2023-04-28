using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Alg_linController : ControllerBase
    {
        [HttpPost("mat-mldiv/{m1}&{m2}")]
        public IActionResult mldiv(string m1, string m2)
        {
            Modelo.Resultado respuesta = Logica.Alg_Lineal.mldivide(m1, m2);

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
