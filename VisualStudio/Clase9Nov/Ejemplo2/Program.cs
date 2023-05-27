using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animalito = new Animal("Animalito", 23.4);
            Carnivoro leon = new Carnivoro();
            herbivoro tortuga = new herbivoro();
            leon.Comer();
            leon.Dormir();
            leon.nombre = "leoncito";
            leon.GetNombre();
            tortuga.nombre = "Leonardo";
            tortuga.GetNombre();
            tortuga.Comer();
            tortuga.Dormir();
            
            

            Console.ReadLine();
        }
    }
}
