/*
Arriaga Mejía José Carlos.
Fragoso Islas Ana Cecilia.
Medina Perabeles Rodrigo.
Pérez Duarte Brenda Elizabeth.

 * 2) Realizar un cajero automático, el usuario ingresará su número de cuenta y  contraseña para iniciar sesión, una vez dentro podrá 
 * realizar los siguiente en su  cuenta: 
a. Consultar Saldo 
b. Retirar efectivo 
c. Transferir a otro usuario (imprimir saldo del cliente) 
d. Pagar servicio 
El cuentahabiente tiene como datos: nombre, apellido, correo, saldo inicial ($1750),  empresa. 
El cuentahabiente a quien se le hará la transferencia tiene como saldo inicial $200. Al finalizar una transferencia se podrá
cerrar sesión y entrar a la sesión del  cuentahabiente que se le transfirió para ver su saldo nuevo. 

Equipo 04

22/10/2020
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Ejemplo1
{

    class Program
    {
        static void Main(string[] args)
        {
            Cajero c = new Cajero();
            /*Usuario 1:
            * id = 12345
            * contraseña = 12345
            * Nombre: Tony
            * Apellido: Stark
            * correo: ironman@avengers.com
            * Saldo inicial: $1750
            * Empresa: Avengers
            * */
            string n1 = "Tony", a1 = "Stark", correo1 = "ironman@avengers.com", em1 = "Avengers";
            double s1 = 1750;

            /*Usuario 2:
             * id = 98765
             * contraseña = 98765
             * Nombre: Steve
             * Apellido: Rogers
             * correo: capitanamerica@avengers.com
             * Saldo inicial: $0
             * Empresa: Avengers
             * */
            string n2 = "Steve", a2 = "Rogers", correo2 = "capitanamerica@avengers.com", em2 = "Avengers";
            double s2 = 200;

            double s1t = s1, s2t = s2, aux;



            string id, contra;
            int opc;
            string bucle1;
            do
            {
                bucle1 = "0";
                Console.Clear();
                Console.WriteLine("Hola, Bienvenido a su cajero automático           usuario1 : id=12345, contra=12345\n");
                Console.WriteLine("Ingrese su ID de usuario:                           usuario2 : id=98765, contra=98765");
                id = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Ahora ingrese su contraseña: ");
                contra = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Verificando");
                Console.Write("...");
                Thread.Sleep(1000);
                Console.Write("...");
                Thread.Sleep(1000);
                Console.Write("...");
                Thread.Sleep(1000);

                if (id == "12345" && contra == "12345")
                {
                    do
                    {
                        bucle1 = "1";
                        Console.Clear();
                        c.menu(a1);
                        opc = Convert.ToInt32(Console.ReadLine());
                        switch (opc)
                        {
                            case 1:
                                c.consultasaldo(s1, a1);
                                break;
                            case 2:
                                s1 = c.retiro(s1, a1);

                                break;
                            case 3:

                                s2 = c.transferencia(s1, s2, a1);
                                if (c.op == 0)
                                {
                                    aux = s2 - s2t;
                                    s1 = s1 - aux;
                                    s2t = s2;
                                }
                                break;
                            case 4:

                                s1 = c.pago(s1, a1);

                                break;
                            case 5:
                                c.info(n1, a1, correo1, s1, em1);
                                break;

                        }

                    } while (opc != 6);

                }
                else
                if (id == "98765" && contra == "98765")
                {
                    do
                    {
                        bucle1 = "1";
                        Console.Clear();
                        c.menu(a2);
                        opc = Convert.ToInt32(Console.ReadLine());
                        switch (opc)
                        {
                            case 1:
                                c.consultasaldo(s2, a2);
                                break;
                            case 2:
                                s1 = c.retiro(s2, a2);
                                break;
                            case 3:
                                s2 = c.transferencia(s2, s1, a2);
                                if (c.op == 0)
                                {
                                    aux = s1 - s1t;
                                    s2 = s2 - aux;
                                    s1t = s1;
                                }
                                break;
                            case 4:
                                s2 = c.pago(s2, a2);
                                break;
                            case 5:
                                c.info(n2, a2, correo2, s2, em2);
                                break;
                        }
                    } while (opc != 6);

                }
                else
                {
                    Console.WriteLine("\nSu ID y/o contraseña son incorrectos.\nDesea volver a intentar?:\nPresione 1 para si");
                    bucle1 = Convert.ToString(Console.ReadLine());
                    Console.Write("...");
                    Thread.Sleep(1000);
                    Console.Write("...");
                    Thread.Sleep(1000);
                    Console.Write("...");
                    Thread.Sleep(1000);

                }
                if (bucle1 != "1")
                    bucle1 = "0";

            } while (bucle1 != "0");

            Console.ReadLine();
        }
    }
}
