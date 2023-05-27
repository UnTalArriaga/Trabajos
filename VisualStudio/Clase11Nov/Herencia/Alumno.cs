using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Herencia
{
    class Alumno : Persona
    {
        int calificacion;

        public Alumno()
        {

        }

        public void SetCalificacion(int calif)
        {
            calificacion = calif;
        }

        public int GetCalificacion()
        {
            return calificacion;
        }

        public string Estudiar()
        {
            //string variable;
            //String objeto = new String();
            return "\n"+nombre+" se encuentra concentrado en sus"+
                " estudios de POO para el examen :O";
        }

    }
}
