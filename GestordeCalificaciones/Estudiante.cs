using System;
using System.Collections.Generic;
using System.Linq;

namespace GestordeCalificaciones
{
    public class Estudiante
    {
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        // Se utiliza private para proteger las calificaciones y evitar que sean modificadas directamente desde fuera de la clase.
        // De esta forma, solo pueden agregarse mediante el método AgregarCalificacion().
        private List<double> Calificaciones { get; set; }

        public Estudiante(string matricula, string nombre)
        {
            Matricula = matricula;
            Nombre = nombre;
            Calificaciones = new List<double>();
        }
        // Método para agregar una calificación a la lista de calificaciones del estudiante.
        public void AgregarCalificacion(double calificacion)
        {
            Calificaciones.Add(calificacion);
        }
        // Método para calcular el promedio de las calificaciones del estudiante.
        public double CalcularPromedio()
        {
            return Calificaciones.Average();
        }
        // Método para obtener la calificación máxima del estudiante.
        public bool TieneCalificaciones()
        {
            return Calificaciones.Count > 0;
        }
        // Método para obtener la calificación máxima del estudiante.
        public override string ToString()
        {
            return $"Matrícula: {Matricula}, Nombre: {Nombre}";
        }
    }
}