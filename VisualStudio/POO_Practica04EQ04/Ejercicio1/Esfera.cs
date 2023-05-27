using System;

namespace Ejercicio1
{
    class Esfera
    {
        private float radio, area, volumen;
        public Esfera()
        {
            //Constructor por defecto
        }
        public void SetRadio(float radio)
        {
            if (radio < 0)
            {
                radio = -1 * radio;
                this.radio = radio;
                Console.WriteLine("No puede haber radios negativas, por lo tanto la convertimos en positivo.");
                Console.Write("Presione cualquier tecla para continuar.");
                Console.ReadLine();
            }
            else
            {
                this.radio = radio;
            }
            
        }
        public void SetArea()
        {
            this.area = 4*Convert.ToSingle((System.Math.PI))*radio*radio;

        }
        public float GetArea()
        {
            return this.area;
        }
        public void SetVolumen()
        {
            this.volumen = (4 * Convert.ToSingle((System.Math.PI)) * radio * radio * radio)/3;

        }
        public float Getvolumen()
        {
            return this.volumen;
        }
    }
}
