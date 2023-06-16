using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace Vista.Controllers
{
    public class ExamenesController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public ExamenesController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Exam1()
        {
            return View();
        }

        [HttpPost]
        public JsonResult examen1(string matriz)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Examenes/mat-exam1/{matriz}", null);
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

        public IActionResult Ordinario()
        {
            return View();
        }
    }
}
