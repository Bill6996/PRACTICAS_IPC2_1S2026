using System;

namespace SistemaBiblioteca
{
    public class LibroFisico : MaterialBiblioteca
    {
        // Atributo propio de LibroFisico
        private int numeroEjemplar;

        // Constructor
        public LibroFisico(string titulo, string autor, int numeroEjemplar)
            : base(titulo, autor)
        {
            this.numeroEjemplar = numeroEjemplar;
        }

        // Getter y Setter
        public int GetNumeroEjemplar() { return numeroEjemplar; }
        public void SetNumeroEjemplar(int valor) { numeroEjemplar = valor; }

        // Sobrescribe Prestar para mostrar los días máximos
        public new void Prestar()
        {
            if (GetPrestado())
            {
                Console.WriteLine("No disponible, ya está prestado.");
            }
            else
            {
                SetPrestado(true);
                Console.WriteLine("Material prestado correctamente.");
                Console.WriteLine("Tienes 7 días para devolverlo.");
            }
        }

        // MostrarInformacion personalizado (Polimorfismo)
        public override void MostrarInformacion()
        {
            Console.WriteLine("=== LIBRO FÍSICO ===");
            Console.WriteLine("Título: " + GetTitulo());
            Console.WriteLine("Autor: " + GetAutor());
            Console.WriteLine("Código: " + GetCodigo());
            Console.WriteLine("Número de ejemplar: " + numeroEjemplar);
            Console.WriteLine("Días máximos de préstamo: 7");
            Console.WriteLine("Estado: " + (GetPrestado() ? "Prestado" : "Disponible"));
        }
    }
}