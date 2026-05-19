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

            if (usuario != null && contrasena != null &&
                usuario == Usuario && contrasena == Contraseña)
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
        login.IniciarSesion();
    }
}
