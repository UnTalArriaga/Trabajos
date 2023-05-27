using System;

namespace ejercicio004
{
    public class restaurante
    {
        string platillo;
        int cantidad;
        string bebida;
        int mesa;

        //métodos 
        public restaurante()
        {

        }
        public void nuevaOrden()
        {
            Console.WriteLine("¿Qué deseas ordenar?");
        }
        public void revisarOrden()
        {

        }
        public void entregarOrden()
        {
            Console.WriteLine("Espera un momento, por favor. La orden está siendo entregada...");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("¡La orden fue entregada con éxito!");
        }
        public void guardaPlatillo(string plato)
        {
            platillo = plato;
        }
        public void guardaCantidad(int n)
        {
            cantidad = n;
        }
        public void guardaBebida(string soda)
        {
            bebida = soda;
        }
        public void guardaMesa(int posicion)
        {
            mesa = posicion;
        }
        //Métodos para guardar y mostrar los atributos
        public string obtenPlatillo()
        {
            Console.WriteLine(platillo);
            return platillo;
        }
        public int obtenCantidad()
        {
            Console.WriteLine("Pediste "+cantidad +" "+ platillo+ ".");
            return cantidad;
        }
        public string obtenBebida()
        {
            Console.WriteLine("Tu bebida es: " +bebida+ ".");
            return bebida;
        }
        public int obtenMesa()
        {
            Console.WriteLine("Tu mesa es la número " + mesa+ ".");
            return mesa;
        }

    }
}
