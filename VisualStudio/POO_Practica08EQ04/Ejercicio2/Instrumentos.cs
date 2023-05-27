using System;
namespace p8ejercicio2
{
    public class Instrumentos
    {
        string marca, modelo, nSerie;
        int numero;
        public Instrumentos()
        {

        }
        public virtual void guardaMarca(string mark)
        {
            marca = mark;
        }
        public virtual void guardaModelo(string tipo)
        {
            modelo = tipo;
        }
        public virtual void guardaNserie(string ID)
        {
            nSerie = ID;
        }
        public virtual void guardaNumero(int n)
        {
            numero = n;
        }

        // ******** //

        public string obtenMaca()
        {
            Console.WriteLine("Marca: " + marca);
            return marca;
        }
        public string obtenModelo()
        {
            Console.WriteLine("Modelo: " + modelo);
            return modelo;
        }
        public string obtenNserie()
        {
            Console.WriteLine("Número de serie: " + nSerie);
            return nSerie;
        }
        public int obtenNumero()
        {
            return numero;
        }
        public virtual void tocarInstrumento()
        {
            Console.WriteLine("Presiona 1 para tocar una rola: ");
            int t = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Tocando To be so Lonely de Harry Styles...");
            Console.WriteLine("Qué gran canción :).");
        }
        public virtual void cambiarPieza()
        {
            Console.WriteLine("Algunas piezas de tu guitarra están dañadas, presiona 1 para cambiar: ");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("La pieza está siendo cambiada...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("¡Tu guitarra está como nueva! Recogela en el pasillo 2. :) ");
        }
    }
}
