using ALaMaronaManager.Lists;
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

            dataTable.FillDataTableFromList(_context.ClienteBus.GetAll().ToComboList());

            cmbClientes.DataSource = dataTable;
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "Id";

            this.Show();
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