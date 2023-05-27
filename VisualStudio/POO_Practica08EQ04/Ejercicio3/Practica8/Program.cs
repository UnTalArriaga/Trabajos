/*Arriaga Mejía José Carlos
    Fragoso Islas Ana Cecilia
    Medina Perabeles Rodrigo
    Pérez Duarte Brenda Elizabeth

    Práctica 1 - Ejemplo 7
            Descripción: Se realizará un sistema de gestion de la informacion de un aeropuerto con algunos datos importantes como
            las caracterizticas del vehículo y las llamadas a los pasajeros, aterrizajes, despegues, encedido y apagado del vehículo.
    Equipo : 04
    Fecha 25 / 11 / 2020 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica8
{
    class Program
    {
        static void Main(string[] args)
        {
            Avion avion1 = new Avion();
            Avion avion2 = new Avion();
            Helicoptero helicoptero1 = new Helicoptero();
            Helicoptero helicoptero2 = new Helicoptero();
            Avion [] Aviones = { avion1, avion2};
            Helicoptero[] Helicopteros = { helicoptero1, helicoptero2};
            int opcacc;
            do
            {
                Console.WriteLine("Bienvenido al sistema de informacion para vehículos Aereos del Aeropuerto"+
                    "\nSeleccione la opción que desee realizar:" +
                    "\n1)Ver datos del avión\n2)Ver datos del helicoptero\n3)Salir");
                opcacc = int.Parse(Console.ReadLine());
                switch (opcacc)
                {
                    case 1:
                        Console.WriteLine("Los datos de los aviones son los siguientes:");
                        int opcAvion = 1;
                        foreach (var avion in Aviones)
                        {
                            Console.WriteLine("Avión {0}", opcAvion);
                            Console.WriteLine(avion.tipoCombustible());
                            Console.WriteLine(avion.Modelo());
                            Console.WriteLine(avion.Pasajeros());
                            Console.WriteLine(avion.EncenderVehiculo());
                            Console.WriteLine(avion.ApagarVehiculoenVuelo());
                            Console.WriteLine(avion.SubirPasajeros());
                            Console.WriteLine(avion.Aterrizar());
                            Console.WriteLine(avion.NumeroTurbinas());
                            Console.WriteLine("\n");
                            opcAvion++;
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Los datos de los helicopteros son los siguiente:");
                        int opcHelicoptero = 1;
                        foreach (var Heli in Helicopteros)
                        {
                            Console.WriteLine("Avión {0}", opcHelicoptero);
                            Console.WriteLine(Heli.tipoCombustible());
                            Console.WriteLine(Heli.Modelo());
                            Console.WriteLine(Heli.Pasajeros());
                            Console.WriteLine(Heli.EncenderVehiculo());
                            Console.WriteLine(Heli.ApagarVehiculoenVuelo());
                            Console.WriteLine(Heli.SubirPasajeros());
                            Console.WriteLine(Heli.Aterrizar());
                            Console.WriteLine(Heli.NumeroHelices());
                            Console.WriteLine("\n");
                            opcHelicoptero++;
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opcacc != 3);
        }
    }
}