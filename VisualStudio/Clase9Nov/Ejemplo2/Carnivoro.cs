using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplo2
{
    class Carnivoro : Animal
    {
        string tipoDientes = "afilados";
        public Carnivoro()
        {

        }


        override public void Dormir()
        {
            Console.WriteLine(nombre+" está devorando un antílope :O");
        }

        
    }
}
