using System;

namespace SistemaBiblioteca
{
    public abstract class MaterialBiblioteca
    {
        // Atributos privados (Encapsulamiento)
        private string titulo;
        private string autor;
        private string codigo;
        private bool prestado;

        // Constructor
        public MaterialBiblioteca(string titulo, string autor)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.codigo = GenerarCodigo();
            this.prestado = false;
        }

        // Getters y Setters (Encapsulamiento)
        public string GetTitulo() { return titulo; }
        public string GetAutor() { return autor; }
        public string GetCodigo() { return codigo; }
        public bool GetPrestado() { return prestado; }
        public void SetPrestado(bool valor) { prestado = valor; }

        // Genera un código único de 8 caracteres automáticamente
        private string GenerarCodigo()
        {
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string codigo = "";
            for (int i = 0; i < 8; i++)
            {
                codigo += caracteres[random.Next(caracteres.Length)];
            }
            return codigo;
        }

        // Presta el material si está disponible
        public void Prestar()
        {
            if (prestado)
            {
                Console.WriteLine("No disponible, ya está prestado.");
            }
            else
            {
                prestado = true;
                Console.WriteLine("Material prestado correctamente.");
            }
        }

        // Devuelve el material si estaba prestado
        public void Devolver()
        {
            if (!prestado)
            {
                Console.WriteLine("Este material no estaba prestado.");
            }
            else
            {
                prestado = false;
                Console.WriteLine("Material devuelto correctamente.");
            }
        }

        // Método abstracto (Polimorfismo)
        public abstract void MostrarInformacion();
    }
}