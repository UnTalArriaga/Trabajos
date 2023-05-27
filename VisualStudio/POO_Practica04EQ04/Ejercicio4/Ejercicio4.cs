/*
Carlos Arriaga.
Ana Fragoso.
Rodrigo Medina.
Brenda Pérez.
Practica 04 - ejercicio 4
Descripción: Realizar un programa que simule las órdenes que ingresan a la
cocina de un restaurante.
Equipo 04.
22 / 10 / 20
*/

using System;

namespace ejercicio004
{
    class Program
    {
        static void Main(string[] args)
        {
            restaurante simulador = new restaurante();
            int op;
            string platillo;
            do
            {
                Console.Clear();
                Console.WriteLine("¡Hola!, bienvenido a The Ledbury. :)");
                Console.WriteLine("¿Qué deseas hacer?");
                Console.Write("\n1.Ingresar nueva orden.\n2.Revisar orden.\n3.Entregar orden.\n4.Salir\n");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine("¿Qué se te antoja hoy?");
                        platillo = Console.ReadLine();
                        simulador.guardaPlatillo(platillo);
                        Console.WriteLine("¿Qué cantidad de " + platillo + "?");
                        simulador.guardaCantidad(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("¡Perfecto!\n¿Qué apeteces para tomar?");
                        simulador.guardaBebida(Console.ReadLine());

                        Console.WriteLine("¡Buena elección!\nPor último, ¿cuál es tu número de mesa?");
                        simulador.guardaMesa(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("Tu orden ha sido enviada. ¡Gracias!");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Tu orden es: ");
                        simulador.obtenPlatillo();
                        simulador.obtenCantidad();
                        simulador.obtenBebida();
                        simulador.obtenMesa();
                        Console.ReadLine();
                        break;

                    case 3:
                        simulador.entregarOrden();
                        Console.ReadLine();
                        break;
                }
            }
            while (op != 4);
        }
    }
}