using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplo1
{
    class Borrador
    {
        //Atributos o propiedades
        string forma;
        string color;
        string material;

        //constructor
        public Borrador()
        {
            //constructor vacío, crea un nuevo objeto sin asignar datos a sus variables
        }
        
        //Constructor con argumentos
        public Borrador(string dato1, string dato2, string material)
        {
            this.forma = dato1;
            color = dato2;
            this.material = material;
        }

        //Métodos o acciones o funciones
        public void borrarPizarron()
        {
            Console.WriteLine("Pizarron Limpio");
        }

        public void Caer()
        {
            Console.WriteLine("Me caí del pizarron, levantame :'(");
        }

        public void LanzarBorrador()
        {
            Console.WriteLine("El borrador alcanzó una ditacia de 100mts");
        }

        //////Get y Set//////
        //
        //Métodos de recuperacion de información (Get)
        public string GetForma() //obtenForma() o tambien se puede llamar leeForma()
        {
            return forma; //retorna el valor para procesarlo posteriormente
        }
        public void leeForma() //obtenForma() o tambien se puede llamar leeForma()
        {
            Console.WriteLine("La forma del borrador es: "+forma); //retorna el valor para procesarlo posteriormente
        }
        public string GetMaterial()
        {
            return material;
        }
        public string GetColor()
        {
            return color;
        }

        //Métodos de asignación de información (Set)
        public void SetMaterial(string dato)
        {
            material = dato;
        }
        public void SetColor(string dato)
        {
            color = dato;
        }
        public void SetForma(string dato)
        {
            forma = dato;
        }
    }
}
