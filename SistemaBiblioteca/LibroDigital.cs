using System;

namespace SistemaBiblioteca
{
    public class LibroDigital : MaterialBiblioteca
    {
        // Atributo propio de LibroDigital
        private double tamanoMB;

        // Constructor
        public LibroDigital(string titulo, string autor, double tamanoMB)
            : base(titulo, autor)
        {
            this.tamanoMB = tamanoMB;
        }

        // Getter y Setter
        public double GetTamanoMB() { return tamanoMB; }
        public void SetTamanoMB(double valor) { tamanoMB = valor; }

        // MostrarInformacion personalizado (Polimorfismo)

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
                Console.WriteLine("Tienes 3 días para devolverlo.");
            }
        }
        public override void MostrarInformacion()
        {
            Console.WriteLine("=== LIBRO DIGITAL ===");
            Console.WriteLine("Título: " + GetTitulo());
            Console.WriteLine("Autor: " + GetAutor());
            Console.WriteLine("Código: " + GetCodigo());
            Console.WriteLine("Tamaño del archivo: " + tamanoMB + " MB");
            Console.WriteLine("Días máximos de préstamo: 3");
            Console.WriteLine("Estado: " + (GetPrestado() ? "Prestado" : "Disponible"));
        }
    }
}