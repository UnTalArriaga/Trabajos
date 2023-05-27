using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class Carrito
    {
        Producto producto1 = new Producto();
        Producto producto2 = new Producto();
        Producto producto3 = new Producto();
        Producto producto4 = new Producto();
        Producto producto5 = new Producto();
        Producto producto6 = new Producto();
        Producto producto7 = new Producto();
        Producto producto8 = new Producto();
        Producto producto9 = new Producto();
        Producto producto10 = new Producto();
        Producto producto11 = new Producto();
        Producto producto12 = new Producto();
        Producto producto13 = new Producto();
        Producto producto14 = new Producto();
        Producto producto15 = new Producto();
        Producto producto16 = new Producto();
        Producto producto17 = new Producto();
        Producto producto18 = new Producto();
        Producto producto19 = new Producto();
        Producto producto20 = new Producto();
        int contProductos = 0;

        public void AñadirProducto(int tienda)
        {
            Producto[] productos = { producto1, producto2, producto3,producto4,producto5,producto6,producto7,producto8,producto9,producto10,producto11,producto12,producto13,producto14,producto15,producto16,producto17,producto18,producto19,producto20};
            char opc;
            bool compra = true;
            string[] articulo;
            while (compra == true)
            {
                Console.WriteLine("¿Desea añadir alguno de los anteriores productos?\ns = Sí\tn = No");
                while (true)
                {
                    try
                    {
                        opc = Convert.ToChar(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Ingresa una opcion valida");
                    }
                }
                switch (opc)
                    {
                        case 's':
                            if (contProductos < 20 )
                            {
                                Busqueda bus = new Busqueda();
                                Console.WriteLine("Ingrese el nombre del articulo que desea comprar");
                                articulo = bus.BuscarProductoNombreCompra(tienda,Console.ReadLine());
                                if (articulo == null)
                                {
                                    Console.WriteLine("Por favor Ingrese el nombre del articulo como se muestra en pantalla");
                                }
                                else
                                {
                                    productos[contProductos].nombre = articulo[0];
                                    productos[contProductos].precio = Convert.ToDouble(articulo[2]);

                                    Console.WriteLine("Nombre: {0}\nPrecio: {1:c}\nCantidad Disponible: {2}\n",articulo[0],articulo[2],articulo[3]);
                                    
                                    int cantidad = 0;
                                    while (true)
                                    {
                                        Console.WriteLine("¿Cuantas unidades desea adquirir?");
                                        while (true)
                                        {
                                            try
                                            {
                                                cantidad = Convert.ToInt32(Console.ReadLine());
                                                break;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Ingresa un valor valido");
                                            }
                                        }
                                        if (cantidad > Convert.ToInt32(articulo[3]))
                                        {
                                            Console.WriteLine("Lo sentimos, no contamos con ese inventario");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    productos[contProductos].cantidad = cantidad;
                                    productos[contProductos].precioTotal = productos[contProductos].precio * productos[contProductos].cantidad;
                                    contProductos++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No puede agregar más de 20 articulos distintos");
                            }
                            break;
                        case 'n':
                            compra = false;
                            break;
                    default:
                        Console.WriteLine("Ingresa una opción valida");
                        break;
                }
            }
        }
        public void MostrarCarrito()
        {
            Producto[] productos = { producto1, producto2, producto3, producto4, producto5, producto6, producto7, producto8, producto9, producto10, producto11, producto12, producto13, producto14, producto15, producto16, producto17, producto18, producto19, producto20 };
            //int cont = 0;
            for (int i = 0; i < contProductos; i++)
            {
                Console.WriteLine("Nombre: {0}\nPrecio: {1:c}\nCantidad: {2}\n", productos[i].nombre, productos[i].precioTotal, productos[i].cantidad);
            }
        }
    }
}
