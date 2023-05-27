using System;
using System.IO;

namespace Proyecto
{
    class Busqueda
    {

        string InvTienda = "";
        string Reportes = "";
        public void BuscarProductoDepartamento(string nombre)
        {
            StreamReader busqueda = new StreamReader(InvTienda);
            int cont = 0, ban=1;
            //int noProducto = 500;
            string linea;
            string[] lineas = new string[100];
            string[,] producto = new string[100, 8];
            while ((linea = busqueda.ReadLine()) != null)
            {
                lineas[cont] = linea;
                cont++;
            }
            busqueda.Close();

            for (int i = 0; i < cont; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 8; j++)
                {
                    producto[i, j] = datos[j];
                }
            }

            for (int i = 0; i < cont; i++)
            {
                if (nombre == producto[i, 7])
                {
                    Console.WriteLine("Nombre: {0}\nPrecio: {1:c}\nDisponibles: {2}\n", producto[i, 0], producto[i, 2], producto[i, 3]);
                    ban = 0;
                }
                if (ban != 0)
                {
                    Console.WriteLine("Ese departamento no existe.");
                }
            }
        }
        public void BuscarProductoNombre(string nombre)
        {
            StreamReader busqueda = new StreamReader(InvTienda);
            int cont = 0;
            int noProducto = 500;
            string linea;
            string[] lineas = new string[100];
            string[,] producto = new string[100, 8];
            while ((linea = busqueda.ReadLine()) != null)
            {
                lineas[cont] = linea;
                cont++;
            }
            busqueda.Close();

            for (int i = 0; i < cont; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 8; j++)
                {
                    producto[i, j] = datos[j];
                }
            }

            for (int i = 0; i < cont; i++)
            {
                if (nombre == producto[i, 0])
                {
                    noProducto = i;
                }
            }

            if (noProducto == 500)
            {
                Console.WriteLine("No se ha encontrado el producto");
            }
            else
            {
                Console.WriteLine("Nombre: {0}\nPrecio: {1:c}\nDisponibles: {2}", producto[noProducto, 0], producto[noProducto, 2], producto[noProducto, 3]);
            }
        }
        public void tienda(int x)
        {
            switch (x)
            {
                case 1:
                    InvTienda = "InventarioTla.txt";
                    Reportes = "RepTla.txt";
                    break;
                case 2:
                    InvTienda = "InventarioCoy.txt";
                    Reportes = "RepCoy.txt";
                    break;
                case 3:
                    InvTienda = "InventarioIns.txt";
                    Reportes = "RepIns.txt";
                    break;
                case 4:
                    InvTienda = "InventarioTotal.txt";
                    break;
            }
        }
        public void BuscarUsuarioAp(string nombre)
        {
            string linea;
            int cont = 0, noUsuario=500;
            string[] lineas = new string[100];
            string[,] Usuarios = new string[100,9];
            try
            {
                StreamReader sr = new StreamReader("Usuarios.txt");
                while ((linea = sr.ReadLine()) != null)
                {
                    lineas[cont] = linea;
                    cont++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Se generó una excepción: " + e.Message);
                Console.ReadLine();
            }

            for (int i = 0; i < cont; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0 && datos[j] != "2")
                    {//Condicion para que solo pueda buscar clientes, ya que su permiso es buscar el usuario del cliente
                        break; ;
                    }
                    else 
                    {
                        Usuarios[i, j] = datos[j];
                    }

                }
            }

            for (int i = 0; i < cont; i++)
            {
                if (nombre == Usuarios[i, 5])
                {
                    noUsuario = i;
                }
            }

            if (noUsuario == 500)
            {
                Console.WriteLine("No se ha encontrado el usuario");
            }
            else
            {
                Console.WriteLine("Nombre de Usuario: {0}\n" +
                    "Nombre(s): {1}\n" +
                    "apellidos: {2}\n" +
                    "Direccion: {3}\n" +
                    "Correo: {4}\n" +
                    "Celular: {5}", Usuarios[noUsuario,2], Usuarios[noUsuario, 4], Usuarios[noUsuario, 5], Usuarios[noUsuario, 6], Usuarios[noUsuario, 7], Usuarios[noUsuario, 8]);
            }
        }
        public void BuscarUsuarioNU(string nombre)
        {
            string linea;
            int cont = 0, noUsuario = 500;
            string[] lineas = new string[100];
            string[,] Usuarios = new string[100, 9];
            try
            {
                StreamReader sr = new StreamReader("Usuarios.txt");
                while ((linea = sr.ReadLine()) != null)
                {
                    lineas[cont] = linea;
                    cont++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Se generó una excepción: " + e.Message);
                Console.ReadLine();
            }

            for (int i = 0; i < cont; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0 && datos[j] != "2")
                    {//Condicion para que solo pueda buscar clientes, ya que su permiso es buscar el usuario del cliente
                        break; ;
                    }
                    else
                    {
                        Usuarios[i, j] = datos[j];
                    }
                }
            }

            for (int i = 0; i < cont; i++)
            {
                if (nombre == Usuarios[i, 2])
                {
                    noUsuario = i;
                }
            }

            if (noUsuario == 500)
            {
                Console.WriteLine("No se ha encontrado el usuario");
            }
            else
            {
                Console.WriteLine("Nombre de Usuario: {0}\n" +
                    "Nombre(s): {1}\n" +
                    "apellidos: {2}\n" +
                    "Direccion: {3}\n" +
                    "Correo: {4}\n" +
                    "Celular: {5}", Usuarios[noUsuario, 2], Usuarios[noUsuario, 4], Usuarios[noUsuario, 5], Usuarios[noUsuario, 6], Usuarios[noUsuario, 7], Usuarios[noUsuario, 8]);
            }
        }
        public void BuscarUsuario()
        {
            string linea;
            int cont = 0, noUsuario = 0;
            string[] lineas = new string[100];
            string[,] Usuarios = new string[100, 9];
            try
            {
                StreamReader sr = new StreamReader("Usuarios.txt");
                while ((linea = sr.ReadLine()) != null)
                {
                    lineas[cont] = linea;
                    cont++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Se generó una excepción: " + e.Message);
                Console.ReadLine();
            }

            for (int i = 0; i < cont; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0 && datos[j] != "2")
                    {//Condicion para que solo pueda buscar clientes, ya que su permiso es buscar el usuario del cliente
                        j = 8;
                    }
                    else
                    {
                        Usuarios[noUsuario, j] = datos[j];
                        if (j == 7)
                        {
                            noUsuario++;
                        }
                    }
                }
            }
            if (noUsuario == 0)
            {
                Console.WriteLine("No se ha encontrado el usuario");
            }
            else
            {
                for (int i=0; i < noUsuario; i++)
                {
                    Console.WriteLine("Nombre de Usuario: {0}\n" +
                        "Nombre(s): {1}\n" +
                        "apellidos: {2}\n" +
                        "Direccion: {3}\n" +
                        "Correo: {4}\n" +
                        "Celular: {5}\n", Usuarios[i, 2], Usuarios[i, 4], Usuarios[i, 5], Usuarios[i, 6], Usuarios[i, 7], Usuarios[i, 8]);
                }
            }
        }
        public void MostrarCatalogo()
        {
            StreamReader busqueda = new StreamReader(InvTienda);
            int cont = 0;
            string linea;
            string[] lineas = new string[100];
            string[,] producto = new string[100, 8];
            while ((linea = busqueda.ReadLine()) != null)
            {
                lineas[cont] = linea;
                cont++;
            }
            busqueda.Close();

            for (int i = 0; i < cont; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 8; j++)
                {
                    producto[i, j] = datos[j];
                }
            }

            for (int i = 65; i <= 90; i++)
            {
                for (int j = 0; j < cont; j++)
                {
                    char letras = Convert.ToChar(producto[j, 0][0]);
                    if (Convert.ToChar(i) == letras)
                    {
                        Console.WriteLine("Nombre: {0}\nPrecio: {1:c}\nDisponibles: {2}\n", producto[j, 0], producto[j, 2], producto[j, 3]);
                    }
                }
            }
        }
        public void MostrarCatalogoDep()
        {
            StreamReader busqueda = new StreamReader(InvTienda);
            int cont = 0;
            string linea;
            string[] lineas = new string[100];
            string[,] producto = new string[100, 8];
            while ((linea = busqueda.ReadLine()) != null)
            {
                lineas[cont] = linea;
                cont++;
            }
            busqueda.Close();

            for (int i = 0; i < cont; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 8; j++)
                {
                    producto[i, j] = datos[j];
                }
            }

            for (int i = 65; i <= 90; i++)
            {
                for (int j = 0; j < cont; j++)
                {
                    char letras = Convert.ToChar(producto[j, 7][0]);
                    if (Convert.ToChar(i) == letras)
                    {
                        Console.WriteLine("Departamento: {0}\n" +
                            "Nombre: {1}\n" +
                            "Precio: {2:c}\n" +
                            "Disponibles: {3}\n",producto[j,7], producto[j, 0], producto[j, 2], producto[j, 3]);
                    }
                }
            }
        }
        public void BuscarUsuarioEmp()
        {
            string linea;
            int cont = 0, noUsuario = 0;
            string[] lineas = new string[100];
            string[,] Usuarios = new string[100, 9];
            try
            {
                StreamReader sr = new StreamReader("Usuarios.txt");
                while ((linea = sr.ReadLine()) != null)
                {
                    lineas[cont] = linea;
                    cont++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Se generó una excepción: " + e.Message);
                Console.ReadLine();
            }

            for (int i = 0; i < cont; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 8; j++)
                {
                    
                        Usuarios[noUsuario, j] = datos[j];
                        if (j == 7)
                        {
                            noUsuario++;
                        }
                    
                }
            }
            if (noUsuario == 0)
            {
                Console.WriteLine("No se ha encontrado el usuario");
            }
            else
            {
                for (int i = 0; i < noUsuario; i++)
                {
                    Console.WriteLine("Nombre de Usuario: {0}\n" +
                        "Nombre(s): {1}\n" +
                        "apellidos: {2}\n" +
                        "Direccion: {3}\n" +
                        "Correo: {4}\n" +
                        "Celular: {5}\n", Usuarios[i, 2], Usuarios[i, 4], Usuarios[i, 5], Usuarios[i, 6], Usuarios[i, 7], Usuarios[i, 8]);
                }
            }
        }
        public string[] BuscarProductoNombreCompra(int x,string nombre)
        {
            switch (x)
            {
                case 1:
                    InvTienda = "InventarioTla.txt";
                    break;
                case 2:
                    InvTienda = "InventarioCoy.txt";
                    break;
                case 3:
                    InvTienda = "InventarioIns.txt";
                    break;
            }
            StreamReader busqueda = new StreamReader(InvTienda);
            int cont = 0;
            int noProducto = 500;
            string linea;
            string[] articulo = new string[8];
            string[] lineas = new string[100];
            string[,] producto = new string[100, 8];
            while ((linea = busqueda.ReadLine()) != null)
            {
                lineas[cont] = linea;
                cont++;
            }
            busqueda.Close();

            for (int i = 0; i < cont; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 8; j++)
                {
                    producto[i, j] = datos[j];
                }
            }

            for (int i = 0; i < cont; i++)
            {
                if (nombre == producto[i, 0])
                {
                    noProducto = i;
                }
            }

            if (noProducto == 500)
            {
                Console.WriteLine("No se ha encontrado el producto");
                return null;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    articulo[i] = producto[noProducto, i];
                }
            }
            /*
            else
            {
                Console.WriteLine("Nombre: {0}\nPrecio: {1:c}\nDisponibles: {2}", producto[noProducto, 0], producto[noProducto, 2], producto[noProducto, 3]);
            }*/

            
            return articulo;
        }
    }
}

