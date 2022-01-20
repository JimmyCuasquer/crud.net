using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.dao;

namespace WindowsFormsApp1
{
    public partial class GestionClientes : Form
    {
        public GestionClientes()
        {
            InitializeComponent();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            renderizarLista();
         
        }
        private void renderizarLista()
        {
            ClienteDao baseDeDatos = new ClienteDao();
            List<Cliente> listaDb = baseDeDatos.listadoDeClientes();
            listClientes.Items.Clear();

            for(int i = 0; i < listaDb.Count; i++)
            {
                Cliente cliente = listaDb[i];
                listClientes.Items.Add(cliente);
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
         Cliente cliente = new Cliente();
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.TarjetaDeCredito = txtTarjetaDeCredito.Text;

            if(lblId.Text != "")
            {
                cliente.Id = lblId.Text;
            }

            ClienteDao baseDeDatos = new ClienteDao();
            baseDeDatos.Guardar(cliente);
            renderizarLista();
            limpiarListado();
            // listClientes.Items.Add(cliente);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)listClientes.SelectedItem;
            

            ClienteDao baseDeDatos = new ClienteDao();
            baseDeDatos.Eliminar(cliente);
            renderizarLista();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)listClientes.SelectedItem;

            txtApellido.Text = cliente.Apellido;
            txtNombre.Text = cliente.Nombre;
            txtTarjetaDeCredito.Text = cliente.TarjetaDeCredito;
            txtTelefono.Text = cliente.Telefono;
            lblId.Text = cliente.Id;
        }

        private void bntAgregar_Click(object sender, EventArgs e)
        {
            limpiarListado();
        }

        private void limpiarListado()
        {
            lblId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTarjetaDeCredito.Text = "";
            txtTelefono.Text = "";
        }
    }
}
