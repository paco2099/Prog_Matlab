using System.Text.RegularExpressions;

namespace Logica
{
    public class Examenes
    {
        public static Modelo.Resultado examen1(string matriz)
        {
            Modelo.Resultado resultado = new Modelo.Resultado();

            try
            {
                var filas = new List<String>(matriz.Split('\n'));

                if (filas.Count == 1)
                {
                    var fila = new List<String>(Regex.Split(filas[0], @"\s+"));
                    if (String.IsNullOrEmpty(fila[fila.Count - 1]))
                    {
                        fila.RemoveAt(fila.Count - 1);
                    }
                    if (String.IsNullOrEmpty(fila[0]))
                    {
                        fila.RemoveAt(0);
                    }
                    var fila_int = fila.Select(int.Parse).ToList();
                    int valorMinimo = fila_int.Min();
                    int valorMaximo = fila_int.Max();

                    resultado.Correcto = true;
                    resultado.Objecto = "Valor Minimo: " + valorMinimo + "\nValor Maximo: " + valorMaximo;
                    return resultado;
                }
                else
                {
                    var filasHD = new List<List<int>>();

                    for (int i = 0; i < filas.Count; i++)
                    {
                        var fs = new List<String>(Regex.Split(filas[i], @"\s+"));
                        if (String.IsNullOrEmpty(fs[fs.Count - 1]))
                        {
                            fs.RemoveAt(fs.Count - 1);
                        }
                        if (String.IsNullOrEmpty(fs[0]))
                        {
                            fs.RemoveAt(0);
                        }
                        var fs_int = fs.Select(int.Parse).ToList();
                        filasHD.Add(fs_int);
                    }

                    string min_list = "";
                    string max_list = "";

                    for (int j = 0; j < filasHD.Count; j++)
                    {
                        min_list = min_list + filasHD[j].Min() + "\n";
                        max_list = max_list + filasHD[j].Max() + "\n";
                    }

                    resultado.Correcto = true;
                    resultado.Objecto = "Valores Minimos: \n" + min_list + "\nValores Máximos: \n" + max_list;
                }
            }
            catch (Exception)
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Error: Ocurrió un error";
            }
            return resultado;
        }
    }
}
