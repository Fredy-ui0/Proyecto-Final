class Login
{
    private string Usuario = "admin";
    private string Contraseña = "12345A#?";

    public bool IniciarSesion()
    {
        while (true)
        {
            Console.Write("Usuario: ");
            string usuario = Console.ReadLine();

            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();

            if (usuario == Usuario && contrasena == Contraseña)
            {
                Console.WriteLine("Acceso concedido");
                return true;
            }

            Console.WriteLine("Datos incorrectos");
        }
    }
}

class Program
{
    static void Main()
    {
        Login login = new Login();

        if (login.IniciarSesion())
        {
            MenuPrincipal();
        }
    }

    static void MenuPrincipal()
    {
        int opcion;

        do
        {
            Console.WriteLine("-------- JUEGO DE TABLERO --------");
            Console.WriteLine("1. Iniciar partida");
            Console.WriteLine("2. Ver reglas del juego");
            Console.WriteLine("3. Ver puntaje más alto");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Iniciando partida...");
                    break;

                case 2:
                    Console.WriteLine("Ver reglas del juego...");
                    break;

                case 3:
                    Console.WriteLine("Ver puntaje más alto...");
                    break;

                case 4:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("La opción no es válida");
                    break;
            }

        } while (opcion != 4);
    }
}
