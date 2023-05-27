using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ejemplo1
{
    public partial class Form1 : Form
    {
        public int seleccionLabel; //0-> lblCodigo, 1->lblEfectivo, 2-> Ya noe scribo en los label´s y hasta que presione ok reinicia la máquina a su estado original
        public double aPagar = 0;
        public double precio = 10;
        public string[,] prod;
        public string prodCodigo, prodNombre, prodPrecio, prodCantidad; //clase Producto 
        public Form1()
        {            
            InitializeComponent();
            //cargo configuración de inicio
            lblCodigo.Text = "";
            lblCambio.Text = "";
            lblPagar.Text = "";
            lblEfectivo.Text = "";
            seleccionLabel = 0;
            btnCinco.Enabled = false; //deshabilito el botón
            btnSeis.Enabled = false;
            btnSiete.Enabled = false;
            btnOcho.Enabled = false;
            btnNueve.Enabled = false;
            btnPunto.Enabled = false;
            btnCero.Enabled = false;
            prod = leeArchivoV1();
            pbPrincipal.Image = Image.FromFile("imgMaq.jpg");
            pbEntrega.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEntrega.Image = Image.FromFile("imgFondo.jpg");
            MessageBox.Show("Bienvenido!!!, ingresa el código de producto y la cantidad!!!");
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            DeshabilitaLetras();            
            if(seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "A";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "A";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                //validar código
                string cod = lblCodigo.Text;
                if (validaCodigo(cod)) //If (true) if(false) =>if (!validaCodigo(cod))
                {
                    aPagar = Convert.ToInt32(prodPrecio) * Convert.ToInt32(txbCantidad.Text);
                    lblPagar.Text = Convert.ToString(Convert.ToInt32(prodPrecio)*Convert.ToInt32(txbCantidad.Text));
                }
                if (txbCantidad.Text == "")
                {
                    MessageBox.Show("Ingresa un valor en cantidad!!! -.-");
                }
                else
                {
                    //validar que el código sea correcto
                    //tener arreglo (leer archivo/base de datos) con los códigos válidos
                    //Limitar al número de caracteres del código (cadena.lenght<=2)
                    seleccionLabel = 1;
                    MessageBox.Show("Ingresa el dinero para pagar y presona OK");
                    btnUno.Enabled = true;
                    btnDos.Enabled = true;
                    btnTres.Enabled = true;
                    btnCuatro.Enabled = true;
                    btnCinco.Enabled = true;    //habilito el botón
                    btnSeis.Enabled = true;
                    btnSiete.Enabled = true;
                    btnOcho.Enabled = true;
                    btnNueve.Enabled = true;
                    btnCero.Enabled = true;
                    btnPunto.Enabled = true;
                    //aPagar = precio * Convert.ToDouble(txbCantidad.Text);
                    //lblPagar.Text = Convert.ToString(aPagar);
                }
            }
            else if (seleccionLabel == 1)
            {
                if (lblEfectivo.Text == "")
                {
                    MessageBox.Show("Ingresa el dinero para pagar ");
                }
                else
                {
                    if (aPagar > Convert.ToInt32(lblEfectivo.Text))
                    {
                        MessageBox.Show("Fondos insuficientes :(");
                    }
                    else
                    {
                        seleccionLabel = 2;
                        MessageBox.Show("Recoje tus productos, Presiona OK");
                        pbEntrega.Image = Image.FromFile("sabritas.jpg");
                    }
                }
                
            }
            else if (seleccionLabel == 2)
            {
                seleccionLabel = 0;
                lblCambio.Text = Convert.ToString(Convert.ToInt32(lblEfectivo.Text)-aPagar);
                pbEntrega.Image = Image.FromFile("cambio.jpeg");
                MessageBox.Show("Recoge tu cambio, Gracias por tu compra");
                
                //Limpiar Interfaz
                LimpiarInterfaz();
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            seleccionLabel = 0;
            lblCodigo.Text = "";
            lblEfectivo.Text = "";
            lblPagar.Text = "";
            lblCambio.Text = "";
            txbCantidad.Text = "";

        }

        private void btnB_Click(object sender, EventArgs e)
        {
            DeshabilitaLetras();
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "B";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "B";
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            DeshabilitaLetras();
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "C";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "C";
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            DeshabilitaLetras();
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "D";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "D";
            }
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            
            if (seleccionLabel == 0)
            {
                DeshabilitarDigitos();
                lblCodigo.Text = lblCodigo.Text + "1";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "1";
            }
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "2";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "2";
            }
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "3";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "3";
            }
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "4";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "4";
            }
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "5";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "5";
            }
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "6";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "6";
            }
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "7";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "7";
            }
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "8";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "8";
            }
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "9";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "9";
            }
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + "0";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += "0";
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            btnPunto.Enabled = false;
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = lblCodigo.Text + ".";
            }
            else if (seleccionLabel == 1)
            {
                lblEfectivo.Text += ".";
            }
        }

        private void brnLimpiar_Click(object sender, EventArgs e)
        {
            if (seleccionLabel == 0)
            {
                lblCodigo.Text = "";
                btnA.Enabled = true;
                btnB.Enabled = true;
                btnC.Enabled = true;
                btnD.Enabled = true;
            }
            else if (seleccionLabel == 1)
            {
                btnPunto.Enabled = true;
                lblEfectivo.Text = "";
            }
        }

        public void DeshabilitaLetras()
        {
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
        }

        public void LimpiarInterfaz()
        {
            //rev del hilo con el cambio
            System.Threading.Thread.Sleep(5000);//milisegundos
            lblCodigo.Text = "";
            lblPagar.Text = "";
            lblCambio.Text = "";
            lblEfectivo.Text = "";
            txbCantidad.Text = "";
            //habilitar boton ABCD
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            //deshabilitar de 5 al punto
            btnCinco.Enabled = false;
            btnSeis.Enabled = false;
            btnSiete.Enabled = false;
            btnOcho.Enabled = false;
            btnNueve.Enabled = false;
            btnCero.Enabled = false;
            btnPunto.Enabled = false;

            pbEntrega.Image = Image.FromFile("imgFondo.jpg");
            MessageBox.Show("Bienvenido!!!, ingresa el código de producto y la cantidad!!!");
        }

        public void DeshabilitarDigitos()
        {
            btnUno.Enabled = false;
            btnDos.Enabled = false;
            btnTres.Enabled = false;
            btnCuatro.Enabled = false;
        }

        public string [,] leeArchivoV1()
        {
            //Código-Nombre_Producto-Precio
            string[] lineas = new string[20];
            string linea;
            int contador = 0;
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("productos.txt");
                while((linea = sr.ReadLine()) != null)
                {
                    lineas[contador] = linea;
                    contador++;
                }
                sr.Close();
            }
            catch
            {
                MessageBox.Show("Error al leer el archivo");
            }
            //como la clase anteapasada
            string[] codigo = new string[contador];
            string[] nombreProducto = new string[contador];
            string[] precio = new string[contador];
            /*
            //Para el archivo con 3 columnas
            string[,] producto = new string[contador,3];
            /*  codigo(0)      nombre(1)     precio(2)
             * |        |           |           |0
             * |        |           |           |1
             * |        |           |           |2    
             * |        |           |           |3
             * 
            for(int i=0; i< contador; i++)
            {
                string[] datos = lineas[i].Split('|');
                for(int j=0; j<3; j++)
                {
                    if (j == 0)
                        producto[i, j] = datos[j];
                    if(j == 1)
                        producto[i, j] = datos[j];
                    if (j == 2)
                        producto[i, j] = datos[j];
                }
            }
            //prod = producto; sin return
            return producto;
            */
            //Para el archivo con 4 columnas (stock añadido)
            string[,] producto = new string[contador, 4];
            /*  codigo(0)  nombre(1)   precio(2)  cantidad(3)
             * |    A1    |     Sabritas      |      10     |       5    |0
             * |        |           |           |           |1
             * |        |           |           |           |2    
             * |        |           |           |           |3
             */
            for (int i = 0; i < contador; i++)
            {
                string[] datos = lineas[i].Split('|');
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                        producto[i, j] = datos[j];
                    if (j == 1)
                        producto[i, j] = datos[j];
                    if (j == 2)
                        producto[i, j] = datos[j];
                    if (j == 3)
                        producto[i, j] = datos[j];
                }
            }
            //prod = producto; sin return
            return producto;
        }
        //Validaciones de código (método)
        public bool validaCodigo(string cod)
        {
            int filaAleer = 50; //50 indica que no se encontró registro
            //recorro la columna 0 y leo las filas de esa columna
            for (int i= 0; i<=0; i++)
            {
                for(int j=0; j < 16; j++)
                {
                    if(cod.Equals(prod[j,i]))
                    {
                        filaAleer = j;
                        MessageBox.Show("Producto encontrado");
                        
                    }
                }
            }
            //una vez encontrado el código leo los datos de la fila
            if (filaAleer == 50)
            {
                MessageBox.Show("Código no válido");
                return false;
            }
            else
            {
                prodCodigo = prod[filaAleer, 0];
                prodNombre = prod[filaAleer, 1];
                prodPrecio = prod[filaAleer, 2];
                prodCantidad = prod[filaAleer, 3];
                return true;
            }
            
        }
        //modificar costo * cantidad;
        //entregue cambio y productos correctamente
        /*
         1.- Actualizar el stock en prod[] -> necesito filaAleer para crear un método que actualice stock
         2.- Actualizar el archivo
         */
    }
}
