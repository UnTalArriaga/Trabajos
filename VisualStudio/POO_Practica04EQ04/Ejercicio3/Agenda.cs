/*  Arriaga Mejía José Carlos
    Fragoso Islas Ana Cecilia
    Medina Perabeles Rodrigo
    Pérez Duarte Brenda Elizabeth

    Práctica 1 - Ejemplo 7
            Descripción: Se realizará una agenda de contactos con capacidad de 4 contactos, con las opciones de agregar contacto,
            buscar contacto y ver contacto.
    Equipo : 04
    Fecha 22/10/2020*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica4
{
    class Agenda
    {

        static void Main(string[] args)
        {
            string info;
            int rep, opc; 
            int NC = 0;
            int tel;
            Contactos Contacto1 = new Contactos();
            Contactos Contacto2 = new Contactos();
            Contactos Contacto3 = new Contactos();
            Contactos Contacto4 = new Contactos();
            do
            {
                Console.WriteLine("Bienvenido a la agenda poo free, selecciona la acción a realizar: \n1. Guardar contacto\n2. Buscar cantacto" +
                                   "\n3. Ver Contactos");

                opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        switch (NC)
                        {
                            case 0:
                                NC = NC + 1;
                                Console.WriteLine("Ingresa el nombre del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto1.Setnombre(info);
                                Console.WriteLine("Ingresa el apellido del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto1.Setapellido(info);
                                Console.WriteLine("Ingresa el telefono del contacto {0}:", NC);
                                tel = (int)Convert.ToInt64(Console.ReadLine());
                                Contacto1.Settelefono(tel);
                                Console.WriteLine("Ingresa el correo del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto1.Setcorreo(info);
                                Console.WriteLine("Ingresa la dirección del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto1.Setdireccion(info);
                                break;
                            case 1:
                                NC = NC + 1;
                                Console.WriteLine("Ingresa el nombre del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto2.Setnombre(info);
                                Console.WriteLine("Ingresa el apellido del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto2.Setapellido(info);
                                Console.WriteLine("Ingresa el telefono del contacto {0}:", NC);
                                tel = (int)Convert.ToInt64(Console.ReadLine());
                                Contacto2.Settelefono(tel);
                                Console.WriteLine("Ingresa el correo del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto2.Setcorreo(info);
                                Console.WriteLine("Ingresa la dirección del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto2.Setdireccion(info);
                                break;
                            case 2:
                                NC = NC + 1;
                                Console.WriteLine("Ingresa el nombre del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto3.Setnombre(info);
                                Console.WriteLine("Ingresa el apellido del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto3.Setapellido(info);
                                Console.WriteLine("Ingresa el telefono del contacto {0}:", NC);
                                tel = (int)Convert.ToInt64(Console.ReadLine());
                                Contacto3.Settelefono(tel);
                                Console.WriteLine("Ingresa el correo del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto3.Setcorreo(info);
                                Console.WriteLine("Ingresa la dirección del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto3.Setdireccion(info);
                                break;
                            case 3:
                                NC = NC + 1;
                                Console.WriteLine("Ingresa el nombre del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto4.Setnombre(info);
                                Console.WriteLine("Ingresa el apellido del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto4.Setapellido(info);
                                Console.WriteLine("Ingresa el telefono del contacto {0}:", NC);
                                tel = (int)Convert.ToInt64(Console.ReadLine());
                                Contacto4.Settelefono(tel);
                                Console.WriteLine("Ingresa el correo del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto4.Setcorreo(info);
                                Console.WriteLine("Ingresa la dirección del contacto {0}:", NC);
                                info = Console.ReadLine();
                                Contacto4.Setdireccion(info);
                                break;
                        }
                        break;
                    case 2:
                        int Con = 1;
                        Console.WriteLine("Escribe el nombre a buscar");
                        string nom = Console.ReadLine();
                        if (nom == Contacto1.Getnombre())
                        Console.WriteLine("Los datos datos del contacto {0} son: Nombre: {1}\nApellido: {2}\nTelefono: {3}\n"
                            +"Correo: {4}\nDirección: {5}",
                            Con, Contacto1.Getnombre(), Contacto1.Getapellido(), Contacto1.Gettelefono(), Contacto1.Getcorreo(),
                            Contacto1.Getdirecion());
                        else if (nom == Contacto2.Getnombre())
                            Console.WriteLine("Los datos datos del contacto {0} son: Nombre: {1}\nApellido: {2}\nTelefono: {3}\n"
                             + "Correo: {4}\nDirección: {5}",
                             Con + 1, Contacto2.Getnombre(), Contacto2.Getapellido(), Contacto2.Gettelefono(), Contacto2.Getcorreo(),
                             Contacto2.Getdirecion());
                        else if (nom == Contacto3.Getnombre())
                            Console.WriteLine("Los datos datos del contacto {0} son: Nombre {1}\nApellido {2}\nTelefono {3}\n"
                             + "Correo {4}\nDirección {5}",
                             Con + 2, Contacto3.Getnombre(), Contacto3.Getapellido(), Contacto3.Gettelefono(), Contacto3.Getcorreo(),
                             Contacto3.Getdirecion());
                        else if (nom == Contacto4.Getnombre())
                            Console.WriteLine("Los datos datos del contacto {0} son: Nombre {1}\nApellido {2}\nTelefono {3}\n"
                             + "Correo {4}\nDirección {5}",
                             Con + 3, Contacto4.Getnombre(), Contacto4.Getapellido(), Contacto4.Gettelefono(), Contacto4.Getcorreo(),
                             Contacto4.Getdirecion());
                        break;
                    case 3:
                        int Cont = 1;
                        Console.WriteLine("Los contactos que tienes guardados son:");
                        Console.WriteLine("Datos del contacto {0}:\nNombre {1}\nApellido {2}\nTelefono {3}\nCorreo {4}\nDirección {5}",
                            Cont, Contacto1.Getnombre(), Contacto1.Getapellido(), Contacto1.Gettelefono(), Contacto1.Getcorreo(),
                            Contacto1.Getdirecion());

                        Console.WriteLine("Datos del contacto {0}:\nNombre {1}\nApellido {2}\nTelefono {3}\nCorreo {4}\nDirección {5}",
                            Cont + 1, Contacto2.Getnombre(), Contacto2.Getapellido(), Contacto2.Gettelefono(), Contacto2.Getcorreo(),
                            Contacto2.Getdirecion());

                        Console.WriteLine("Datos del contacto {0}:\nNombre {1}\nApellido {2}\nTelefono {3}\nCorreo {4}\nDirección {5}",
                            Cont + 2, Contacto3.Getnombre(), Contacto3.Getapellido(), Contacto3.Gettelefono(), Contacto3.Getcorreo(),
                            Contacto3.Getdirecion());

                        Console.WriteLine("Datos del contacto {0}:\nNombre: {1}\nApellido: {2}\nTelefono: {3}\nCorreo: {4}\nDirección: {5}",
                            Cont + 3, Contacto4.Getnombre(), Contacto4.Getapellido(), Contacto4.Gettelefono(), Contacto4.Getcorreo(),
                            Contacto4.Getdirecion());
                        break;
                }
                Console.WriteLine("Si desea repetir la acción pulse 1, si desea salir pulse 2.");
                rep = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (rep != 2);
        }
    }
}

