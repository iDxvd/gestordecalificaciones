# Gestor de Calificaciones

Este es un programa de consola hecho en csharp para poder registrar estudiantes, agregarles calificaciones y ver su promedio y estado.

Primero hay que abrir la terminal dentro de la carpeta del proyecto y ejecutar:

```bash
dotnet run
```

Cuando el programa inicia, aparece un menú con varias opciones:

```text
1. Registrar estudiante
2. Agregar calificación
3. Mostrar estudiantes
4. Salir
```

Desde ahí se puede manejar todo el programa.

## ¿Qué hace el programa?

### 1. Registrar estudiante

Permite registrar un estudiante utilizando:

- Matrícula
- Nombre

La matrícula tiene que ser diferente para cada estudiante. Si se intenta registrar una matrícula que ya existe, el programa lo avisa.

### 2. Agregar calificación

Primero se introduce la matrícula del estudiante y después la calificación.

Las calificaciones solamente pueden estar entre **0 y 100**. Si se pone un número fuera de ese rango, el programa muestra un mensaje de error y permite volver al menú.

También se verifica que la matrícula exista antes de agregar la calificación.

### 3. Mostrar estudiantes

Esta opción muestra los estudiantes que han sido registrados junto con su promedio.

Dependiendo del promedio, el programa muestra:

- **Aprobado:** promedio de 70 o más.
- **Reprobado:** promedio menor de 70.
- **Sin calificaciones:** si todavía no se le ha agregado ninguna.

### 4. Salir

Esta opción termina el programa.

## ¿Cómo está organizado?

El proyecto está dividido principalmente en tres partes.

### `Estudiante.cs`

Aquí está la información de cada estudiante, como su nombre y matrícula.

También se guardan sus calificaciones y se tiene el método que permite calcular su promedio.

### `GestorCalificaciones.cs`

Esta clase se encarga de manejar a los estudiantes.

Los estudiantes se guardan en una `List<Estudiante>`, por lo que se pueden registrar varios estudiantes y buscarlos utilizando su matrícula.

También desde aquí se registran estudiantes, se buscan y se agregan calificaciones.

### `Program.cs`

Aquí está la parte principal del programa.

Se muestra el menú y se utiliza un `switch` para decidir qué hacer dependiendo de la opción que seleccione el usuario.

También se hacen algunas validaciones para evitar que el programa se cierre si el usuario escribe algo incorrecto.

### Algunas dificultades

Como todavía estoy empezando con C#, una de las cosas que más me costó fue entender cómo organizar el programa. Además, hice un archivo por cada clase y al principio también me costó un poquito entender cómo organizar todo de esa forma.

Otra cosa que me costó fue almacenar los estudiantes en una variable. Al principio estaba haciendo una variable por cada estudiante, pero luego busqué y vi que podía utilizar una `List<Estudiante>` para guardar todos los estudiantes. Al final lo hice así porque es mucho más fácil y puedo agregar todos los estudiantes que quiera sin tener que crear una variable nueva para cada uno.

También tuve que aprender un poco sobre las validaciones, como evitar que se pueda poner una calificación mayor de 100 o que el programa se cierre cuando se introduce algo incorrecto. 