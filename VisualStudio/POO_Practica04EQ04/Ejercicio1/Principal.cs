/*
Arriaga Mejia Jose Carlos
Fragoso Islas Ana Cecilia.
Medina Perabeles Rodrigo.
Perez Duarte Brenda Elizabeh.
 
Descripción:
Realizar las clases para los siguientes prismas: cubo, pirámide, cilindro y esfera.
En cada uno deberá de pedir si se quiere calcular el área, el perímetro y el volumen 
(determinar los atributos y métodos necesarios).
Elaborar un menú para seleccionar el prisma y la opción para seleccionar el área, perímetro o el volumen.
 */
using System;


namespace Ejercicio1
{
    class Principal
    {
        static void Main(string[] args)
        {
            try
            {
                int op, opi, opi2;
                Cubo c = new Cubo();
                Esfera e = new Esfera();
                Piramide p = new Piramide();
                Cilindro ci = new Cilindro();
                do
                {
                    Console.Clear();
                    Console.WriteLine("Este programa calculara el area, volumen y perimetro (Si es que se puede) " +
                        "de distintas figuras geometricas");
                    Console.Write("Menu\n" +
                        "1.-Cubo\n" +
                        "2.-Esfera\n" +
                        "3.-Cilindro\n" +
                        "4.-Piramide\n" +
                        "5.-Salir\n" +
                        "Elija una figura: ");
                    op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Eligio al Cubo, por favor ingrese el tamaño de su lado: ");
                            c.SetLado(Convert.ToSingle(Console.ReadLine()));
                            do
                            {
                                Console.Clear();
                                Console.Write("Cubo\n" +
                                    "Menu interno\n" +
                                    "1.-Perimetro\n" +
                                    "2.-Area\n" +
                                    "3.-Volumen\n" +
                                    "4.-Salir\n" +
                                    "Elija una opcion: ");
                                opi = Convert.ToInt32(Console.ReadLine());
                                switch (opi)
                                {
                                    case 1:
                                        c.SetPerimetro();
                                        Console.WriteLine("El perimetro del Cubo es de: " + c.GetPerimetro() + " unidades");
                                        break;
                                    case 2:
                                        c.SetArea();
                                        Console.WriteLine("El area del Cubo es: " + c.GetArea() + " unidades cuadradas");
                                        break;
                                    case 3:
                                        c.SetVolumen();
                                        Console.WriteLine("El volumen del Cubo es: " + c.Getvolumen() + " unidades cubicas");
                                        break;
                                    case 4:
                                        Console.WriteLine("Saliendo del menu del Cubo.");
                                        break;
                                    default:
                                        Console.WriteLine("Opcion Invalida.");
                                        break;
                                }
                                Console.Write("Presione cualquier tecla para continuar.");
                                Console.ReadLine();
                            } while (opi != 4);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Eligio a la Esfera, por favor ingrese el tamaño de su Radio: ");
                            e.SetRadio(Convert.ToSingle(Console.ReadLine()));
                            do
                            {
                                Console.Clear();
                                Console.Write("Esfera\n" +
                                    "Menu interno\n" +
                                    "1.-Area\n" +
                                    "2.-Volumen\n" +
                                    "3.-Salir\n" +
                                    "Elija una opcion: ");
                                opi = Convert.ToInt32(Console.ReadLine());
                                switch (opi)
                                {
                                    case 1:
                                        e.SetArea();
                                        Console.WriteLine("El area de la Esfera es: " + e.GetArea() + " unidades cuadradas");
                                        break;
                                    case 2:
                                        e.SetVolumen();
                                        Console.WriteLine("El volumen de la Esfera es: " + e.Getvolumen() + " unidades cubicas");
                                        break;
                                    case 3:
                                        Console.WriteLine("Saliendo del menu de la Esfera.");
                                        break;
                                    default:
                                        Console.WriteLine("Opcion Invalida.");
                                        break;
                                }
                                Console.Write("Presione cualquier tecla para continuar.");
                                Console.ReadLine();
                            } while (opi != 3);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Eligio al Cilindro, por favor ingrese el tamaño del Radio de la base: ");
                            ci.SetRadio(Convert.ToSingle(Console.ReadLine()));
                            Console.WriteLine("Ingrese la altura del Cilindro: ");
                            ci.SetAltura(Convert.ToSingle(Console.ReadLine()));
                            do
                            {
                                Console.Clear();
                                Console.Write("Cilindro\n" +
                                    "Menu interno\n" +
                                    "1.-Area\n" +
                                    "2.-Volumen\n" +
                                    "3.-Salir\n" +
                                    "Elija una opcion: ");
                                opi = Convert.ToInt32(Console.ReadLine());
                                switch (opi)
                                {
                                    case 1:
                                        ci.SetArea();
                                        Console.WriteLine("El area de la Cilindro es: " + ci.GetArea() + " unidades cuadradas");
                                        break;
                                    case 2:
                                        ci.SetVolumen();
                                        Console.WriteLine("El volumen de la Cilindro es: " + ci.Getvolumen() + " unidades cubicas");
                                        break;
                                    case 3:
                                        Console.WriteLine("Saliendo del menu de la Cilindro.");
                                        break;
                                    default:
                                        Console.WriteLine("Opcion Invalida.");
                                        break;
                                }
                                Console.Write("Presione cualquier tecla para continuar.");
                                Console.ReadLine();
                            } while (opi != 3);
                            break;
                        case 4:
                            do
                            {
                                Console.Clear();
                                Console.Write("Piramide\n" +
                                   "Menu interno\n" +
                                   "1.-Triangulo\n" +
                                   "2.-Cuadrilatero\n" +
                                   "3.-Poligono de 5 lados o mas lados\n" +
                                   "4.-Salir\n" +
                                   "Elija la figura que tiene como base de la Piramide: ");
                                opi = Convert.ToInt32(Console.ReadLine());
                                switch (opi)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.Write("Piramide Triangular (Tetraedro)\n" +
                                            "Ingrese el tamaño del lado: ");
                                        p.SetLado(Convert.ToSingle(Console.ReadLine()));
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Tetraedro");
                                            Console.Write("Menu interno 2\n" +
                                               "1.-Area\n" +
                                               "2.-Volumen\n" +
                                               "3.-Perimetro\n" +
                                               "4.-Salir\n" +
                                               "Elija una opcion: ");
                                            opi2 = Convert.ToInt32(Console.ReadLine());
                                            switch (opi2)
                                            {
                                                case 1:
                                                    p.SetAT();
                                                    Console.WriteLine("El area de la piramide es: " + p.GetArea() +  " unidades cuadradas");
                                                    break;
                                                case 2:
                                                    p.SetVT();
                                                    Console.WriteLine("El volumen de la piramide es: " + p.GetVolumen() +  " unidades cubicas");
                                                    break;
                                                case 3:
                                                    p.SetPT();
                                                    Console.WriteLine("El perimetro de la piramide es: " + p.GetP() + " unidades");
                                                    break;
                                                case 4:
                                                    Console.WriteLine("Saliendo del menu del Tetraedro.");
                                                    break;
                                                default:
                                                    Console.WriteLine("Opcion Invalida.");
                                                    break;
                                            }
                                            Console.Write("Presione cualquier tecla para continuar.");
                                            Console.ReadLine();
                                        } while (opi2 != 4);
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.Write("Piramide con un cuadrilatero de base\n" +
                                            "Ingrese el tamaño del lado menor de la base: ");
                                        p.SetLado(Convert.ToSingle(Console.ReadLine()));
                                        Console.Write("Ingrese el valor del lado mayor de la base: ");
                                        p.SetLado2(Convert.ToSingle(Console.ReadLine()));
                                        Console.Write("Ingrese la altura de la piramide: ");
                                        p.SetAltura(Convert.ToSingle(Console.ReadLine()));
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Piramide con un cuadrilatero de base");
                                            Console.Write("Menu interno 2\n" +
                                                "1.-Area\n" +
                                                "2.-Volumen\n" +
                                                "3.-Perimetro\n" +
                                                "4.-Salir\n" +
                                                "Elija una opcion: ");
                                            opi2 = Convert.ToInt32(Console.ReadLine());
                                            switch (opi2)
                                            {
                                                case 1:
                                                    p.SetAC();
                                                    Console.WriteLine("El area de la piramide es: " + p.GetArea() +  " unidades cuadradas");
                                                    break;
                                                case 2:
                                                    p.SetVC();
                                                    Console.WriteLine("El volumen de la piramide es: " + p.GetVolumen() + " unidades cubicas");
                                                    break;
                                                case 3:
                                                    p.SetPC();
                                                    Console.WriteLine("El perimetro de la piramide es: " + p.GetP() + " unidades");
                                                    break;
                                                case 4:
                                                    Console.WriteLine("Saliendo del menu de la Piramide con un cuadrilatero de base.");
                                                    break;
                                                default:
                                                    Console.WriteLine("Opcion Invalida.");
                                                    break;
                                            }
                                            Console.Write("Presione cualquier tecla para continuar.");
                                            Console.ReadLine();
                                        } while (opi2 != 4);
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.Write("Piramide con un poligono de 5 o mas lados de base\n" +
                                            "Ingrese el tamaño de una lado de la base: ");
                                        p.SetLado(Convert.ToSingle(Console.ReadLine()));
                                        Console.Write("Ingrese el numeros de lados que tiene la base: ");
                                        p.SetNumLados(Convert.ToInt32(Console.ReadLine()));
                                        Console.Write("Ingrese la altura de la piramide: ");
                                        p.SetAltura(Convert.ToSingle(Console.ReadLine()));
                                        do
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Piramide con un poligono de " + p.GetNumLados() + " lados de base");
                                            Console.Write("Menu interno 2\n" +
                                                "1.-Area\n" +
                                                "2.-Volumen\n" +
                                                "3.-Perimetro\n" +
                                                "4.-Salir\n" +
                                                "Elija una opcion: ");
                                            opi2 = Convert.ToInt32(Console.ReadLine());
                                            switch (opi2)
                                            {
                                                case 1:
                                                    p.SetAP();
                                                    Console.WriteLine("El area de la piramide es: " + p.GetArea() + " unidades cuadradas");
                                                    break;
                                                case 2:
                                                    p.SetVP();
                                                    Console.WriteLine("El volumen de la piramide es: " + p.GetVolumen() + " unidades cubicas");
                                                    break;
                                                case 3:
                                                    p.SetPP();
                                                    Console.WriteLine("El perimetro de la piramide es: " + p.GetP() + " unidades");
                                                    break;
                                                case 4:
                                                    Console.WriteLine("Saliendo del menu de la Piramide con un poligono de 5 " +
                                                        "o mas lados de base.");
                                                    break;
                                                default:
                                                    Console.WriteLine("Opcion Invalida.");
                                                    break;
                                            }

                                            Console.Write("Presione cualquier tecla para continuar.");
                                            Console.ReadLine();
                                            
                                        } while (opi2 != 4);
                                        break;
                                    case 4:
                                        Console.WriteLine("Saliendo del menu de las Piramides.");
                                        Console.Write("Presione cualquier tecla para continuar.");
                                        Console.ReadLine();
                                        break;
                                        
                                    default:
                                        Console.WriteLine("Opcion Invalida.");
                                        Console.Write("Presione cualquier tecla para continuar.");
                                        Console.ReadLine();
                                        break;
                                }
                            } while (opi!=4);
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del programa.");
                            Console.Write("Presione cualquier tecla para continuar.");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Opcion Invalida.");
                            Console.Write("Presione cualquier tecla para continuar.");
                            Console.ReadLine();
                            break;
                    }
                } while (op != 5);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato de ingreso, por favor reinicie el programa.");
                Console.Read();
            }
        }
    }
}
