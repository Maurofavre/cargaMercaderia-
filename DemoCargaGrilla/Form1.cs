using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCargaTextBoxMultilinea
{
    public partial class Form1 : Form
    {

        public struct ARTICULO
        {
            public string Nombre;
            public int Codigo;
            public float Precio;
        }

        // creamos el arreglo 
        
        const int MAX = 4; 
        ARTICULO[] articulo;
        int pos;

        int control = 0; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = ""; 

            articulo= new ARTICULO[MAX];
            pos = 0;

            //limpiamos la grilla 
            dgvDatos.Rows.Clear();  
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            int control = int.Parse(txtCodigo.Text);    
            bool tieneRepetido = false;


            for (int i = 0; i < pos; i++)
            {
                if (articulo[i].Codigo == control)
                {
                    tieneRepetido = true;
                    MessageBox.Show("Numero repetido");
                    txtCodigo.Text = "";
                    break;
                }
            }


            if (txtNombre.Text!= "" && txtCodigo.Text!= "" && txtPrecio.Text !="" )
            {

                 
               //agregamos elementos 
                articulo[pos].Nombre = txtNombre.Text;
                articulo[pos].Codigo = int.Parse(txtCodigo.Text);
                articulo[pos].Precio=float.Parse(txtPrecio.Text);
                //iteramos para que agregue
                
                pos++;
                //controlar si quedan espacios 
                if (pos == MAX)
                {
                    MessageBox.Show("Datos llenos"); 
                    btnAgregar.Enabled = false;
                }
                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int i; 
            if (chkPrecio.Checked)
            {
                 for ( i = 0; i < MAX; i++)
                  {
                      if (articulo[i].Precio > 1000) { 
                           
                           dgvDatos.Rows.Add(articulo[i].Codigo.ToString(),
                                        articulo[i].Nombre,
                                        articulo[i].Precio.ToString());

                    }
                    
                }
               
            }
            else
            {
                for (i = 0; i < pos; i++)
                {
                    // mostrar en la grilla
                    dgvDatos.Rows.Add(articulo[i].Codigo.ToString(),
                                        articulo[i].Nombre,
                                        articulo[i].Precio.ToString());
                }
            }




        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(e.KeyChar>=48 && e.KeyChar <= 57) && e.KeyChar != 8)
            {
                MessageBox.Show("Solo numeros"); 
                e.Handled = true;
                return; 
            }
        }
    }
}
