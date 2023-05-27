using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MisBibliotecas
{
    public class Class1
    {
        //atributos
        string nombre;
        int edad;
        public double altura;
        public double peso;
        bool genero; //0-> Hombre, 1-> Mujer
        //constructor(es)
        public Class1()
        {
            //constructor vacío
        }
        public Class1(string name)
        {
            nombre = name;
        }
        //métodos
            //Set (guardar información)
        public void setNombre(string n) { nombre = n; }
        public void setEdad(int valor) { edad = valor; }
        public void setGenero(bool gen) { genero = gen; }
            //Get (recuperar o mostrar información)
        public void RecuperaInfo()
        {
            /*
            Console.WriteLine("\nNombre: " + nombre +
                "\nEdad: " + edad +
                "\nGenero: " + genero);*/
            Console.WriteLine("\nNombre: "+nombre+
                "\nEdad: "+edad);
        }
        public void RecuperaInfo2()
        {
            //otra opción es crear un "duplicado del método" y pasarle el string corrrespondiente al método
        }
        public void RecuperaInfo3(string gener)
        {
            Console.WriteLine("\nNombre: " + nombre +
                "\nEdad: " + edad +
                "\nGenero: " + gener);
        }
        public bool RecuperaGenero() { return genero; }

    }
}
