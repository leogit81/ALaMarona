using ALaMaronaManager.Forms;
using System;
using System.Windows.Forms;

namespace ALaMaronaManager
{
    public partial class ALaMaronaManager : Form
    {
        private readonly IALaMaronaManagerFactory _factory;

        public ALaMaronaManager(IALaMaronaManagerFactory factory)
        {
            _factory = factory;

            InitializeComponent();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BuscarCliente(_factory.CrearClienteFormContext());
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Pedidos(_factory.CrearPedidoFormContext());
        }
    }
}
