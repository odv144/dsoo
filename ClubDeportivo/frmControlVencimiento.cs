using ClubDeportivo.Datos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmControlVencimiento : Form
    {
        private RepositoryCuota repoCuota = new RepositoryCuota();


        private DataTable dtOriginal; //  sin filtrar

        public frmControlVencimiento()
        {
            InitializeComponent();
        }

        private void CargarVencimientos()
        {
            try
            {
                // Obtenemos los datos desde el repositorio
                DataTable dt = repoCuota.ObtenerVencimientos();

                // Guardamos una copia intacta (para filtros)
                dtOriginal = dt.Copy();

                // Mostramos los datos en la grilla
                dgvVencimientos.DataSource = dt;

                // Aplicamos el formato visual
                FormatearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los vencimientos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormatearGrilla()
        {
            if (dgvVencimientos.Columns.Count == 0) return;

            dgvVencimientos.Columns["nrosocio"].HeaderText = "N° Socio";
            dgvVencimientos.Columns["NombreCompleto"].HeaderText = "Nombre";
            dgvVencimientos.Columns["mes"].HeaderText = "Mes";
            dgvVencimientos.Columns["anio"].HeaderText = "Año";
            dgvVencimientos.Columns["monto"].HeaderText = "Monto";
            dgvVencimientos.Columns["fechavencimiento"].HeaderText = "Vencimiento";
            dgvVencimientos.Columns["Estado"].HeaderText = "Estado";


            foreach (DataGridViewRow fila in dgvVencimientos.Rows)
            {
                if (fila.Cells["Estado"].Value == null) continue;

                string estado = fila.Cells["Estado"].Value.ToString();

                if (estado == "VENCIDO")
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210);
                else if (estado == "PRÓXIMO A VENCER")
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 196);
                else
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201);
            }
            dgvVencimientos.Columns["nrosocio"].Width = 60;
            dgvVencimientos.Columns["NombreCompleto"].Width = 133;
            dgvVencimientos.Columns["mes"].Width = 40;
            dgvVencimientos.Columns["anio"].Width = 40;
            dgvVencimientos.Columns["monto"].Width = 60;
            dgvVencimientos.Columns["fechavencimiento"].Width = 80;
            dgvVencimientos.Columns["Estado"].Width = 130;
            // Centrar solo el encabezado de la columna "Monto"
            dgvVencimientos.Columns["monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvVencimientos.AllowUserToResizeColumns = false;

            // 🎯 Centramos columnas específicas
            dgvVencimientos.Columns["mes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVencimientos.Columns["anio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVencimientos.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVencimientos.Columns["fechavencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }




        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string filtroSeleccionado = cmbFiltroVencimiento.SelectedItem?.ToString();
            CargarVencimientos();

            // Si había un filtro activo, lo aplicamos de nuevo
            if (!string.IsNullOrEmpty(filtroSeleccionado) && filtroSeleccionado != "Todos")
            {
                cmbFiltroVencimiento.SelectedItem = filtroSeleccionado;
                cmbFiltroVencimiento_SelectedIndexChanged(null, null);
            }
        }


        private void dgvVencimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmControlVencimiento_Load(object sender, EventArgs e)
        {
            CargarVencimientos();
            CrearLeyendaColores();
            InicializarFiltro();
        }

        private void CrearLeyendaColores()
        {

            int baseY = dgvVencimientos.Bottom + 15;
            int baseX = 30;


            // 🔴 LABEL - VENCIDO
            Panel pnlVencido = new Panel();
            pnlVencido.BackColor = Color.LightCoral;
            pnlVencido.Size = new Size(20, 20);
            pnlVencido.Location = new Point(baseX, baseY);
            this.Controls.Add(pnlVencido);

            Label lblVencido = new Label();
            lblVencido.Text = "Vencido";
            lblVencido.Font = new Font("Segoe UI", 10);
            lblVencido.AutoSize = true;
            lblVencido.Location = new Point(pnlVencido.Right + 8, baseY - 1);
            this.Controls.Add(lblVencido);


            // 🟡 LABEL - PRÓXIMO A VENCER
            Panel pnlProximo = new Panel();
            pnlProximo.BackColor = Color.Khaki;
            pnlProximo.Size = new Size(20, 20);
            pnlProximo.Location = new Point(lblVencido.Right + 40, baseY);
            this.Controls.Add(pnlProximo);

            Label lblProximo = new Label();
            lblProximo.Text = "Próximo a vencer (3 días)";
            lblProximo.Font = new Font("Segoe UI", 10);
            lblProximo.AutoSize = true;
            lblProximo.Location = new Point(pnlProximo.Right + 8, baseY - 1);
            this.Controls.Add(lblProximo);

            // ================================
            // 🟢 CUADRADO - AL DÍA
            // ================================
            Panel pnlAlDia = new Panel();
            pnlAlDia.BackColor = Color.LightGreen;
            pnlAlDia.Size = new Size(20, 20);
            pnlAlDia.Location = new Point(lblProximo.Right + 40, baseY);
            this.Controls.Add(pnlAlDia);

            Label lblAlDia = new Label();
            lblAlDia.Text = "Al día";
            lblAlDia.Font = new Font("Segoe UI", 10);
            lblAlDia.AutoSize = true;
            lblAlDia.Location = new Point(pnlAlDia.Right + 8, baseY - 1);
            this.Controls.Add(lblAlDia);
        }



        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void InicializarFiltro()
        {
            cmbFiltroVencimiento.Items.Clear();
            cmbFiltroVencimiento.Items.Add("Todos");
            cmbFiltroVencimiento.Items.Add("VENCIDO");
            cmbFiltroVencimiento.Items.Add("PRÓXIMO A VENCER");
            cmbFiltroVencimiento.Items.Add("AL DÍA");
            cmbFiltroVencimiento.SelectedIndex = 0;
        }

        private void cmbFiltroVencimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dtOriginal == null || cmbFiltroVencimiento.SelectedItem == null)
                return;

            string filtro = cmbFiltroVencimiento.SelectedItem.ToString();
            DataView dv = new DataView(dtOriginal);

            if (filtro == "Todos")
                dv.RowFilter = ""; // sin filtro
            else
                dv.RowFilter = $"Estado = '{filtro}'";

            dgvVencimientos.DataSource = dv;
            FormatearGrilla();



        }

        private void cmbFiltroVencimiento_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblTituloPrincipal_Click(object sender, EventArgs e)
        {

        }
    }
}

