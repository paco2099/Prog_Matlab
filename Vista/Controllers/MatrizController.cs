using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Vista.Controllers
{
    public class MatrizController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public MatrizController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Tarea1()
        {
            return View();
        }

        [HttpPost]
        public JsonResult min(string matriz)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Matriz/mat-min/{matriz}", null);
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


        public IActionResult Mink()
        {
            return View();
        }

        [HttpPost]
        public JsonResult mink(string matriz, int k)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Matriz/mat-mink/{matriz}&{k}", null);
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
                    }else
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

        public IActionResult Max()
        {
            return View();
        }

        [HttpPost]
        public JsonResult max(string matriz)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Matriz/mat-max/{matriz}", null);
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

        public IActionResult Maxk()
        {
            return View();
        }

        [HttpPost]
        public JsonResult maxk(string matriz, int k)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Matriz/mat-maxk/{matriz}&{k}", null);
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

        public IActionResult Randi()
        {
            return View();
        }

        [HttpPost]
        public JsonResult randi(int rango, int filas, int col)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Matriz/mat-randi/{rango}&{filas}&{col}", null);
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

        public IActionResult Graf_vec()
        {
            return View();
        }

        [HttpPost]
        public JsonResult graf_vec(string matriz)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                string urlAPI = _configuration["API"];
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(urlAPI);
                    var peticion = cliente.PostAsync($"Matriz/mat-graf_vec/{matriz}", null);
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

