using System;
using GestordeCalificaciones;

class Program
{
    static void Main(string[] args)
    {
        GestorCalificaciones gestor = new GestorCalificaciones();
        // Se crea un bucle para mostrar el menú y permitir al usuario interactuar con el programa.
        // Variable 'opcion' se inicializa en 0 para entrar en el bucle.
        int opcion = 0;
        
        while (opcion != 4)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("   GESTOR DE CALIFICACIONES");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Agregar calificación");
            Console.WriteLine("3. Mostrar estudiantes");
            Console.WriteLine("4. Salir");
            Console.WriteLine("=================================");
            Console.Write("Seleccione una opción: ");
            // Se utiliza TryParse para que el programa no se caiga si el usuario introduce un valor no numérico.
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Introduzca un número.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                continue;
            }
            // Se utiliza un switch para manejar las diferentes opciones del menú(idea de chatgpt yo lo estaba haciendo con un monton de condicionales y luego me acorde que usted explico en la clase que esa era una solución a esto hahahah).
            switch (opcion)
            {
                case 1:
                    RegistrarEstudiante(gestor);
                    break;

                case 2:
                    AgregarCalificacion(gestor);
                    break;

                case 3:
                    gestor.MostrarEstudiantes();
                    // Se agrega una pausa para que el usuario pueda leer la información antes de que salga de nuevo el menu ya que es molesto y no le da tiempo a leer la información.
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Método para registrar un estudiante, solicitando la matrícula y el nombre
    static void RegistrarEstudiante(GestorCalificaciones gestor)
    {
        Console.Write("Ingrese la matrícula: ");
        string matricula = Console.ReadLine() ?? "";

        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine() ?? "";

        bool registrado = gestor.RegistrarEstudiante(matricula, nombre);

        if (registrado)
        {
            Console.WriteLine("Estudiante registrado correctamente.");
        }
        // Si la matrícula ya existe se le avisa.
        else
        {
            Console.WriteLine("Ya existe un estudiante con esa matrícula.");
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    static void AgregarCalificacion(GestorCalificaciones gestor)
    {
        Console.Write("Ingrese la matrícula del estudiante: ");
        string matricula = Console.ReadLine() ?? "";

        Estudiante? estudiante = gestor.BuscarEstudiante(matricula);

        if (estudiante == null)
        {
            Console.WriteLine("No se encontró un estudiante con esa matrícula.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.Write("Ingrese la calificación (0-100): ");

        if (!double.TryParse(Console.ReadLine(), out double calificacion))
        {
            Console.WriteLine("Debe introducir un número válido.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            return;
        }
        // condicional or para validar que la calificación este entre 0 y 100.
        if (calificacion < 0 || calificacion > 100)
        {
            // El unico que saca mas de 100 soy yo.
            Console.WriteLine("La calificación debe estar entre 0 y 100.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            return;
        }

        gestor.AgregarCalificacion(matricula, calificacion);

        Console.WriteLine("Calificación agregada correctamente.");
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }
}