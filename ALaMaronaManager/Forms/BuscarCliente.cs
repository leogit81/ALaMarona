using ALaMarona.Domain.Entities;
using ALaMaronaManager.Forms;
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
                clientes = clientes.Where(x => x.Nombre != null
                && ((x.Nombre.Primero != null ? x.Nombre.Primero.ToLower().Contains(txtNombre.Text.ToLower()) : false)
                || (x.Nombre.Segundo != null ? x.Nombre.Segundo.ToLower().Contains(txtNombre.Text.ToLower()) : false)
                || (x.Nombre.Apellido != null ? x.Nombre.Apellido.ToLower().Contains(txtNombre.Text.ToLower()) : false)
                || (x.Nombre.Alias != null ? x.Nombre.Alias.ToLower().Contains(txtNombre.Text.ToLower()) : false))
                || (x.Codigo != null ? x.Codigo.ToLower().Contains(txtNombre.Text.ToLower()) : false)
                || (x.EMail != null ? x.EMail.ToLower().Contains(txtNombre.Text.ToLower()) : false)
                ).ToList();
            }

            var gridClientList = clientes.Select(x => _clienteFormCtx.Mapper.Map<GridClient>(x)).ToList();
            dgvClientes.DataSource = gridClientList;
        }

        private void BuscarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.UnbindSession(rollback);
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var idCliente = (long)dgvClientes.Rows[e.RowIndex].Cells[0].Value;
            var cliente = _clienteFormCtx.ClienteBus.GetById(idCliente);
            _clienteFormCtx.SelectedClient = cliente;

            new ViewEditClient(_clienteFormCtx, FormModes.VIEW);
        }
    }
}