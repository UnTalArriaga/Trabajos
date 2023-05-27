using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //instancia del objeto (crear un objeto)
            Borrador borrador1 = new Borrador();            
            Borrador borrador2 = new Borrador("circular","rojo","plástico");
            char repetir;
            string dato;
            int opc;
            do
            {
                Console.WriteLine("Bienvenido\n1.- Asignar valores a mi borrador"+
                    "\n2.- Modificar Forma\n3.- Modificar Color\n4.-Modificar Material\n"
                    +"5.-Leer Info\n6.-Ejecutar acciones");
                opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Ingresa forma: ");
                        dato = Console.ReadLine();
                        borrador1.SetForma(dato);
                        Console.WriteLine("Ingresa color: ");
                        dato = Console.ReadLine();
                        borrador1.SetColor(dato);
                        Console.WriteLine("Ingresa material: ");
                        dato = Console.ReadLine();
                        borrador1.SetMaterial(dato);
                        break;
                    case 2:
                        Console.WriteLine("Ingresa forma: ");
                        dato = Console.ReadLine();
                        borrador1.SetForma(dato);
                        break;
                    case 3:
                        Console.WriteLine("Ingresa color: ");
                        dato = Console.ReadLine();
                        borrador1.SetColor(dato);
                        break;
                    case 4:
                        Console.WriteLine("Ingresa material: ");
                        dato = Console.ReadLine();
                        borrador1.SetMaterial(dato);
                        break;
                    case 5:
                        Console.WriteLine("Color: {0} Forma: {1} Material: {2}",
                        borrador1.GetColor(),
                        borrador1.GetForma(),
                        borrador1.GetMaterial());
                        borrador2.leeForma();
                        break;
                    case 6:
                        borrador1.borrarPizarron();
                        borrador1.LanzarBorrador();
                        borrador2.borrarPizarron();
                        break;
                    default:
                        Console.WriteLine("OPC no válida, formateando disco duro :( ");
                        break;
                }
                Console.WriteLine("Repetir? s Salir n");
                repetir = Convert.ToChar(Console.ReadLine());
            } while (repetir != 'n');


            Console.ReadLine();
        }
    }
}
