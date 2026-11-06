using System;
using System.Collections.Generic;

namespace GestordeCalificaciones
{
    // Se crea la clase GestorCalificaciones para manejar la lógica de registro de estudiantes, agregar calificaciones y mostrar información.
    public class GestorCalificaciones
    {
        private List<Estudiante> estudiantes;
        
        public GestorCalificaciones()
        {
            estudiantes = new List<Estudiante>();
        }

        // Registra un estudiante verificando primero que su matrícula no exista.
        public bool RegistrarEstudiante(string matricula, string nombre)
        {
            if (BuscarEstudiante(matricula) != null)
            {
                return false;
            }

            Estudiante nuevoEstudiante = new Estudiante(matricula, nombre);
            estudiantes.Add(nuevoEstudiante);

            return true;
        }

        // Busca un estudiante utilizando su matrícula.
        public Estudiante? BuscarEstudiante(string matricula)
        {
            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.Matricula == matricula)
                {
                    return estudiante;
                }
            }

            return null;
        }

        // Agrega una calificación al estudiante indicado.
        public bool AgregarCalificacion(string matricula, double calificacion)
        {
            Estudiante? estudiante = BuscarEstudiante(matricula);

            if (estudiante == null)
            {
                return false;
            }

            estudiante.AgregarCalificacion(calificacion);
            return true;
        }

        // Muestra todos los estudiantes, su promedio y su estado.
        public void MostrarEstudiantes()
        {
            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Matrícula: {estudiante.Matricula}");
                Console.WriteLine($"Nombre: {estudiante.Nombre}");

                if (!estudiante.TieneCalificaciones())
                {
                    Console.WriteLine("Promedio: Sin calificaciones");
                    Console.WriteLine("Estado: Sin calificaciones");
                }
                else
                {
                    double promedio = estudiante.CalcularPromedio();

                    Console.WriteLine($"Promedio: {promedio:F2}");

                    if (promedio >= 70)
                    {
                        Console.WriteLine("Estado: Aprobado");
                    }
                    else
                    {
                        Console.WriteLine("Estado: Reprobado");
                    }
                }
            }

            Console.WriteLine("-----------------------------");
        }
    }
}