using System;
using System.Collections.Generic;

class Programa
{
    // Clase Usuario: Representa a un usuario en el sistema.
    class Usuario
    {
        public string Correo { get; set; } //  para almacenar el correo del usuario.
        public string Contraseña { get; set; } //  para almacenar la contraseña del usuario.
        public List<Entrenamiento> Entrenamientos { get; set; } // Lista de entrenamientos del usuario.

        // Constructor de la clase Usuario, inicializa las propiedades.
        public Usuario(string correo, string contraseña)
        {
            Correo = correo;
            Contraseña = contraseña;
            Entrenamientos = new List<Entrenamiento>(); // Inicializa la lista de entrenamientos vacía.
        }
    }

    // Clase Entrenamiento: Representa un entrenamiento realizado por el usuario.
    class Entrenamiento
    {
        public double Distancia { get; set; } //  para almacenar la distancia recorrida (en kilómetros).
        public double Tiempo { get; set; } //  para almacenar el tiempo empleado (en minutos).

        // Constructor de la clase Entrenamiento, inicializa las propiedades.
        public Entrenamiento(double distancia, double tiempo)
        {
            Distancia = distancia;
            Tiempo = tiempo;
        }
    }

    // Lista global que almacena a los usuarios registrados.
    static List<Usuario> usuariosRegistrados = new List<Usuario>();
    // Variable que almacena el usuario que ha iniciado sesión.
    static Usuario usuarioLogeado = null;

    // Función principal que controla el flujo del programa.
    static void Main()
    {
        int opcion;
        do
        {
            // Menú principal donde el usuario puede elegir qué acción realizar.
            Console.Clear();
            Console.WriteLine(" Menú: ");
            Console.WriteLine(" 1. Registrar usuario ");
            Console.WriteLine(" 2. Iniciar sesión de usuario ");
            Console.WriteLine(" 3. Salir ");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine()); // Lee la opción ingresada por el usuario.

            // Dependiendo de la opción, se ejecuta una acción.
            switch (opcion)
            {
                case 1:
                    RegistrarUsuario(); // Registra un nuevo usuario.
                    break;

                case 2:
                    LogearUsuario(); // Inicia sesión con un usuario ya registrado.
                    break;

                case 3:
                    Console.WriteLine("Saliendo del programa..."); // Muestra mensaje de salida y termina el programa.
                    break;

                default:
                    Console.WriteLine("Opción no válida."); // Si la opción no es válida, muestra un mensaje de error.
                    break;
            }
        } while (opcion != 3); // El menú seguirá apareciendo hasta que el usuario elija salir (opción 3).
    }

    // Función para registrar un nuevo usuario.
    static void RegistrarUsuario()
    {
        Console.Clear();
        Console.Write("Ingrese el correo del usuario: ");
        string correo = Console.ReadLine(); // Lee el correo ingresado.

        // Verifica si ya existe un usuario con el mismo correo.
        if (usuariosRegistrados.Exists(u => u.Correo == correo))
        {
            Console.WriteLine("Ya existe un usuario con este correo.");
            return; // Si el correo ya está registrado, no permite crear un nuevo usuario.
        }

        Console.Write("Ingrese la contraseña del usuario: ");
        string contraseña = Console.ReadLine(); // Lee la contraseña ingresada.

        // Crea un nuevo objeto Usuario y lo agrega a la lista de usuarios registrados.
        usuariosRegistrados.Add(new Usuario(correo, contraseña));
        Console.WriteLine("Usuario registrado con éxito.");
        Console.ReadKey(); // Espera a que el usuario presione una tecla para continuar.
    }

    // Función para logear a un usuario.
    static void LogearUsuario()
    {
        Console.Clear();
        Console.Write("Ingrese el correo: ");
        string correo = Console.ReadLine(); // Lee el correo ingresado.

        Console.Write("Ingrese la contraseña: ");
        string contraseña = Console.ReadLine(); // Lee la contraseña ingresada.

        // Busca el usuario que coincida con el correo y la contraseña proporcionados.
        usuarioLogeado = usuariosRegistrados.Find(u => u.Correo == correo && u.Contraseña == contraseña);

        if (usuarioLogeado == null)
        {
            Console.WriteLine("Correo o contraseña incorrectos."); // Si no se encuentra el usuario, muestra un mensaje de error.
            Console.ReadKey(); // Espera a que el usuario presione una tecla para continuar.
            return;
        }

        Console.WriteLine("Inicio de sesión exitoso.");
        MenuEntrenamientos(); // Si el login es exitoso, accede al menú de entrenamientos.
    }

    // Menú de entrenamientos, disponible solo cuando el usuario está logeado.
    static void MenuEntrenamientos()
    {
        int opcion;
        do
        {
            // Menú de opciones para gestionar los entrenamientos del usuario logueado.
            Console.Clear();
            Console.WriteLine(" Menú de Entrenamientos:");
            Console.WriteLine(" 1. Registrar un entrenamiento");
            Console.WriteLine(" 2. Listar entrenamientos");
            Console.WriteLine(" 3. Vaciar entrenamientos");
            Console.WriteLine(" 4. Cerrar sesión");
            Console.Write(" Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine()); // Lee la opción seleccionada.

            // Dependiendo de la opción seleccionada, se ejecuta una acción.
            switch (opcion)
            {
                case 1:
                    RegistrarEntrenamiento(); // Permite al usuario registrar un nuevo entrenamiento.
                    break;

                case 2:
                    ListarEntrenamientos(); // Muestra los entrenamientos registrados por el usuario.
                    break;

                case 3:
                    VaciarEntrenamientos(); // Borra todos los entrenamientos registrados.
                    break;

                case 4:
                    CerrarSesion(); // Cierra la sesión del usuario logueado.
                    break;

                default:
                    Console.WriteLine("Opción no válida."); // Si la opción no es válida, muestra un mensaje de error.
                    break;
            }
        } while (opcion != 4); // El menú continuará mostrando opciones hasta que el usuario elija cerrar sesión (opción 4).
    }

    // Función para registrar un entrenamiento (distancia y tiempo).
    static void RegistrarEntrenamiento()
    {
        Console.Clear();
        Console.Write("Ingrese la distancia recorrida (en km (Ej:2,5)): ");
        double distancia = double.Parse(Console.ReadLine()); // Lee la distancia recorrida (en kilómetros).

        Console.Write("Ingrese el tiempo empleado (en minutos): ");
        double tiempo = double.Parse(Console.ReadLine()); // Lee el tiempo empleado (en minutos).

        // Crea un nuevo objeto Entrenamiento y lo agrega a la lista de entrenamientos del usuario logueado.
        usuarioLogeado.Entrenamientos.Add(new Entrenamiento(distancia, tiempo));
        Console.WriteLine("Entrenamiento registrado con éxito.");
        Console.ReadKey(); // Espera a que el usuario presione una tecla para continuar.
    }

    // Función para listar todos los entrenamientos del usuario logueado.
    static void ListarEntrenamientos()
    {
        Console.Clear();
        // Verifica si el usuario tiene entrenamientos registrados.
        if (usuarioLogeado.Entrenamientos.Count == 0)
        {
            Console.WriteLine("No tienes entrenamientos registrados.");
        }
        else
        {
            Console.WriteLine("Lista de entrenamientos:");
            // Muestra todos los entrenamientos con distancia y tiempo.
            foreach (var entrenamiento in usuarioLogeado.Entrenamientos)
            {
                Console.WriteLine($"Distancia: {entrenamiento.Distancia} km, Tiempo: {entrenamiento.Tiempo} horas");
            }
        }
        Console.ReadKey(); // Espera a que el usuario presione una tecla para continuar.
    }

    // Función para vaciar la lista de entrenamientos del usuario.
    static void VaciarEntrenamientos()
    {
        Console.Clear();
        usuarioLogeado.Entrenamientos.Clear(); // Borra todos los entrenamientos del usuario logueado.
        Console.WriteLine("Entrenamientos borrados con éxito.");
        Console.ReadKey(); // Espera a que el usuario presione una tecla para continuar.
    }

    // Función para cerrar la sesión del usuario logueado.
    static void CerrarSesion()
    {
        Console.Clear();
        usuarioLogeado = null; // Resetea la variable usuarioLogeado, lo que significa que el usuario ya no está logueado.
        Console.WriteLine("Sesión cerrada.");
        Console.ReadKey(); // Espera a que el usuario presione una tecla para continuar.
    }
}
