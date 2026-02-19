using System;
using System.Collections.Generic;

namespace SistemaBiblioteca
{
    class Program
    {
        // Lista que guardara todos los materiales registrados
        static List<MaterialBiblioteca> materiales = new List<MaterialBiblioteca>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n===== SISTEMA DE BIBLIOTECA =====");
                Console.WriteLine("1. Registrar Libro Físico");
                Console.WriteLine("2. Registrar Libro Digital");
                Console.WriteLine("3. Gestionar materiales");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opción: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1: RegistrarLibroFisico(); break;
                    case 2: RegistrarLibroDigital(); break;
                    case 3: GestionarMateriales(); break;
                    case 4: Console.WriteLine("Saliendo..."); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            } while (opcion != 4);
        }

        // Método para registrar un libro físico
        static void RegistrarLibroFisico()
        {
            Console.Write("Ingresa el título: ");
            string titulo = Console.ReadLine();
            Console.Write("Ingresa el autor: ");
            string autor = Console.ReadLine();
            Console.Write("Ingresa el número de ejemplar: ");
            int ejemplar = int.Parse(Console.ReadLine());
            LibroFisico libro = new LibroFisico(titulo, autor, ejemplar);
            materiales.Add(libro);
            Console.WriteLine("Libro físico registrado con código: " + libro.GetCodigo());
        }

        // Método para registrar un libro digital
        static void RegistrarLibroDigital()
        {
            Console.Write("Ingresa el título: ");
            string titulo = Console.ReadLine();
            Console.Write("Ingresa el autor: ");
            string autor = Console.ReadLine();
            Console.Write("Ingresa el tamaño en MB: ");
            double tamano = double.Parse(Console.ReadLine());
            LibroDigital libro = new LibroDigital(titulo, autor, tamano);
            materiales.Add(libro);
            Console.WriteLine("Libro digital registrado con código: " + libro.GetCodigo());
        }

        // Método para gestionar materiales registrados
        static void GestionarMateriales()
        {
            if (materiales.Count == 0)
            {
                Console.WriteLine("No hay materiales registrados.");
                return;
            }
            Console.WriteLine("\n===== MATERIALES REGISTRADOS =====");
            for (int i = 0; i < materiales.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + materiales[i].GetTitulo() + " - " + materiales[i].GetCodigo());
            }
            Console.Write("Elige el número del material: ");
            int indice = int.Parse(Console.ReadLine()) - 1;
            if (indice < 0 || indice >= materiales.Count)
            {
                Console.WriteLine("Opción no válida.");
                return;
            }
            MaterialBiblioteca material = materiales[indice];
            Console.WriteLine("\n1. Prestar");
            Console.WriteLine("2. Devolver");
            Console.WriteLine("3. Ver información");
            Console.Write("Elige una opción: ");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1: material.Prestar(); break;
                case 2: material.Devolver(); break;
                case 3: material.MostrarInformacion(); break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }

    } // cierra class Program
} // cierra namespace