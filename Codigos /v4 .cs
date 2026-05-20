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
class Pieza
{
    public int Jugador;

    public Pieza(int jugador)
    {
        Jugador = jugador;
    }

    public virtual int Simbolo()
    {
        return 0;
    }
}
class Rey : Pieza
{
    public Rey(int jugador) : base(jugador)
    {

    }

    public override int Simbolo()
    {
        if (Jugador == 1)
        {
            return 1;
        }
        else
        {
            return 4;
        }
    }
}
class Torre : Pieza
{
    public Torre(int jugador) : base(jugador)
    {

    }

    public override int Simbolo()
    {
        if (Jugador == 1)
        {
            return 2;
        }
        else
        {
            return 5;
        }
    }
}
class Soldado : Pieza
{
    public Soldado(int jugador) : base(jugador)
    {

    }

    public override int Simbolo()
    {
        if (Jugador == 1)
        {
            return 3;
        }
        else
        {
            return 6;
        }
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
        Console.WriteLine("\n    0 1 2 3 4 5 6 7");
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
    public void Mover()
    {
        int filaOrigen;
        int columnaOrigen;
        int filaDestino;
        int columnaDestino;

        Console.WriteLine();
        Console.WriteLine("Mover pieza");

        Console.Write("Fila de origen: ");
        filaOrigen = int.Parse(Console.ReadLine());

        Console.Write("Columna de origen: ");
        columnaOrigen = int.Parse(Console.ReadLine());

        Console.Write("Fila de destino: ");
        filaDestino = int.Parse(Console.ReadLine());

        Console.Write("Columna destino: ");
        columnaDestino = int.Parse(Console.ReadLine());

        if (filaOrigen < 0 || filaOrigen > 7 || columnaOrigen < 0 || columnaOrigen > 7 || filaDestino < 0 || filaDestino > 7 || columnaDestino < 0 || columnaDestino > 7)
        {
            Console.WriteLine("Movimiento fuera del tablero");
            return;
        }

        if (pieza[filaOrigen, columnaOrigen] == 0)
        {
            Console.WriteLine("No hay pieza en esa posición");
            return;
        }

     
        if (pieza[filaDestino, columnaDestino] != 0)
        {
            Console.WriteLine("Has capturado una pieza enemiga!");
        }

        int valor = pieza[filaOrigen, columnaOrigen];

        pieza[filaDestino, columnaDestino] = valor;
        pieza[filaOrigen, columnaOrigen] = 0;

        Console.WriteLine("Movimiento realizado");
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
            Console.WriteLine();
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
                    tablero.Mover();


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
