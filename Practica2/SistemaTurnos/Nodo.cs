namespace SistemaTurnos
{
    public class Nodo
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Especialidad { get; set; }
        public int TiempoAtencion { get; set; }
        public int TiempoEspera { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(string nombre, int edad, string especialidad)
        {
            Nombre = nombre;
            Edad = edad;
            Especialidad = especialidad;
            Siguiente = null;

            // Tiempo de atención según especialidad
            TiempoAtencion = especialidad switch
            {
                "Medicina General" => 10,
                "Pediatría" => 15,
                "Ginecología" => 20,
                "Dermatología" => 25,
                _ => 10
            };
        }
    }
}