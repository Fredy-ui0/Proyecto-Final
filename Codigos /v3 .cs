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
abstract class Pieza
{
    public int Jugador;

    public Pieza(int jugador)
    {
        Jugador = jugador;
    }

    public abstract char Simbolo();
}
class Rey : Pieza
{
    public Rey(int jugador) : base(jugador)
    {

    }

    public override char Simbolo()
    {
        return (Jugador == 1) ? 'R' : 'r';
    }
}
class Torre : Pieza
{
    public Torre(int jugador) : base(jugador) { }

    public override char Simbolo()
    {
        return (Jugador == 1) ? 'T' : 't';
    }
}
class Soldado : Pieza
{
    public Soldado(int jugador) : base(jugador) { }

    public override char Simbolo()
    {
        return (Jugador == 1) ? 'S' : 's';
    }
}


class Tablero
{
    public int[,] pieza = new int[8, 8];

    public void Inicializar()
    {
       
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                pieza[i, j] = 0;
            }
        }

        
        pieza[7, 4] = 1;
        pieza[7, 0] = 2; 
        pieza[7, 7] = 2; 

        pieza[6, 0] = 3;
        pieza[6, 1] = 3;
        pieza[6, 2] = 3;
        pieza[6, 3] = 3;

        
        pieza[0, 4] = 4; 
        pieza[0, 0] = 5;
        pieza[0, 7] = 5; 

        pieza[1, 0] = 6;
        pieza[1, 1] = 6;
        pieza[1, 2] = 6;
        pieza[1, 3] = 6;
    }

    public void Mostrar()
    {
        Console.WriteLine("\n" + "  0 1 2 3 4 5 6 7");
        Console.WriteLine("   ----------------");

        for (int i = 0; i < 8; i++)
        {
            Console.Write(i + " | ");

            for (int j = 0; j < 8; j++)
            {
                Console.Write(pieza[i, j] + " ");
            }

            Console.WriteLine();
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
                    Console.WriteLine();
                    Console.WriteLine("Iniciando partida...");

                    Tablero tablero = new Tablero();
                    tablero.Inicializar();
                    tablero.Mostrar();

                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Ver reglas del juego...");
                    break;

                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Ver puntaje más alto...");
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("La opción no es válida");
                    break;
            }

        } while (opcion != 4);
    }
}
