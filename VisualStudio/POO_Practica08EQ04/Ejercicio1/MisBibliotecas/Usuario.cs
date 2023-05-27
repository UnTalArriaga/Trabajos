using System;

namespace MisBibliotecas
{
    public class Usuario
    {
        //atributos
        string name;
        string lastname;
        int id, numero;
        double comision=0;
        
        //constructor(es)
        public Usuario()
        {
            //constructor vacio
        }

        public Usuario(string nombre)
        {
            name = nombre;
        }

        //metodos Set

        public void setNombre(string nombre) { name = nombre; }
        public void setApellido(string apellido) { lastname = apellido; }
        public void setID(int matricula) { id = matricula; }
        public void SetNumero(int num) { numero = num; }
        public void setComision(double com) { comision=comision+com; }

        //metodos get
        public string GetNombre()
        {
            return name;
        }
        public string GetApellido()
        {
            return lastname;
        }
        public int GetMatricula()
        {
            return id;
        }
        public int GetNumero()
        {
            return numero;
        }
        public double GetComision()
        {
            return comision;
        }

        //metodo muestra info
        public void MuestraInfo()
        {
  
            Console.WriteLine("\nNombre: " + name +
                "\nApellido:  " + lastname +"\nMatrícula: "+id +"\ncomisiones totales: "+comision+
                "\nnumero de trabajador/o puesto: "+numero);
        }
    }

    public class Vehiculo
    {
        //atributos
        string marca, modelo;
        int llantas, pasajeros;

        //costructor

        public Vehiculo()
        {

        }

        //set

        public void SetMarca(string m) { marca = m; }
        public  void SetModelo(string m) { modelo = m; }
        public void SetLLantas(int ll) { llantas = ll; }
        public void SetPasajeros(int p) { pasajeros = p; }

        //get
        public string GetMarca()
        {
            return marca;
        }
        public string GetModelo()
        {
            return modelo;
        }
        public int GetLLantas()
        {
            return llantas;
        }
        public int GetPasajeros()
        {
            return pasajeros;
        }

        //Metodos
        public virtual string Encender()
        {
            return "Vehiculo encendido";
        }
        public virtual string Apagar()
        {
            return "Vehiculo apagado";
        }
        public virtual string SubirPasajeros()
        {
            return "Subiendo pasajeros al vehiculo";
        }
    }


}
