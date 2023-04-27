using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Resultado
    {
        public bool Correcto { get; set; }
        public string Mensaje { get; set; }
        public object Objecto { get; set; }
        public Exception Excepcion { get; set; }
    }
}
