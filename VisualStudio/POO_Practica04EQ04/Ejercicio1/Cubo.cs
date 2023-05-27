using System;

namespace Ejercicio1
{
    class Cubo
    {
        private float perimetro, area, volumen, lado;
        public Cubo()
        {
        }
        public void SetLado(float lado)
        {
            if (lado < 0)
            {
                lado = -1 * lado;
                this.lado = lado;
                Console.WriteLine("No puede haber lados negativas, por lo tanto la convertimos en positivo.");
                Console.Write("Presione cualquier tecla para continuar.");
                Console.ReadLine();
            }
            else
            {
                this.lado = lado;
            }
        }
        public void SetPerimetro()
        {
            this.perimetro = this.lado * 12;
        }
        public float GetPerimetro()
        {
            return this.perimetro;
        }
        public void SetArea()
        {
            this.area = this.lado * this.lado * 6;
        }
        public float GetArea()
        {
            return this.area;
        }
        public void SetVolumen()
        {
            this.volumen = this.lado * this.lado * this.lado;
        }
        public float Getvolumen()
        {
            return this.volumen;
        }

    }
    
}
