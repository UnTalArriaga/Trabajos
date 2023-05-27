using System;
using System.IO;


namespace Proyecto
{
    class InicioSesion
    {
        string[] lineasDelArchivo = new string[100];
        static private string[,] Usuario = new string[2, 9];
        int indice;
        public int Inicio()
        {
            int Band=0, contador=0;
            string linea;
            
            
            try
            {
                StreamReader sr = new StreamReader("Usuarios.txt");
                while ((linea = sr.ReadLine()) != null)
                {
                    lineasDelArchivo[contador] = linea;
                    contador++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Se generó una excepción: " + e.Message);
                Console.ReadLine();
            }
            do
            {
                Console.Clear();
                Console.Write("Nombre de Usuario: ");
                Usuario[0,1]=Console.ReadLine();
                Console.Write("Contraseña: ");
                Usuario[0, 2] = Console.ReadLine();
                for (int i = 0; i < contador; i++)
                {
                    string[] datos = lineasDelArchivo[i].Split('|');
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0)
                            Usuario[1, 0] = datos[j];                     
                        if (j == 1)
                            Usuario[1,1] = datos[j];
                        if (j == 2)
                            Usuario[1,2] = datos[j];
                        if (j == 3)
                            Usuario[1, 3] = datos[j];
                        if (j == 4)
                            Usuario[1, 4] = datos[j];
                        if (j == 5)
                            Usuario[1, 5] = datos[j];
                        if (j == 6)
                            Usuario[1, 6] = datos[j];
                        if (j == 7)
                            Usuario[1, 7] = datos[j];
                        if (j == 8)
                            Usuario[1, 8] = datos[j];

                    }
                    if (String.Compare(Usuario[0,1], Usuario[1,2]) == 0)
                    {
                        if (String.Compare(Usuario[0, 2], Usuario[1, 3]) == 0)
                        {
                            indice = i;
                            Band = 1;
                            break;
                        }
                    }
                }
                if (Band == 0)
                {
                    Console.WriteLine("Usuario o contraseña incorrecta.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Inicio de sesion exitoso.");
                    for (int i = 0; i < 9; i++)
                    {
                        Usuario[0, i] = Usuario[1, i];
                        if (Usuario[1, 0] == "2")
                        {
                            Usuario[0, 0] = "Cliente";
                        }
                        else
                        {
                            if(Usuario[1, 0] == "1")
                            {
                                Usuario[0, 0] = "Empleado";
                            }
                            else
                            {
                                Usuario[0, 0] = "Administrador";
                            }
                        }
                    }
                    Console.ReadLine();
                    
                }
            } while (Band == 0);
            return Convert.ToInt32(Usuario[1, 0]);
        }
        public int tienda()
        {
            return Convert.ToInt32(Usuario[0, 1]);
        }
        public void Registro(int x)
        {
            string nomb, aps, dir, cor, cel, usuario, contra;
            int ban = 1;
            FileStream CA = new FileStream("Usuarios.txt", FileMode.Append, FileAccess.Write);
            StreamWriter esc = new StreamWriter(CA);
            Console.Write("Ingrese su(s) nombre(s) [sin apellidos]:");
            nomb = Console.ReadLine();
            Console.Write("Ingrese sus apellidos: ");
            aps = Console.ReadLine();
            Console.Write("Ingrese su dirección:");
            dir = Console.ReadLine();
            Console.Write("Ingrese su correo: ");
            cor = Console.ReadLine();
            Console.Write("Ingrese su número de telefono: ");
            cel = Console.ReadLine();
            Console.Write("Ingrese su Nombre de usuario: ");
            usuario = Console.ReadLine();
            do
            {
                Console.Write("Ingrese su contraseña (Longuitud minima 10): ");
                contra = Console.ReadLine();
                if (contra.Length >= 10)
                {
                    ban = 0;
                }
                else
                {
                    Console.WriteLine("Ingrese una contraseña de 10 o más caracteres.");
                }
            } while (ban == 1);
            esc.WriteLine(x + "|0|" + usuario + "|" + contra + "|" + nomb + "|" + aps + "|" + dir + "|" + cor + "|" + cel);
            esc.Close();
            CA.Close();

        }
        public void Verperfil()
        {
            Console.WriteLine("Puesto: {6}\n" +
                "Nombre de Usuario: {0}\n" +
                "Nombre(s): {1}\n" +
                "apellidos: {2}\n" +
                "Direccion: {3}\n" +
                "Correo: {4}\n" +
                "Celular: {5}\n", Usuario[1, 2], Usuario[1, 4], Usuario[1, 5], Usuario[1, 6], Usuario[1, 7], Usuario[1, 8],Usuario[0,0]);
}
        public void EdPerfil()
        {
            int op;
            string contra;
            Console.Write("Que desea editar del perfil:\n" +
                "1)Nombre de Usuario\n" +
                "2)Contraseña\n" +
                "3)Nombre(s)\n" +
                "4)Apellidos \n" +
                "5)Direccion \n" +
                "6)Correo \n" +
                "7)Celular \n" +
                "Opcion: ");
            op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.Write("Ingrese su Nuevo Nombre de usuario: ");
                    Usuario[1, 2] = Console.ReadLine();
                    Reescribir();
                    break;
                case 2:
                    Console.Write("Ingrese su contraseña actual: ");
                    contra = Console.ReadLine();
                    if (contra == Usuario[1, 3])
                    {
                        Console.Write("Ingrese su Nueva contraseña: ");
                        Usuario[1, 3] = Console.ReadLine();
                        Reescribir();
                    }
                    else
                    {
                        Console.Write("Contraseña actual incorrecta.");
                    }
                    break;
                case 3:
                    Console.Write("Ingrese su Nombre: ");
                    Usuario[1, 4] = Console.ReadLine();
                    Reescribir();
                    break;
                case 4:
                    Console.Write("Ingrese sus Apellidos: ");
                    Usuario[1, 5] = Console.ReadLine();
                    Reescribir();
                    break;
                case 5:
                    Console.Write("Ingrese su nueva Direccion: ");
                    Usuario[1, 6] = Console.ReadLine();
                    Reescribir();
                    break;
                case 6:
                    Console.Write("Ingrese su Nuevo Correo: ");
                    Usuario[1, 7] = Console.ReadLine();
                    Reescribir();
                    break;
                case 7:
                    Console.Write("Ingrese su Nuevo Celular: ");
                    Usuario[1, 8] = Console.ReadLine();
                    Reescribir();
                    break;
                default:
                    Console.Write("Opcion Invalida.");
                    break;
            }
        }
        public void Reescribir()
        {
            string linea;
            int contador = 0;
            try
            {

                StreamReader sr = new StreamReader("Usuarios.txt");
                while ((linea = sr.ReadLine()) != null)
                {
                    contador++;
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Se generó una excepción: " + e.Message);
                Console.ReadLine();
            }
            FileStream CA = new FileStream("Usuarios.txt", FileMode.Create, FileAccess.Write);
            StreamWriter esc = new StreamWriter(CA);
            lineasDelArchivo[indice] = Usuario[1, 0] + "|" + Usuario[1, 1] + "|" + Usuario[1, 2] + "|" + Usuario[1, 3] + "|" + Usuario[1, 4] + "|"
                + Usuario[1, 5] + "|" + Usuario[1, 6] + "|" + Usuario[1, 7] + "|" + Usuario[1, 8];
            for (int i = 0; i < contador; i++)
            {
                esc.WriteLine(lineasDelArchivo[i]);
            }
            esc.Close();
            CA.Close();
            Console.WriteLine("Se actualizo el perfil.");
        }
    }
}
