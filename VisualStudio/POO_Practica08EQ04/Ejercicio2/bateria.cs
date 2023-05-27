using System;
namespace p8ejercicio2
{
    public class bateria : Instrumentos 
    {
        public bateria()
        {

        }
        public void añadirpieza()
        {
            Console.WriteLine("La pieza está siendo añadida...");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("¡Pieza añadida!");
        }
        override public void cambiarPieza()
        {
            Console.WriteLine("Una pieza de tu bateria está dañada. :(");
            Console.WriteLine("Presiona 1 para cambiarla: ");
            int cbateria = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("La pieza está siendo cambiada...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("¡Pieza reemplazada! Recogela en el pasillo 4. :) ");
        }
        public override void tocarInstrumento()
        {
            Console.WriteLine("Tocando Ride de Twenty One Pilots...");
            Console.WriteLine("Gran, gran canción. :))");
        }
    }
}
