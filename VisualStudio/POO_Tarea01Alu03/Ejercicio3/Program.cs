/*
Arriaga Mejía José Carlos
Descripción
Programa que realiza la multiplicación de dos matrices de misma dimensión
 */
using System;
namespace Ejercicio3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {

                int m;
                Console.WriteLine("Programa para multiplicacion de funciones.");
                Console.Write("Ingrese el tamaño de las matrices cuadradas: ");
                m = Convert.ToInt32(Console.ReadLine());
                double[,] matriz1 = new double[m, m];
                double[,] matriz2 = new double[m, m];
                double[,] matriz = new double[m, m];
                double r;

                Console.WriteLine("Ingrese los valores de la matriz 1");
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("Valor [{0}][{1}]: ", i, j);
                        matriz1[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                }
                Console.WriteLine("Ingrese los valores de la matriz 2");
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("Valor [{0}][{1}]: ", i, j);
                        matriz2[i, j] = Convert.ToDouble(Console.ReadLine());
                    }
                }
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        r = 0;
                        for (int x = 0; x < m; x++)
                        {
                            r += matriz1[i, x] * matriz2[x, j];
                        }
                        matriz[i, j] = r;
                    }
                }
                Console.WriteLine("El resultado de la multiplicacion de matriz 1 x matriz 2 es:");
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(matriz[i, j] + " ");
                    }
                    Console.Write("\n");
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
