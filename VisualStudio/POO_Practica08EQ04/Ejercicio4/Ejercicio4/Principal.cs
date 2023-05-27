/*
Arriaga Mejía José Carlos
Fragoso Islas Ana Cecilia
Medina Perabeles Rodrigo
Pérez Duarte Brenda Elizabeth

 El cliente requiere una programa que simule el tiempo de vida de una lavadora y una television, el tiempo de vida se aumentara cada vez que se encienda el aparato
 y tendra un rango de 4-10 de encendidos y podra aplicar su garantia solo si el aparato se encuentra descompuesto,
 la lavadaora y la television ya estaran registradas para cuando se realice la garantia.
 */
using System;
namespace Ejercicio4
{
    class Principal
    {
        static void Main(string[] args)
        {
            int op, op1;
            Lavadora Lav = new Lavadora();
            Television TV = new Television();
            TV.iniciarTV();
            Lav.IniciarLav();
            TV.TiempoVida();
            Lav.TiempoVida();

            do
            {
                Console.Clear();
                Console.Write("Que aparato desea usar\n" +
                    "1)Televisor\n" +
                    "2)Lavadora\n" +
                    "3)Salir\n" +
                    "Opcion: ");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Console.Write("Ingrese la accion que quiere realizarn con el televisor.\n" +
                                "1)Encender\n" +
                                "2)Garantia\n" +
                                "3)Salir\n" +
                                "Opcion: ");
                            op1 = Convert.ToInt32(Console.ReadLine());
                            switch (op1)
                            {
                                case 1:
                                    TV.Encender();
                                    break;
                                case 2:
                                    TV.Garantia();
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    Console.Write("Dejando de usar el televisor\n" +
                                        "presione cualquier tecla para continuar.");
                                    Console.ReadLine();
                                    break;
                                default:
                                    Console.Write("Opcion invalida\n" +
                                        "Presione una tecla paraa continuar.");
                                    Console.ReadLine();
                                    break;
                            }
                        } while (op1 != 3);
                        break;
                    case 2:
                        do
                        {
                            Console.Clear();
                            Console.Write("Ingrese la accion que quiere realizar con la lavadora.\n" +
                                "1)Encender\n" +
                                "2)Garantia\n" +
                                "3)Salir\n" +
                                "Opcion: ");
                            op1 = Convert.ToInt32(Console.ReadLine());
                            switch (op1)
                            {
                                case 1:
                                    Lav.Encender();
                                    break;
                                case 2:
                                    Lav.Garantia();
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    Console.Write("Dejando de usar la lavadora\n" +
                                        "presione cualquier tecla para continuar.");
                                    Console.ReadLine();
                                    break;
                                default:
                                    Console.Write("Opcion invalida\n" +
                                        "Presione una tecla paraa continuar.");
                                    Console.ReadLine();
                                    break;
                            }
                        } while (op1 != 3);
                        break;
                    case 3:
                        Console.Write("Saliendo del programa\n" +
                            "presione cualquier tecla para continuar.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Write("Opcion invalida\n" +
                                       "Presione una tecla paraa continuar.");
                        Console.ReadLine();
                        break;
                }

            } while (op != 3);
            
        }
    }
}
