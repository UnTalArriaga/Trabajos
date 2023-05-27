using System;

namespace Proyecto
{
    class MenuEmpresa
    {
        static void Main(string[] args)
        {
            int tipo=3,op=0,opin, opi=0,ban=0;
            string nombre;
            Busqueda bus = new Busqueda();
            InicioSesion iniciar = new InicioSesion();
            do
            {
                do
                {
                    Console.Clear();
                    Console.Write("Menu de Inicio de Sesion.\n" +
                        "1)Iniciar Sesion\n" +
                        "2)Registrar Cuenta Nueva\n" +
                        "Opcion: ");
                    opin=Convert.ToInt32( Console.ReadLine() );
                    switch (opin)
                    {
                        case 1:
                            tipo = iniciar.Inicio();
                            break;
                        case 2:
                            iniciar.Registro(2);//se envia un dos ya que en este registro solo se pueden registrar clientes
                            break;
                    }
                } while (opin!=1);
                opin= iniciar.tienda();//Para saber que tienda atiende el empleado si es que es empleado
                switch (opin)
                {
                    case 0://sin tienda(cliente elije tienda)
                        ban = 0;
                        do
                        {
                            Console.Clear();
                            Console.Write("Elija la sucursal de su preferencia:\n" +
                                "1)Tlalpan\n" +
                                "2)Coyoaca\n" +
                                "3)Insurgentes\n" +
                                "Opcion: ");
                            opin = Convert.ToInt32(Console.ReadLine());
                            if (opin == 1)
                            {
                                bus.tienda(1);
                                ban = 1;
                            }
                            if (opin == 2)
                            {
                                bus.tienda(2);
                                ban = 1;
                            }
                            if (opin == 3)
                            {
                                bus.tienda(3);
                                ban = 1;
                            }
                            if (opin < 1 && opin > 3)
                            {
                                Console.WriteLine("Opcion invalida.");
                            }
                        } while (ban==0);
                        break;
                    case 1://tlalpan
                        bus.tienda(1);
                        break;
                    case 2://coyoacan
                        bus.tienda(2);
                        break;
                    case 3://insurgentes
                        bus.tienda(3);
                        break;
                    case 4://sin tienda(admin)
                        bus.tienda(4);
                        break;

                }
                switch (tipo)
                {
                    case 0://admin
                        do
                        {
                            Console.Write("Menu Administrador\n" +
                                "*Ver Tiendas\n" +
                                "\t11)Ver inventario (todos los productos)\n" +
                                "\t12)Buscar en inventario\n" +
                                "\t13)Dar alta de producto (agregar)\n" +
                                "*Empleados\n" +
                                "\t21)Ver empleados\n" +
                                "\t22)Nuevo registro\n" +
                                "\t23)Actualizar Registro\n" +
                                "\t24)Eliminar registro\n" +
                                "*Inventario(Por Tienda)\n" +
                                "\t31)Ver Inventario de productos\n" +
                                "\t32)Ver Solicitudes de Nuevo material\n" +
                                "\t33)Crear Solicitud de nuevo Material\n" +
                                "\t34)Añadir stock(Aceptar Solicitudes)\n" +
                                "*Reportes\n" +
                                "\t41)Ver total de ventas por Productos\n" +
                                "\t42)Ver total de ventas por departamento\n" +
                                "\tVer Compras\n" +
                                "\t\t431)Ver todas las compras\n" +
                                "\t\t432)Buscar por producto\n" +
                                "5)Salir\n" +
                                "Opcion: ");
                            opin = Convert.ToInt32(Console.ReadLine());
                            switch (opin)
                            {
                                case 11:
                                    bus.tienda(0);
                                    bus.MostrarCatalogo();
                                    Console.ReadLine();
                                    break;
                                case 12:
                                    
                                    bus.tienda(0);
                                    Console.WriteLine("Ingrese el departamento del producto: ");
                                    bus.BuscarProductoDepartamento(Console.ReadLine());
                                    Console.ReadLine();
                                    break;
                                case 13:
                                    break;
                                case 21:
                                    bus.BuscarUsuarioEmp();
                                    Console.ReadLine();
                                    break;
                                case 22:
                                    break;
                                case 23:
                                    break;
                                case 24:
                                    break;
                                case 31:
                                    break;
                                case 32:
                                    break;
                                case 33:
                                    break;
                                case 34:
                                    break;
                                case 41:
                                    break;
                                case 42:
                                    break;
                                case 431:
                                    break;
                                case 432:
                                    break;
                                case 5:
                                    Console.WriteLine("Se cerro la sesion.\n" +
                                        "Presione Cualquier tecla para continuar.");
                                    Console.ReadLine();
                                    break;
                                default:
                                    Console.WriteLine("Opcion Invalida.\n" +
                                        "Presione Cualquier tecla para continuar.");
                                    Console.ReadLine();
                                    break;
                            }
                        } while (opi != 5);
                        break;
                    case 1://asesor
                        do
                        {
                            Console.Clear();
                            Console.Write("Menu Asesor\n" +
                                "*Ver Catalogo\n" +
                                "\t11)A-Z\n" +
                                "\t12)Por Departamento\n" +
                                "*Buscar Producto\n" +
                                "\t21)Nombre\n" +
                                "\t22)Departamento\n" +
                                "3)Solicitud de Material\n" +
                                "*Buscar usuario\n" +
                                "\t41)Por apellidos\n" +
                                "\t42)Por nombre de usuario\n" +
                                "\t43)Mostar todos\n" +
                                "*Mi Perfil\n" +
                                "\t51)Ver Perfil\n" +
                                "\t52)Editar\n" +
                                "6)Cerrar Sesion\n" +
                                "Opcion:");
                            opi = Convert.ToInt32(Console.ReadLine());
                            switch (opi)
                            {
                                case 11:
                                    bus.MostrarCatalogo();
                                    Console.ReadLine();
                                    break;
                                case 12:
                                    bus.MostrarCatalogoDep();
                                    Console.ReadLine();
                                    break;
                                case 21:
                                    Console.WriteLine("Ingrese el Nombre del producto que busca: ");
                                    nombre = Console.ReadLine();
                                    bus.BuscarProductoNombre(nombre);
                                    Console.ReadLine();
                                    break;
                                case 22:
                                    Console.WriteLine("Ingrese el departamento que busca: ");
                                    nombre = Console.ReadLine();
                                    bus.BuscarProductoDepartamento(nombre);
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    break;
                                case 41:
                                    Console.WriteLine("Ingrese los apellidos del usuario: ");
                                    nombre = Console.ReadLine();
                                    bus.BuscarUsuarioAp(nombre);
                                    Console.ReadLine();
                                    break;
                                case 42:
                                    Console.WriteLine("Ingrese el nombre de usuario: ");
                                    nombre = Console.ReadLine();
                                    bus.BuscarUsuarioNU(nombre);
                                    Console.ReadLine();
                                    break;
                                case 43:
                                    bus.BuscarUsuario();
                                    Console.ReadLine();
                                    break;
                                case 51:
                                    iniciar.Verperfil();
                                    Console.ReadLine();
                                    break;
                                case 52:
                                    iniciar.EdPerfil();
                                    Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("Se cerro la sesion.\n" +
                                        "Presione Cualquier tecla para continuar.");
                                    Console.ReadLine();
                                    break;
                                default:
                                    Console.WriteLine("Opcion Invalida.\n" +
                                        "Presione Cualquier tecla para continuar.");
                                    Console.ReadLine();
                                    break;
                            }
                                
                        } while (opi != 6);
                        break;
                    case 2://cliente
                        Carrito nuevoCarrito = new Carrito();
                        do
                        {
                            Console.Write("Menu Cliente\n" +
                                "*Ver Catalogo\n" +
                                "\t11)A-Z\n" +
                                "\t12)Por Departamento\n" +
                                "\t*Buscar Producto\n" +
                                "\t\t131)Nombre\n" +
                                "\t\t132)Departamento\n" +
                                "*Mi carrito\n" +
                                "\t21)VerCarrito\n" +
                                "\t22)Pagar\n" +
                                "*Mis compras\n" +
                                "\t31)Ver todas mis compras\n" +
                                "\t32)Buscar compra\n" + 
                                "4)Ver Mis Puntos\n" +
                                "*Mi Perfil\n" +
                                "\t51)Ver Perfil\n" +
                                "\t52)Editar\n" +
                                "6)Cerrar Sesion\n" +
                                "Opcion:");
                            opi=Convert.ToInt32( Console.ReadLine() );
                            switch (opi)
                            {
                                case 11:
                                    bus.MostrarCatalogo();
                                    nuevoCarrito.AñadirProducto(opin);
                                    break;
                                case 12:
                                    bus.MostrarCatalogoDep();
                                    nuevoCarrito.AñadirProducto(opin);
                                    break;
                                case 131:
                                    Console.WriteLine("Ingrese el Nombre del producto que busca: ");
                                    nombre = Console.ReadLine();
                                    bus.BuscarProductoNombre(nombre);
                                    nuevoCarrito.AñadirProducto(opin);
                                    Console.ReadLine();
                                    break;
                                case 132:
                                    Console.WriteLine("Ingrese el departamento que busca: ");
                                    nombre = Console.ReadLine();
                                    bus.BuscarProductoDepartamento(nombre);
                                    nuevoCarrito.AñadirProducto(opin);
                                    Console.ReadLine();
                                    break;
                                case 21:
                                    nuevoCarrito.MostrarCarrito();
                                    Console.WriteLine("Presiona Enter para continuar");
                                    Console.ReadLine();
                                    break;
                                case 22:
                                    break;
                                case 31:
                                    break;
                                case 32:
                                    break;
                                case 4:
                                    break;
                                case 51:
                                    iniciar.Verperfil();
                                    Console.ReadLine();
                                    break;
                                case 52:
                                    break;
                                case 6:
                                    Console.WriteLine("Se cerro la sesion.\n" +
                                        "Presione Cualquier tecla para continuar.");
                                    Console.ReadLine();
                                    break;
                                default:
                                    Console.WriteLine("Opcion Invalida.\n" +
                                        "Presione Cualquier tecla para continuar.");
                                    Console.ReadLine();
                                    break;
                            }
                        } while (opi != 6);
                        break;
                }


            } while (op==0);


        }
    }
}
