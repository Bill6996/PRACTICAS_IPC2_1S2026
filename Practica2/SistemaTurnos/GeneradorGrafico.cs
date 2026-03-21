using System.Diagnostics;

namespace SistemaTurnos
{
    public class GeneradorGrafico
    {
        private string _graphvizPath;

        public GeneradorGrafico()
        {
            // Ruta donde está instalado Graphviz
            _graphvizPath = @"C:\Program Files\Graphviz\bin\dot.exe";
        }

        public string GenerarDot(ColaTurnos cola)
        {
            List<Nodo> nodos = cola.ObtenerTodos();

            string dot = "digraph Cola {\n";
            dot += "    rankdir=LR;\n";
            dot += "    node [shape=box, style=filled, fillcolor=lightblue];\n";

            if (nodos.Count == 0)
            {
                dot += "    vacia [label=\"Cola Vacía\", fillcolor=lightyellow];\n";
            }
            else
            {
                for (int i = 0; i < nodos.Count; i++)
                {
                    Nodo n = nodos[i];
                    dot += $"    nodo{i} [label=\"{n.Nombre}\\nEdad: {n.Edad}\\n{n.Especialidad}\\nEspera: {n.TiempoEspera} min\"];\n";
                }

                for (int i = 0; i < nodos.Count - 1; i++)
                {
                    dot += $"    nodo{i} -> nodo{i + 1};\n";
                }
            }

            dot += "}";
            return dot;
        }

        public string GenerarImagen(ColaTurnos cola)
        {
            string dot = GenerarDot(cola);
            string dotPath = Path.Combine(Path.GetTempPath(), "cola.dot");
            string imgPath = Path.Combine(Path.GetTempPath(), "cola.png");

            File.WriteAllText(dotPath, dot);

            Process proceso = new Process();
            proceso.StartInfo.FileName = _graphvizPath;
            proceso.StartInfo.Arguments = $"-Tpng \"{dotPath}\" -o \"{imgPath}\"";
            proceso.StartInfo.UseShellExecute = false;
            proceso.StartInfo.CreateNoWindow = true;
            proceso.Start();
            proceso.WaitForExit();

            return imgPath;
        }
    }
}