using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica4
{
    class Contactos
    {
        string nombre;
        string apellido;
        int telefono;
        string correo;
        string direccion;

        public Contactos(string inf1, string inf2, string inf3, string inf4, string inf5)
        {
            nombre = inf1;
            apellido = inf2;
            telefono = Convert.ToInt32(inf3);
            correo = inf4;
            direccion = inf5;
        }
        public Contactos()
        {
        }

        public string Getnombre()
        {
            return nombre;
        }
        public string Getapellido()
        {
            return apellido;
        }
        public int Gettelefono()
        {
            return telefono;
        }
        public string Getcorreo()
        {
            return correo;
        }
        public string Getdirecion()
        {
            return direccion;
        }
        public void Setnombre(string inf)
        {
            nombre = inf;
        }
        public void Setapellido(string inf)
        {
            apellido = inf;
        }
        public void Settelefono(int inf)
        {
            telefono = inf;
        }
        public void Setcorreo(string inf)
        {
            correo = inf;
        }
        public void Setdireccion(string inf)
        {
            direccion = inf;
        }
    }
}