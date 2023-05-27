using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ejemplo2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lineasDelArchivo = new string[10];
            string archivoAleer = "datos.txt";
            string linea;
            int contador = 0;
            //Lee la información del archivo
            try
            {
                StreamReader sr = new StreamReader(archivoAleer);

                while ((linea = sr.ReadLine()) != null)
                {
                    lineasDelArchivo[contador] = linea;
                    Console.WriteLine(linea);
                    contador++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Se generó una excepción: "+e.Message);
            }
            //Proceso los datos
            string[] nombre = new string[contador];
            string[] apellido = new string[contador];
            string[] fuerza = new string[contador];
            string[] grupo = new string[contador];

            for(int i=0; i<contador; i++)
            {
                //separar cada campo Split()
                string[] datos = lineasDelArchivo[i].Split('|');
                for (int j=0; j<=nombre.Length; j++)
                {
                    if(j==0)
                        nombre[i] = datos[j];
                    if(j==1)
                        apellido[i] = datos[j];
                    if(j==2)
                        fuerza[i] = datos[j];
                    if(j==3)
                        grupo[i] = datos[j];
                }
                Console.WriteLine("Linea {0}: nombre[{1}]: {2}, apellido[{1}]: {3}, fuerza[{1}]: {4}, grupo[{1}]: {5}",
                        i+1,i,nombre[i], apellido[i], fuerza[i], grupo[i]);
            }
            /*Pedir información
             * Guardar la información (FileMode.Append)
             */



            Console.ReadLine();
        }
    }
}
