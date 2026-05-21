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
    public int turno = 1;
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

  
    public void SistemaTurnos()
    {
        while (true)
        {
            Mostrar();

            Console.WriteLine();

            if (turno == 1)
            {
                Console.WriteLine("Turno del Jugador 1");
            }
            else
            {
                Console.WriteLine("Turno del Jugador 2");
            }

            Mover();

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }

    public void Mover()
    {
        while (true)
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

            bool movimientoValido = true;

            if (filaOrigen < 0 || filaOrigen > 7 || columnaOrigen < 0 || columnaOrigen > 7 ||
                filaDestino < 0 || filaDestino > 7 || columnaDestino < 0 || columnaDestino > 7)
            {
                Console.WriteLine("Movimiento fuera del tablero");
                movimientoValido = false;
            }

            if (movimientoValido && pieza[filaOrigen, columnaOrigen] == 0)
            {
                Console.WriteLine("No hay pieza en esa posición");
                movimientoValido = false;
            }

            if (movimientoValido)
            {
                int piezaOrigen = pieza[filaOrigen, columnaOrigen];
                int piezaDestino = pieza[filaDestino, columnaDestino];

                if (piezaOrigen <= 3 && turno == 2)
                {
                    Console.WriteLine("No puedes mover piezas del Jugador 1");
                    movimientoValido = false;
                }

                if (piezaOrigen >= 4 && turno == 1)
                {
                    Console.WriteLine("No puedes mover piezas del Jugador 2");
                    movimientoValido = false;
                }

                if (movimientoValido && piezaDestino != 0)
                {
                    if ((piezaOrigen <= 3 && piezaDestino <= 3) ||
                        (piezaOrigen >= 4 && piezaDestino >= 4))
                    {
                        Console.WriteLine("No puedes capturar tu propia pieza");
                        movimientoValido = false;
                    }
                }

                if (movimientoValido && (piezaOrigen == 1 || piezaOrigen == 4))
                {
                    movimientoValido = ValidarRey(filaOrigen, columnaOrigen, filaDestino, columnaDestino);
                }

                if (movimientoValido && (piezaOrigen == 2 || piezaOrigen == 5))
                {
                    movimientoValido = ValidarTorre(filaOrigen, columnaOrigen, filaDestino, columnaDestino);

                    if (movimientoValido)
                        movimientoValido = ValidarCaminoTorre(filaOrigen, columnaOrigen, filaDestino, columnaDestino);
                }

                if (movimientoValido && (piezaOrigen == 3 || piezaOrigen == 6))
                {
                    movimientoValido = ValidarSoldado(piezaOrigen, filaOrigen, filaDestino, columnaOrigen, columnaDestino);
                }

                if (movimientoValido)
                {
                    pieza[filaDestino, columnaDestino] = piezaOrigen;
                    pieza[filaOrigen, columnaOrigen] = 0;

                    Console.WriteLine("Movimiento realizado");

                  
                    if (turno == 1)
                    {
                        turno = 2;
                    }
                    else
                    {
                        turno = 1;
                    }

                    Console.WriteLine("Turno del Jugador " + turno);

                    break;
                }
            }
        }
    }

    public bool ValidarRey(int filaOrigen, int columnaOrigen, int filaDestino, int columnaDestino)
    {
        int diferenciaFila = filaDestino - filaOrigen;
        int diferenciaColumna = columnaDestino - columnaOrigen;

        if (diferenciaFila < 0)
            diferenciaFila = diferenciaFila * -1;

        if (diferenciaColumna < 0)
            diferenciaColumna = diferenciaColumna * -1;

        if (diferenciaFila > 1 || diferenciaColumna > 1)
        {
            Console.WriteLine("Movimiento inválido para el Rey");
            return false;
        }

        return true;
    }

    public bool ValidarTorre(int filaOrigen, int columnaOrigen, int filaDestino, int columnaDestino)
    {
        if (filaOrigen != filaDestino && columnaOrigen != columnaDestino)
        {
            Console.WriteLine("Movimiento inválido para la Torre");
            return false;
        }

        return true;
    }

    public bool ValidarSoldado(int pieza, int filaOrigen, int filaDestino, int columnaOrigen, int columnaDestino)
    {

        if (columnaDestino == columnaOrigen)
        {
            if (pieza == 3 && filaDestino == filaOrigen + 1)
                return true;

            if (pieza == 6 && filaDestino == filaOrigen - 1)
                return true;

            Console.WriteLine("Movimiento inválido para el Soldado");
            return false;
        }

        if (columnaDestino == columnaOrigen + 1 || columnaDestino == columnaOrigen - 1)
        {
            if (pieza == 3 && filaDestino == filaOrigen + 1)
                return true;

            if (pieza == 6 && filaDestino == filaOrigen - 1)
                return true;

            Console.WriteLine("Ataque inválido del Soldado");
            return false;
        }

        Console.WriteLine("Movimiento inválido para el Soldado");
        return false;
    }

    public bool ValidarCaminoTorre(int filaOrigen, int columnaOrigen, int filaDestino, int columnaDestino)
    {
        if (filaOrigen == filaDestino)
        {
            int inicio = Math.Min(columnaOrigen, columnaDestino) + 1;
            int fin = Math.Max(columnaOrigen, columnaDestino);

            for (int j = inicio; j < fin; j++)
            {
                if (pieza[filaOrigen, j] != 0)
                {
                    Console.WriteLine("La torre no puede atravesar piezas");
                    return false;
                }
            }
        }
        else if (columnaOrigen == columnaDestino)
        {
            int inicio;
            int fin;

            if (filaOrigen < filaDestino)
            {
                inicio = filaOrigen + 1;
                fin = filaDestino;
            }
            else
            {
                inicio = filaDestino + 1;
                fin = filaOrigen;
            }

            for (int i = inicio; i < fin; i++)
            {
                if (pieza[i, columnaOrigen] != 0)
                {
                    Console.WriteLine("La torre no puede atravesar piezas");
                    return false;
                }
            }
        }

        return true;
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

                    
                    tablero.SistemaTurnos();

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
