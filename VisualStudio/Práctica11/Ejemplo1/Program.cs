using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; //Necesario para poder manipular archivos

namespace Ejemplo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //buffer- transmisión
            //Crear y Guardar en un archivo
            string nombreArchivo = "prueba.txt";
            FileStream crearArchivo = new FileStream(nombreArchivo,FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter escribir = new StreamWriter(crearArchivo);
            escribir.WriteLine("Esta es una linea que se va a guradar en mi archivo");
            escribir.WriteLine("Segunda Linea");
            /* Proceso
             * 
             * 
             * 
             * Writeline
             */

            escribir.Close();
            //Leer un archivo
            StreamReader leerArchivo = new StreamReader(nombreArchivo);
            string linea1 = leerArchivo.ReadLine();
            string linea2 = leerArchivo.ReadLine();
            leerArchivo.Close();
            Console.WriteLine("Info primera línea: " + linea1);
            Console.WriteLine("Info segunda línea: " + linea2);



            Console.ReadLine();
            
        }
    }
}
