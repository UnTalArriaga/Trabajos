using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ejemplo1
{
    class Cajero
    {

        private double r;


        public int op;



        public void menu(string a)
        {
            Console.WriteLine("Hola Sr(a)." + a + " que operacion deseas realizar\n1.-Consulta de saldo" +
                "\n2.- Retiro" +
                "\n3.- Transferencia" +
                "\n4.- pago de servicio" +
                "\n5.- consultar info" +
                "\n6.- cerrar sesion");

        }

        public void consultasaldo(double s, string a)
        {
            Console.Clear();
            Console.WriteLine("Bienvenido Sr(a). " + a + "\nSu saldo actual es de: $ " + s);
            Console.WriteLine("Presione cualquier tecla para continuar y luego oprima ENTER.");
            Console.ReadLine();
        }
        public double retiro(double s, string a)
        {
            do
            {
                op = 0;
                Console.Clear();
                Console.WriteLine("Bienvenido Sr(a). " + a + "\nSu saldo actual es de: $ " + s);
                Console.WriteLine("Cuanto desea retirar: ");
                r = Convert.ToDouble(Console.ReadLine());
                if (r < 0 || r > s)
                {
                    op++;
                    Console.WriteLine("Lo siento. Esa cantidad no es valida." +
                        "\n...");
                    Thread.Sleep(2000);
                }
                else
                {
                    s = s - r;
                    Console.WriteLine("...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Su retiro se realizó con exito.\n" +
                        "Ahora su saldo es de: $ " + s);
                    Console.Write("\n...");
                    Thread.Sleep(1000);
                    Console.Write("...");
                    Thread.Sleep(1000);
                    Console.Write("...");
                    Thread.Sleep(1000);

                }
            } while (op != 0);

            return s;



        }
        public double transferencia(double s, double ss, string a)
        {
            do
            {
                op = 0;
                Console.Clear();
                Console.WriteLine("Bienvenido Sr(a). " + a + "\nSu saldo actual es de: $ " + s);
                Console.WriteLine("Cuanto desea transferir: ");
                r = Convert.ToDouble(Console.ReadLine());
                if (r < 0 || r > s)
                {
                    op++;
                    Console.WriteLine("Lo siento. Esa cantidad no es valida." +
                        "\n...");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("...");
                    Thread.Sleep(2000);
                    ss = ss + r;
                    s = s - r;
                    Thread.Sleep(1200);
                    Console.WriteLine("Su transferencia se realizó con exito.\n" +
                        "Ahora su saldo es de: $ " + s);
                    Console.Write("\n...");
                    Thread.Sleep(1000);
                    Console.Write("...");
                    Thread.Sleep(1000);
                    Console.Write("...");
                    Thread.Sleep(1000);

                }
            } while (op != 0);

            return ss;

        }

        public double pago(double s, string a)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido(a) Sr(a). " + a);
                Console.WriteLine("\nTenemos pagos disponibles: \n1.-Agua\n2.-Gas\n3.-Luz");
                Console.WriteLine("Ingrese el numero del que desea pagar:");
                Console.ReadLine();
                Console.WriteLine("Ahora ingrese el monto a pagar: ");
                r = Convert.ToDouble(Console.ReadLine());
                if (r < 0 || r > s)
                {
                    op++;
                    Console.WriteLine("Lo siento. Esa cantidad no es valida." +
                        "\n...");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("...");
                    Thread.Sleep(2000);
                    s = s - r;
                    Console.WriteLine("Su pago se realizó con exito: ");
                    Console.WriteLine("Ahora su saldo es de $" + s);
                    Console.Write("\n...");
                    Thread.Sleep(1000);
                    Console.Write("...");
                    Thread.Sleep(1000);
                    Console.Write("...");
                    Thread.Sleep(1000);

                }

            } while (op != 0);

            return s;

        }

        public void info(string nombre, string apellido, string correo, double s, string empresa)
        {
            Console.Clear();
            Console.WriteLine("Nombre: " + nombre + "\nApellido: " + apellido + "\nCorreo: " + correo
                + "\nSaldo: $ " + s + "\nEmpresa: " + empresa);
            Console.WriteLine("Presione cualquier tecla para continuar y luego ENTER.");
            Console.ReadLine();
            Console.Write("\n...");
            Thread.Sleep(1000);
            Console.Write("...");
            Thread.Sleep(1000);
            Console.Write("...");
            Thread.Sleep(1000);


        }


    }
}
