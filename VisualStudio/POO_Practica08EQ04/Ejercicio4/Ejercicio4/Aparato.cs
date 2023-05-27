using System;
namespace Ejercicio4
{
    class Aparato
    {
        bool Gar = false;
        int vida, vidaUsada=0;
        public virtual void Encender() 
        {
            Console.WriteLine("Encendio el aparato.");
        }
        public virtual void Descomponer() 
        {
            Console.WriteLine("Se descompuso el aparato.");
            Gar = true; 
        }
        public virtual void Garantia() 
        { 
            if (Gar == true) 
            {
                Console.WriteLine("La garantia sera aplicada.");
            }
            else
            {
                Console.WriteLine("No se puede aplicar la garantia si no esta descompuesto.");
            }
        }
        public void SetGar(bool gar) { Gar = gar; }
        public bool GetGar() { return Gar; }
        public void TiempoVida() 
        {
            Random rnd = new Random();
            vida = rnd.Next(4, 10);
        }
        public void Vida() { vidaUsada++; }
        public int GetVidaUsada() { return vidaUsada; }
        public int GetVida() { return vida; }
    }
}
