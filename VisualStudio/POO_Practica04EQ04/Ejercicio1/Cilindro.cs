using System;

namespace Ejercicio1
{
    class Cilindro
    {
        private float area, volumen, radio, altura;

        public Cilindro()
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
        public void SetAltura(float altura)
        {
            if (altura < 0)
            {
                altura = -1 * altura;
                this.altura = altura;
                Console.WriteLine("No puede haber alturas negativas, por lo tanto la convertimos en positivo.");
                Console.Write("Presione cualquier tecla para continuar.");
                Console.ReadLine();
            }
            else
            {
                this.altura = altura;
            }
        }
        public void SetArea()
        {
            this.area = 2 * Convert.ToSingle((System.Math.PI)) * radio * (altura + radio);

        }
        public float GetArea()
        {
            return this.area;
        }
        public void SetVolumen()
        {
            this.volumen = Convert.ToSingle((System.Math.PI)) * radio * radio * altura;

        }
        public float Getvolumen()
        {
            return this.volumen;
        }
    }
}
