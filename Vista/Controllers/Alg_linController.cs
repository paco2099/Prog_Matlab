using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Vista.Controllers
{
    public class Alg_linController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public Alg_linController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult mldivide()
        {
            return View();
        }

        [HttpPost]
        public JsonResult mldiv(string m1, string m2)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Alg_lin/mat-mldiv/{m1}&{m2}", null);
                    peticion.Wait();

                    var resultadoPeticion = peticion.Result;
                    if (resultadoPeticion.IsSuccessStatusCode)
                    {
                        var leerPeticion = resultadoPeticion.Content.ReadAsStringAsync();
                        leerPeticion.Wait();

                        dynamic resultadoJSON = JObject.Parse(leerPeticion.Result);

                        if (Convert.ToBoolean(resultadoJSON.correcto))
                        {
                            resultado.Correcto = true;
                            resultado.Objecto = Convert.ToString(resultadoJSON.objecto);
                        }
                        else
                        {
                            resultado.Correcto = false;
                            resultado.Mensaje = Convert.ToString(resultadoJSON.mensaje);
                        }
                    }
                    else
                    {
                        var leerPeticion = resultadoPeticion.Content.ReadAsStringAsync();
                        leerPeticion.Wait();
                        dynamic resultadoJSON = JObject.Parse(leerPeticion.Result);

                        resultado.Correcto = false;
                        resultado.Mensaje = Convert.ToString(resultadoJSON.mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensaje = ex.Message;
                resultado.Excepcion = ex;
            }

            if (resultado.Correcto)
            {
                return Json(resultado.Objecto);
            }
            else
            {
                return Json(resultado.Mensaje);
            }
        }
    }
}
