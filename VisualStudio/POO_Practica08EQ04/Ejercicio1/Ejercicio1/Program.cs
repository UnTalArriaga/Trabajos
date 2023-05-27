/*
 * Programa para empresa de servicio de trasporte privado
 * para que sepa los datos de sus vahiculos, asi como su estado
 * actual(si esta encendido/apagado), y conocer si se suben mas pasajeros
 * a los establecidos
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Coche[] c = new Coche[5];
            Moto[] m = new Moto[5];
            int opc, bucle = 1, b = 1, cm= 0,cc=0 ,k;
            do
            {
                Console.Clear();
                Console.WriteLine("Agregar Moto.- Presione 1\nAgregar Coche.- Presione 2\nVer Info Motos.- Presione 3\nVer Info Coches.- Presione 4");
                opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        m[cm] = new Moto();
                        Console.WriteLine("Motocicleta: \n");
                        Console.WriteLine("Ingrese Marca: ");
                        m[cm].SetMarca(Convert.ToString(Console.ReadLine()));
                        Console.WriteLine("Ingrese Modelo: ");
                        m[cm].SetModelo(Convert.ToString(Console.ReadLine()));
                        Console.WriteLine("Ingresa numero de llantas contando refaccion: ");
                        m[cm].SetLLantas(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Ingrese numero de pasajeros: ");
                        m[cm].SetPasajeros(Convert.ToInt32(Console.ReadLine()));
                        cm++;
                        Console.WriteLine("Listo, regresara a menu para que seleccione ver info motos.");
                        Console.WriteLine("Presione Enter Para Continuar");
                        Console.ReadLine();

                        break;
                    case 2:
                        Console.Clear();
                        c[cc] = new Coche();
                        Console.WriteLine("Coche: \n");
                        Console.WriteLine("Ingrese Marca: ");
                        c[cc].SetMarca(Convert.ToString(Console.ReadLine()));
                        Console.WriteLine("Ingrese Modelo: ");
                        c[cc].SetModelo(Convert.ToString(Console.ReadLine()));
                        Console.WriteLine("Ingresa numero de llantas contando refaccion: ");
                        c[cc].SetLLantas(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Ingrese numero de pasajeros: ");
                        c[cc].SetPasajeros(Convert.ToInt32(Console.ReadLine()));
                        cc++;
                        Console.WriteLine("Listo, regresara a menu para que seleccione ver info motos.");
                        Console.WriteLine("Presione Enter Para Continuar");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        for(int i = 0; i < cm; i++)
                        {
                            k = i + 1;
                            Console.WriteLine("Moto: " +k);
                        }
                        opc = Convert.ToInt32(Console.ReadLine());
                        opc -=1;
                        Console.WriteLine("Marca: "+ m[opc].GetMarca());
                        
                        Console.WriteLine("Modelo: "+ m[opc].GetModelo());
                        
                        Console.WriteLine("Numero de llantas: "+ m[opc].GetLLantas());
                      
                        Console.WriteLine("Numero de Pasajeros: "+ m[opc].GetPasajeros());
                        
                        Console.WriteLine("\nEncender moto: Presione 1");
                        Console.WriteLine("Apagar moto: Presione 2");
                        Console.WriteLine("Subir Pasajeros: Presione 3");
                        Console.WriteLine("Salir: Presione 4");
                        b = 1;
                        do
                        {
                            opc = Convert.ToInt32(Console.ReadLine());
                            switch (opc)
                            {
                                case 1:
                                    Console.WriteLine("" + m[0].Encender());
                                    break;
                                case 2:
                                    Console.WriteLine("" + m[0].Apagar());
                                    break;
                                case 3:
                                    Console.WriteLine("" + m[0].SubirPasajeros());
                                    break;
                                case 4:
                                    b = 0;
                                    break;
                            }

                        } while (b != 0);
                        
                        break;
                    case 4:
                        Console.Clear();
                        for (int i = 0; i < cc; i++)
                        {
                            k = i + 1;
                            Console.WriteLine("Coche: " +k);
                        }
                        opc = Convert.ToInt32(Console.ReadLine());
                        opc -= 1;
                        Console.WriteLine("Marca: " + c[opc].GetMarca());
                        
                        Console.WriteLine("Modelo: " + c[opc].GetModelo());
                        
                        Console.WriteLine("Numero de llantas: " + c[opc].GetLLantas());
                        
                        Console.WriteLine("Numero de Pasajeros: " + c[opc].GetPasajeros());
                      
                        Console.WriteLine("\nEncender coche: Presione 1");
                        Console.WriteLine("Apagar coche: Presione 2");
                        Console.WriteLine("Subir Pasajeros: Presione 3");
                        Console.WriteLine("Salir: Presione 4");
                        b = 1;
                        do
                        {
                            opc = Convert.ToInt32(Console.ReadLine());
                            switch (opc)
                            {
                                case 1:
                                    Console.WriteLine("" + c[0].Encender());
                                    break;
                                case 2:
                                    Console.WriteLine("" + c[0].Apagar());
                                    break;
                                case 3:
                                    Console.WriteLine("" + c[0].SubirPasajeros());
                                    break;
                                case 4:
                                    b = 0;
                                    break;
                            }

                        } while (b != 0);


                        break;
                    
                }

            } while (bucle != 0);
           
             

        }
    }
}
