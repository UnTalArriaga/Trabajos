/*
 * Ejemplo de repaso Bibliotecas (usa el proyecto MisBibliotecas)
 * 
 * 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MisBibliotecas;

namespace EjemploBibliotecas
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            int edad;
            bool genero;
            //Persona persona1 = new Persona();
            Console.Write("Ingresa tu nombre: ");
            nombre = Console.ReadLine();
            Class1 objeto = new Class1();
            Class1 objeto2 = new Class1(nombre);
            Console.Write("Ingresa tu edad: ");
            edad = Convert.ToInt32(Console.ReadLine());
            objeto2.setEdad(edad);
            Console.Write("Ingresa tu nombre: ");
            //nombre = Console.ReadLine();
            //objeto2.setNombre(nombre);
            objeto2.setNombre(Console.ReadLine()); //otro manera de asignar;
            Console.Write("Ingresa tu género (False->Hombre, True-> Mujer): ");
            genero = Convert.ToBoolean(Console.ReadLine()); //otra manera Convertir primero a entero y luego a booleano
            objeto2.setGenero(genero);
            objeto2.altura = 1.71;
            objeto2.peso = 69.9;
            objeto2.RecuperaInfo();
            bool gen = objeto2.RecuperaGenero();
            if (gen == false)
            {
                objeto2.RecuperaInfo3("Hombre");
            }
            else
            {
                objeto2.RecuperaInfo3("Mujer");
            }
            



            Console.ReadLine();
        }
    }
}
