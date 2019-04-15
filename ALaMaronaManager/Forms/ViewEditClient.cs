using ALaMarona.Domain.Entities;
using ALaMaronaManager.Lists;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ALaMaronaManager.Forms
{
    public partial class ViewEditClient : Form
    {
        private readonly ClienteFormContext _clienteFormCtx;
        private bool rollback = false;
        private string _mode;

        private DataTable localidadesDS;
        private DataTable provinciasDS;
        private DataTable paisesDS;

        public ViewEditClient(ClienteFormContext context, string mode)
        {
            InitializeComponent();

            _clienteFormCtx = context;
            _mode = mode;

            this.Text = string.Format(this.Text, FormModes.GetFormattedText(mode));

            loadForm();

            this.Show();
        }

        private void loadForm()
        {
            loadCombos();

            var paises = _clienteFormCtx.PaisBus.GetAll();

            var nombrePais = "ARGENTINA";
            if (_clienteFormCtx.SelectedClient != null && _mode != FormModes.NEW)
            {

                txtCodigo.Text = _clienteFormCtx.SelectedClient.Codigo;
                txtNombre.Text = _clienteFormCtx.SelectedClient.Nombre?.Primero 
                    + " " + _clienteFormCtx.SelectedClient.Nombre?.Segundo;
                txtApellido.Text = _clienteFormCtx.SelectedClient.Nombre?.Apellido;
                txtEMail.Text = _clienteFormCtx.SelectedClient.EMail;
                mskTxtTelefono.Text = _clienteFormCtx.SelectedClient.Telefono;
                txtCalle.Text = _clienteFormCtx.SelectedClient.Domicilio?.Calle;
                txtAltura.Text = _clienteFormCtx.SelectedClient.Domicilio?.Altura.ToString();
                txtPiso.Text = _clienteFormCtx.SelectedClient.Domicilio?.Piso;
                txtDepto.Text = _clienteFormCtx.SelectedClient.Domicilio?.Departamento;
                txtCodPostal.Text = _clienteFormCtx.SelectedClient.Domicilio?.CodigoPostal;

                nombrePais = _clienteFormCtx.SelectedClient.Domicilio?.Pais?.Nombre.ToUpper() ?? string.Empty;
            }
            cmbPais.SelectedIndex = cmbPais.FindString(paises.FirstOrDefault(x => x.Nombre.ToUpper() == nombrePais).Nombre);
        }

        private void loadCombos()
        {
            paisesDS = new DataTable();
            paisesDS.Columns.Add("Nombre", typeof(string));
            paisesDS.Columns.Add("Id", typeof(long));
            cmbPais.DisplayMember = "Nombre";
            cmbPais.ValueMember = "Id";

            provinciasDS = new DataTable();
            provinciasDS.Columns.Add("Nombre", typeof(string));
            provinciasDS.Columns.Add("Id", typeof(long));
            cmbProvincia.DisplayMember = "Nombre";
            cmbProvincia.ValueMember = "Id";

            localidadesDS = new DataTable();
            localidadesDS.Columns.Add("Nombre", typeof(string));
            localidadesDS.Columns.Add("Id", typeof(long));
            cmbLocalidades.DisplayMember = "Nombre";
            cmbLocalidades.ValueMember = "Id";

            var paises = _clienteFormCtx.PaisBus.GetAll();
            paisesDS.FillDataTableFromList(paises.ToComboList());
            cmbPais.DataSource = paisesDS;
            cmbProvincia.DataSource = provinciasDS;
            cmbLocalidades.DataSource = localidadesDS;
        }

        private void cmbPais_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var idPais = (long)cmbPais.SelectedValue;
            var pais = _clienteFormCtx.PaisBus.GetById(idPais);
            provinciasDS.FillDataTableFromList(pais.Provincias.ToComboList());
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var idProvincia = (long)cmbPais.SelectedValue;
            var provincia = GetProvinciaById((long)cmbPais.SelectedValue);

            if (provincia != null)
            {
                localidadesDS.FillDataTableFromList(provincia.Localidades.ToComboList());
            }
        }

        private Provincia GetProvinciaById(long idProvincia)
        {
            var pais = _clienteFormCtx.PaisBus.GetAll().FirstOrDefault(x => x.Provincias.Any(y => y.Id == idProvincia));

            if (pais != null)
            {
                return pais.Provincias.FirstOrDefault(x => x.Id == idProvincia);
            }

            return null;
        }

        private void cmbProvincia_DataSourceChanged(object sender, System.EventArgs e)
        {
            var provincia = _clienteFormCtx.SelectedClient?.Domicilio?.Provincia;
            if (provincia != null)
            {
                cmbProvincia.SelectedIndex = cmbProvincia.FindString(provincia.Nombre);
            }
        }

        private void cmbLocalidades_DataSourceChanged(object sender, System.EventArgs e)
        {
            var localidad = _clienteFormCtx.SelectedClient?.Domicilio?.Localidad;
            if (localidad != null)
            {
                cmbLocalidades.SelectedIndex = cmbLocalidades.FindString(localidad.Nombre);
            }
        }
    }
}
