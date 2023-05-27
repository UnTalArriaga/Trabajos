using System;


namespace Ejercicio1
{
    class Piramide
    {
        private float altura, area, volumen, lado, lado2, ATP, ATC, perimetro;
        private int nl;
        public Piramide()
        {
            //constructor por defecto
        }
        public void SetAltura(float altura)
        {
            
            if (altura< 0)
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
        public void SetLado2(float lado2)
        {
            if (lado2 < 0)
            {
                lado2 = -1 * lado2;
                this.lado2 = lado2;
                Console.WriteLine("No puede haber lados negativas, por lo tanto la convertimos en positivo.");
                Console.Write("Presione cualquier tecla para continuar.");
                Console.ReadLine();
            }
            else
            {
                this.lado2 = lado2;
            }
        }
        public void SetNumLados(int nl)
        {
            if ( nl < 5)
            {
                this.nl = 5;
                Console.WriteLine("El numero minimo de lados es 5, asi que pusimos como el numero de lados.");
                Console.Write("Presione cualquier tecla para continuar.");
                Console.ReadLine();
            }
            else
            {
                this.nl = nl;
            }
        }
        public void SetAT()
        {
            this.area = lado * lado * Convert.ToSingle((System.Math.Sqrt(3)));
            //area=lado^2*raiz(3)
        }
        public void SetAC()
        {
            this.area = (((2 * lado + 2 * lado2) * Convert.ToSingle(System.Math.Sqrt(altura*altura+(lado*lado)/4)) ) / 2)+(lado * lado2);
            //area=(perimetrro de la base)(altura del triangulo, no de la piramide)/2+(area de la base)
        }
        public void SetAP()
        {
            this.area = ((nl * lado * Convert.ToSingle(System.Math.Sqrt(altura * altura + System.Math.Sqrt(lado * lado - (lado * lado) / 2)))) / 2) + ((lado * nl * Convert.ToSingle(System.Math.Sqrt(lado * lado - (lado * lado) / 2))) / 2);
            //area=(perimetrro de la base)(altura del triangulo, no de la piramide)/2+(area de la base)
        }
        public void SetVT()
        {
            this.volumen = (lado * lado * lado * Convert.ToSingle(System.Math.Sqrt(2))) / 12;
            //volumen=(lado^3*raiz(3))/12
        }
        public void SetVC()
        {
            this.volumen = (lado * lado2 * altura) / 3;
            //volumen=(base*altura)/3
        }
        public void SetVP()
        {
            this.volumen = (((lado * nl * Convert.ToSingle(System.Math.Sqrt(lado * lado - (lado * lado)/2))) / 2) * altura) / 3;
            //volumen=(base*altura)/3
        }
        public float GetArea()
        {
            return area;
        }
        public float GetVolumen()
        {
            return volumen;
        }
        public int GetNumLados()
        {
            return nl;
        }
        public void SetPT()
        {
            this.perimetro = 6 * lado;
        }
        public void SetPC()
        {
            atc();
            this.perimetro = 4 * (Convert.ToSingle(System.Math.Sqrt(ATC * ATC + (lado * lado) / 4))) + (4 * lado);
        }
        public void atc()
        {
            this.ATC = Convert.ToSingle(System.Math.Sqrt(altura * altura + (lado * lado) / 4));
        }
        public void SetPP()
        {
            atp();
            this.perimetro = nl * (Convert.ToSingle(System.Math.Sqrt(ATP*ATP+(lado*lado)/4))) + (nl * lado);
        }
        public void atp()
        {
            this.ATP = Convert.ToSingle(System.Math.Sqrt(altura * altura + System.Math.Sqrt(lado * lado - (lado * lado) / 2)));
        }
        public float GetP()
        {
            return perimetro;
        }
    }
}

