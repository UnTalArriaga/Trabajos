using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplo2
{
    class Animal
    {
        //atributos
        public string nombre;
        double peso;
        //constructor
        public Animal()
        {

        }
        public Animal(string n, double p)
        {
            nombre = n;
            peso = p;
        }
        //métodos
        public virtual void Dormir()
        {
            Console.WriteLine("Durmiendo...");
        }
        public void Comer()
        {
            Console.WriteLine("Comiendo...");
        }
        public void GetNombre()
        {
            Console.WriteLine(nombre);
        }
    }
}
