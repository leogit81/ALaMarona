using ALaMarona.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ALaMaronaManager.Forms
{
    public partial class Pedidos : Form
    {
        private readonly PedidoFormContext _context;
        protected DataTable dataTable;
        protected bool rollback;

        public Pedidos(PedidoFormContext context)
        {
            InitializeComponent();

            _context = context;

            SessionManager.BindSession();

            dataTable = new DataTable();
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Id", typeof(long));

            fillDataTableFromList(_context.ClienteBus.GetAll());

            cmbClientes.DataSource = dataTable;
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "Id";

            this.Show();
        }

        private void fillDataTableFromList(IEnumerable<Cliente> clientes)
        {
            dataTable.Rows.Clear();
            foreach (var cliente in clientes)
            {
                DataRow row = dataTable.NewRow();
                row["Nombre"] = getNombreCliente(cliente);
                row["Id"] = cliente.Id;
                dataTable.Rows.Add(row);
            }
        }

        private string getNombreCliente(ALaMarona.Domain.Entities.Cliente x)
        {
            string nombreCliente = string.Empty;

            if (x.Nombre != null
            && !string.IsNullOrEmpty(x.Nombre.Apellido)
            && !string.IsNullOrEmpty(x.Nombre.Primero))
            {
                nombreCliente = x.Nombre?.Apellido + ", " + x.Nombre?.Primero;
            }
            else if (x.Nombre != null && !string.IsNullOrEmpty(x.Nombre.Alias))
            {
                nombreCliente = x.Nombre.Alias;
            }
            else if (!string.IsNullOrEmpty(x.EMail))
            {
                nombreCliente = x.EMail;
            }
            return nombreCliente;
        }

        private void cmbClientes_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            long idCliente;
            if (long.TryParse(cmbClientes.SelectedValue.ToString(), out idCliente))
            {
                dgvPedidos.DataSource = _context.PedidoBus.GetAll().Where(x => x.Cliente?.Id == idCliente).ToList();
            }
        }

        private void Pedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.UnbindSession(rollback);
        }
    }
}