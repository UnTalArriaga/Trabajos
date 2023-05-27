/*
Arriaga Mejía José Carlos
Descripción:
Realizar un programa que le pida al usuario una cadena, y posterior mente le pida un carácter a reemplazar.
*/
using System;
namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa que sustituira un caracter de una cadena.");
            string s1, c, r;
            Console.WriteLine("Ingrese la cadena:");
            s1 = Console.ReadLine();
            Console.Write("Ingrese el caracter que desea remplazar: ");
            c = Console.ReadLine();
            Console.Write("Ingrese el caracter por el que lo desea remplazar: ");
            r = Console.ReadLine();
            Console.WriteLine(s1.Replace(c, r));
            Console.Read();
        }
    }
}
