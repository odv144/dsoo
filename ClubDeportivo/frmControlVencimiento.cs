using ClubDeportivo.Datos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmControlVencimiento : Form
    {
        private readonly RepositoryCuota repoCuota = new RepositoryCuota();
        private DataTable dtOriginal;

        public frmControlVencimiento()
        {
            InitializeComponent();
        }

        private void frmControlVencimiento_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            InicializarFiltro();
            CargarVencimientos();
            CrearLeyendaColores();
        }

        private void ConfigurarGrilla()
        {
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AllowUserToDeleteRows = false;
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.MultiSelect = false;
            dgvVencimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVencimientos.RowHeadersVisible = false;
            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVencimientos.EnableHeadersVisualStyles = false;

            dgvVencimientos.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvVencimientos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        public void CargarVencimientos()
        {
            try
            {
                var dt = repoCuota.ObtenerVencimientos();
                dtOriginal = dt.Copy();
                dgvVencimientos.DataSource = dt;

                AplicarColores();
                dgvVencimientos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los vencimientos:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarColores()
        {
            foreach (DataGridViewRow fila in dgvVencimientos.Rows)
            {
                if (fila.IsNewRow) continue;

                string estado = fila.Cells["Estado"]?.Value?.ToString() ?? "";
                Color color = Color.White;

                switch (estado)
                {
                    case "VENCIDO": color = Color.FromArgb(255, 205, 210); break;
                    case "PRÓXIMO A VENCER": color = Color.FromArgb(255, 249, 196); break;
                    case "AL DÍA": color = Color.FromArgb(200, 230, 201); break;
                }

                fila.DefaultCellStyle.BackColor = color;
                fila.DefaultCellStyle.SelectionBackColor = ControlPaint.Dark(color, 0.15f);
                fila.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void InicializarFiltro()
        {
            cmbFiltroVencimiento.Items.Clear();
            cmbFiltroVencimiento.Items.AddRange(new object[]
            {
                "Todos", "VENCIDO", "PRÓXIMO A VENCER", "AL DÍA"
            });
            cmbFiltroVencimiento.SelectedIndex = 0;
        }

        private void cmbFiltroVencimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtOriginal == null) return;

            string filtro = cmbFiltroVencimiento.SelectedItem.ToString();
            DataView vista = new DataView(dtOriginal)
            {
                RowFilter = (filtro == "Todos") ? "" : $"Estado = '{filtro}'"
            };

            dgvVencimientos.DataSource = vista;
            AplicarColores();
            dgvVencimientos.ClearSelection();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarVencimientos();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (dgvVencimientos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila antes de continuar.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int nroSocio = Convert.ToInt32(dgvVencimientos.CurrentRow.Cells["NroSocio"].Value);
                frmListaCuotaVencida listado = new frmListaCuotaVencida(this)
                {
                    cuotas = repoCuota.ObtenerCuotasPorSocio(nroSocio)
                };
                listado.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir cuotas:\n{ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearLeyendaColores()
        {
            // Pequeño bloque para mostrar los colores de referencia (igual que antes)
            int y = dgvVencimientos.Bottom + 15;
            int x = 30;

            AgregarLeyenda(Color.LightCoral, "Vencido", x, y);
            AgregarLeyenda(Color.Khaki, "Próximo a vencer (3 días)", x + 150, y);
            AgregarLeyenda(Color.LightGreen, "Al día", x + 400, y);
        }

        private void AgregarLeyenda(Color color, string texto, int x, int y)
        {
            Panel pnl = new Panel
            {
                BackColor = color,
                Size = new Size(20, 20),
                Location = new Point(x, y)
            };
            this.Controls.Add(pnl);

            Label lbl = new Label
            {
                Text = texto,
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                Location = new Point(x + 28, y - 1)
            };
            this.Controls.Add(lbl);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}



