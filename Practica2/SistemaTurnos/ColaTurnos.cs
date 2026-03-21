namespace SistemaTurnos
{
    public class ColaTurnos
    {
        private Nodo frente;
        private Nodo final;
        private int cantidad;

        public ColaTurnos()
        {
            frente = null;
            final = null;
            cantidad = 0;
        }

        public bool EstaVacia() => frente == null;

        public int Cantidad() => cantidad;

        // Agregar paciente al final de la cola
        public void Encolar(string nombre, int edad, string especialidad)
        {
            // Calcular tiempo de espera antes de agregar
            int tiempoEspera = CalcularTiempoEsperaTotal();

            Nodo nuevo = new Nodo(nombre, edad, especialidad);
            nuevo.TiempoEspera = tiempoEspera;

            if (EstaVacia())
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
            cantidad++;
        }

        // Atender al primer paciente (quitar del frente)
        public Nodo Desencolar()
        {
            if (EstaVacia()) return null;

            Nodo atendido = frente;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

            cantidad--;
            return atendido;
        }

        // Ver quién es el siguiente sin quitarlo
        public Nodo VerFrente() => frente;

        // Calcular el tiempo total de espera acumulado en la cola
        public int CalcularTiempoEsperaTotal()
        {
            int total = 0;
            Nodo actual = frente;
            while (actual != null)
            {
                total += actual.TiempoAtencion;
                actual = actual.Siguiente;
            }
            return total;
        }

        // Obtener lista de nodos para mostrar en pantalla
        public List<Nodo> ObtenerTodos()
        {
            List<Nodo> lista = new List<Nodo>();
            Nodo actual = frente;
            while (actual != null)
            {
                lista.Add(actual);
                actual = actual.Siguiente;
            }
            return lista;
        }
    }
}