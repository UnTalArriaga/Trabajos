using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            int repetir, opcionTipoUsuario;
            double horas;
            do 
            {
                Console.WriteLine("Ingresa el tipo de usuario:\n1. Profesor\n2. Alumno");
                opcionTipoUsuario = Convert.ToInt32(Console.ReadLine());
                if(opcionTipoUsuario == 1)
                {
                    //usuario es profesor
                    Profesor profe1 = new Profesor();
                    Console.Write("Estimado profesor, gracias por usar nuestro sistema\n"+
                        "Ingresa tu nombre completo: ");
                    profe1.SetNombre(Console.ReadLine());
                    Console.WriteLine("Ingresa las horas a dar clase: ");
                    horas = Convert.ToDouble(Console.ReadLine());
                    if(horas < 10.5)
                    {
                        profe1.SetSueldo(1000);
                    }
                    else
                    {
                        profe1.SetSueldo(2500);
                    }
                    Console.WriteLine("Sus datos:\n"+
                        "Nombre: "+profe1.GetNombre()+
                        "\nSueldo: "+profe1.GetSueldo()+
                        "\nAcciones: ");
                    //no muestra los mensaje ya que nuestros métodos retornan una cadena!!
                    profe1.Asistir();
                    profe1.Ensenar();
                    Console.WriteLine("****************************************");
                    Console.WriteLine("Sus datos:\n" +
                        "Nombre: " + profe1.GetNombre() +
                        "\nSueldo: " + profe1.GetSueldo() +
                        "\nAcciones: "+ profe1.Asistir()+profe1.Ensenar());
                }
                else if(opcionTipoUsuario == 2)
                {
                    //usuario es alumno
                    Alumno alu1 = new Alumno();
                    string mensajeCalificacion;
                    Console.WriteLine("Estimado alumno, gracias por usar nuestro sistema\n" +
                        "Ingresa tu nombre completo: ");
                    //string nombre = Console.ReadLine(); alu1.SetNombre(nombre);
                    alu1.SetNombre(Console.ReadLine());
                    Console.Write("Ingresa tu promedio final: ");
                    alu1.SetCalificacion(Convert.ToInt32(Console.ReadLine()));
                    if (alu1.GetCalificacion() >=0 && alu1.GetCalificacion() <8)
                    {
                        mensajeCalificacion = "Recursas la materia -.-";
                    }
                    else if (alu1.GetCalificacion() <= 10)
                    {
                        mensajeCalificacion = "Aprobado :')";
                    }
                    else
                    {
                        //Console.WriteLine("Calificación no válida");
                        mensajeCalificacion = "Calificación no válida";
                    }
                    Console.WriteLine("Tus datos:\n" +
                        "Nombre: " + alu1.GetNombre() +
                        "\nPromedio: " + alu1.GetCalificacion() +
                        "\n"+mensajeCalificacion+
                        "\nAcciones: ");
                    //no muestra los mensaje ya que nuestros métodos retornan una cadena!!
                    alu1.Asistir();
                    alu1.Estudiar();
                    Console.WriteLine("****************************************");
                    Console.WriteLine("Tus datos:\n" +
                        "Nombre: " + alu1.GetNombre() +
                        "\nPromedio: " + alu1.GetCalificacion() +
                        "\n" + mensajeCalificacion +
                        "\nAcciones: "+ alu1.Asistir()+alu1.Estudiar());
                }
                else
                {
                    Console.WriteLine("Opoción no válida, borrando unidad C:/ jajajaja");
                    repetir = 50; //asiganación repetida/demás
                }
                Console.WriteLine("Deseas intentarlo otra vez? escribe 50" );
                repetir = Convert.ToInt32(Console.ReadLine());
                

            } while (repetir == 50);

            Console.ReadLine();
        }
    }
}
