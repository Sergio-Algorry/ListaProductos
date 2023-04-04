using ListaProductos.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaProductos.FE
{
    public partial class frmListaProductos : Form
    {
        public ListaProducto ListaPrecios { get; set; }=new ListaProducto();


        public frmListaProductos()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Producto pr = new Producto();

            pr.Codigo = txtCod.Text;
            pr.Decripcion=txtDesc.Text;
            pr.Precio=System.Convert.ToDecimal(txtPrecio.Text);

            ListaPrecios.Agregar(pr);

            label4.Text = ListaPrecios.Listar();

        }
    }
}
