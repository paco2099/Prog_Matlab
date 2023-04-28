using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Vista.Controllers

//https://platzi.com/tutoriales/1352-ia/1313-calcular-cualquier-promedio-media-y-moda-de-una-lista-de-datos/
{
    public class EstadisticaController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public EstadisticaController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Mean()
        {
            return View();
        }

        public IActionResult Median()
        {
            return View();
        }

        [HttpPost]
        public JsonResult mean(string matriz, int a)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Estadistica/mat-mean/{matriz}&{a}", null);
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

        [HttpPost]
        public JsonResult median(string matriz, int a)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Estadistica/mat-median/{matriz}&{a}", null);
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
