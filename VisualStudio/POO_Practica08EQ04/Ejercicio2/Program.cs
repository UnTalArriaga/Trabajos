/*
Carlos Arriaga.
Ana Fragoso.
Rodrigo Medina.
Brenda Pérez.

Práctica 08 - Ejercicio 2
     Descripción: Realizar un programa que simule algunas de las acciones que
                  se pueden hacer en una tienda de música. 

Equipo: 04
*/



using System;

namespace p8ejercicio2
{
    class MainClass
    {


        public static void Main(string[] args)
        {
            guitarra g1 = new guitarra();
            bateria b1 = new bateria();
            int op, o;

            Console.WriteLine("¡Bienvenido a Detroit! ¿Hacia dónde te gustaría dirigirte?: ");
            Console.WriteLine("1.- Departamento de guitarras.\n2.- Departamento de baterias.");
            int opc = Convert.ToInt32(Console.ReadLine());

            if (opc == 1)
            {
                do
                {
                    Console.WriteLine("¡Muy bien! ¿Qué deseas hacer? ");
                    Console.WriteLine("1.- Comprar una guitarra.\n2.- Probar una guitarra.\n3.- Cambiar pieza de guitarra.\n4.- Salir.");
                    op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("Ingresa la marca de tu agrado: ");
                            g1.guardaMarca(Console.ReadLine());
                            Console.WriteLine("Ingresa el modelo: ");
                            g1.guardaModelo(Console.ReadLine());
                            Console.WriteLine("Ingresa el número de serie: ");
                            g1.guardaNserie(Console.ReadLine());
                            Console.WriteLine("Ingresa el número de cuerdas: ");
                            g1.guardaNumero(Convert.ToInt16(Console.ReadLine()));
                            Console.WriteLine("¡Perfecto! Tu guitarra está disponible. Presiona 1 para comprarla: ");
                            int comprar = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("El pago está siendo procesado...");
                            System.Threading.Thread.Sleep(3000);
                            Console.WriteLine("\n¡Pago realizado! Recoge tu guitarra en el pasillo 2.");
                            Console.WriteLine("\n\nAntes de irte, te proporcionamos información sobre la guitarra que acabas de comprar.:)");
                            g1.obtenMaca();
                            g1.obtenModelo();
                            g1.obtenNserie();
                            Console.WriteLine("Número de cuerdas: " + g1.obtenNumero());

                            break;

                        case 2:
                            g1.tocarInstrumento();

                            break;

                        case 3:
                            g1.cambiarPieza();
                            break;

                        case 4:
                            Console.Clear();
                            break;

                    }

                } while (op == 4);


            }
            else if (opc == 2)
            {
                do
                {
                    Console.WriteLine("¡Bienvenido al departamento de baterias! ¿Qué deseas hacer?");
                    Console.WriteLine("1.- Comprar una bateria.\n2.- Probar una bateria.\n3.- Cambiar pieza de una bateria.\n4.- Salir.");
                    o = Convert.ToInt32(Console.ReadLine());

                    switch (o)
                    {
                        case 1:
                            Console.WriteLine("Ingresa la marca de tu interés: ");
                            b1.guardaMarca(Console.ReadLine());
                            Console.WriteLine("Ingresa el modelo: ");
                            b1.guardaModelo(Console.ReadLine());
                            Console.WriteLine("Ingresa el número de serie: ");
                            b1.guardaNserie(Console.ReadLine());
                            Console.WriteLine("Ingresa el número de platillos: ");
                            b1.guardaNumero(Convert.ToInt16(Console.ReadLine()));
                            Console.WriteLine("¡Felictaciones! La bateria de tu interés está disponible. :)");
                            Console.WriteLine("Presiona 1 para comprarla...");
                            int com = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Realizando pago...");
                            System.Threading.Thread.Sleep(3000);
                            Console.WriteLine("\n¡pago realizado con éxito! Recoge tu bateria en el pasillo 4.");
                            Console.WriteLine("\n\nAntes de irte, te mostramos la información de tu compra final...");
                            b1.obtenMaca();
                            b1.obtenModelo();
                            b1.obtenNserie();
                            Console.WriteLine("Número de platillos: " + b1.obtenNumero());

                            break;
                        case 2:
                            b1.tocarInstrumento();

                            break;
                        case 3:
                            b1.cambiarPieza();

                            break;

                        case 4:
                            Console.Clear();

                            break;
                    }

                } while (o == 4);

            } Console.ReadKey();

        }
    }
}
