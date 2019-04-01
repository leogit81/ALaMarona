using ALaMarona.Core.DI;
using ALaMarona.Domain.Entities;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ALaMaronaManager
{
    public partial class BuscarCliente : Form
    {
        private readonly ClienteFormContext _clienteFormCtx;
        private bool rollback = false;

        public BuscarCliente(ClienteFormContext clienteFormCtx)
        {
            InitializeComponent();

            _clienteFormCtx = clienteFormCtx;

            SessionManager.BindSession();

            Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IList<Cliente> clientes = _clienteFormCtx.ClienteBus.GetAll();
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                clientes = clientes.Where(x => x.Nombre?.Primero == txtNombre.Text).ToList();
            }

            //dgvClientes.DataSource = clientes.Select(x => new { Nombre = x.Nombre?.Primero, Apellido = x.Nombre?.Apellido }).ToList();
            dgvClientes.DataSource = clientes;
        }

        private void BuscarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.UnbindSession(rollback);
        }
    }
}