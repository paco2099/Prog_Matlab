using System.Text.RegularExpressions;

namespace Logica
{
    public class Matriz
    {
        public static string min(string matriz)
        {
            if (Regex.IsMatch(matriz, @"^[\s*-?0-9]") && !(Regex.IsMatch(matriz, @"[a-z]+")))
            {
                var filas = new List<String>(matriz.Split('\n'));

                if (filas.Count == 1)
                {
                    try
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

                        return valorMinimo.ToString();
                    }
                    catch (Exception)
                    {
                        return "Error: Ingrese los datos correctamente.";
                    }
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

                    var filasHDT = filasHD.SelectMany(inner => inner.Select((item, index) => new { item, index })).GroupBy(i => i.index, i => i.item).Select(g => g.ToList()).ToList();
                    var minCol = new List<int>();
                    try
                    {

                        for (int i = 0; i < filasHDT.Count; i++)
                        {
                            if (minCol.Count == 0)
                            {
                                minCol.Add(filasHDT[i].Min());
                            }
                            else if (filasHDT[i - 1].Count == filasHDT[i].Count)
                            {
                                minCol.Add(filasHDT[i].Min());
                            }
                            else
                            {
                                return "Error: Las matrices tienen que tener el mismo tamaño.";
                            }

                        }

                        return String.Join(" ", minCol);
                    }
                    catch (Exception)
                    {
                        return "Error: Las matrices tienen que tener el mismo tamaño.";
                    }

                }
            }
            else
            {
                return "Error: Los datos ingresados no son numéricos.";
            }
        }
    }
}