/*
Arriaga Mejía José Carlos
Descripción
Crear un programa que pida 20 números y los guarde en un arreglo, leer los 20 números y clasificarlos en 2 arreglos:
•numerosPositivos y numerosNegativos
•Mostrar la lista de los tres arreglos
 */
using System;
namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] num = new double[20];
            double[] pos = new double[20];
            double[] neg = new double[20];
            int p = 0, n = 0;
            Console.WriteLine("Programa que separara 20 numeros ingresados por el usuario en " +
                "positivos o negativos, considerando al 0 como positivo.");
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine("Ingrese el numero {0}", i + 1);
                    //try
                    //{
                    num[i] = Convert.ToDouble(Console.ReadLine());
                    //}

                    if (num[i] < 0)
                    {
                        neg[n] = num[i];
                        n++;
                    }
                    else
                    {
                        pos[p] = num[i];
                        p++;
                    }
                }
                Console.WriteLine("Arreglo con los 20 numeros:");
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("[{0}] ", num[i]);
                }
                Console.WriteLine("\nArreglo con los numeros positivos:");
                for (int i = 0; i < p; i++)
                {
                    Console.Write("[{0}] ", pos[i]);
                }
                Console.WriteLine("\nArreglo con los numeros negativos:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("[{0}] ", neg[i]);
                }
                Console.Read();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Debe ingresar un numero, reinice el programa.");
                Console.Read();
            }
        }
    }
}
