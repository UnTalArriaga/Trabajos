using System;
namespace Ejercicio4
{
    class Lavadora:Aparato
    {
        //dimension [0] = ancho
        //dimension [1] = altura
        //dimension [2] = largo
        string[] dimensiones = new string[3];
        string[] ListLav = new string[6];
        public override void Encender()
        {
            if (GetGar() == false)
            {
                Console.WriteLine("Encendio la lavadora.");
                Vida();
                if (GetVida() == GetVidaUsada())
                {
                    Descomponer();
                }
                else
                {
                    Console.Write("Presione cualquier tecla para apagar la lavadora.");
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No se puede encender la lavadora, porque esta descompuesta.\n" +
                    "Aplique su garantia.");
                Console.ReadLine();
            }
        }
        public override void Descomponer()
        {
            Console.WriteLine("Se descompuso la lavadora.");
            SetGar(true);
        }
        public void IniciarLav()
        {
            ListLav[0] = "Samsung";
            ListLav[1] = "Wf20m5500ap/ax";
            ListLav[2] = "95867452";
            ListLav[3] = "20999.00";
            ListLav[4] = "Grafito";
            ListLav[5] = "20";
            dimensiones[0] = "68.6";
            dimensiones[1] = "98.4";
            dimensiones[2] = "98.4";
        }
        public override void Garantia()
        {
            if (GetGar() == true)
            {
                Console.WriteLine("La garantia sera aplicada a la sigueinte lavadora.");
                Console.Write("Marca: " + ListLav[0] + ".\n" +
                            "Modelo: " + ListLav[1] + ".\n" +
                            "Numero de Serie: " + ListLav[2] + ".\n" +
                            "Costo: $" + ListLav[3] + "\n" +
                            "Color: " + ListLav[4] + ".\n" +
                            "Carga Maxima: " + ListLav[5] + " Kg.\n" +
                            "Ancho: " + dimensiones[0] + " cm.\n" +
                            "Altura: " + dimensiones[1] + " cm.\n" +
                            "Largo: " + dimensiones[2] + " cm.\n\n");
            }
            else
            {
                Console.WriteLine("No se puede aplicar la garantia si no esta descompuesta la lavadora.");
            }
        }
    }
}
