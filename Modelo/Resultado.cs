namespace Modelo
{
    public class Resultado
    {
        public bool Correcto { get; set; }
        public string Mensaje { get; set; }
        public object Objecto { get; set; }
        public Exception Excepcion { get; set; }
    }
}