using System;
namespace Ejercicio4
{
    class Television : Aparato
    {
        string[] ListTV = new string[6];
        public override void Encender()
        {
            if (GetGar() == false)
            {
                Console.WriteLine("Encendio el televisor.");
                Vida();
                if (GetVida() == GetVidaUsada())
                {
                    Descomponer();
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("Presione cualquier tecla para apagar el televisor.");
                    Console.ReadLine();
                }   
            }
            else
            {
                Console.WriteLine("No se puede encender el televisor, porque esta descompuesto.\n" +
                    "Aplique su garantia.");
                Console.ReadLine();
            }
        }
        public override void Descomponer()
        {
            Console.WriteLine("Se descompuso el televisor.");
            SetGar(true);
        }
        public void iniciarTV()
        {
            ListTV[0] = "Samsung";//marca
            ListTV[1] = "QN55Q900RBFXZX ";//modelo
            ListTV[2] = "945963452";//NumSer
            ListTV[3] = "44999.00";//Costo
            ListTV[4] = "55";//pulgadas   
            ListTV[5] = "7680x4320";//resolucion
        }
        public override void Garantia()
        {
            if (GetGar()== true)
            {
                Console.WriteLine("La garantia sera aplicada al siguente televisor.");
                Console.Write("Marca: " + ListTV[0] + ".\n" +
                      "Modelo: " + ListTV[1] + ".\n" +
                      "Numero de Serie: " + ListTV[2] + ".\n" +
                      "Costo: $" + ListTV[3] + "\n" +
                      "Tamaño: " + ListTV[4] + " Pulgadas.\n" +
                      "Resolucion: " + ListTV[5] + " Pixeles.\n\n");
            }
            else
            {
                Console.WriteLine("No se puede aplicar la garantia si no esta descompuesto el televisor.");
            }
        }
    }
}
