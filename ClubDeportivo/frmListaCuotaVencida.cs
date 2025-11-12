using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmListaCuotaVencida : Form
    {
        public frmListaCuotaVencida(frmControlVencimiento frmControl)
        {
            InitializeComponent();
            this.frmCtrlVen=frmControl;

        }
        internal List<E_Cuota> cuotas = new List<E_Cuota>();
        private frmControlVencimiento frmCtrlVen;
        RepositorySocio repoSocio = new RepositorySocio();
        RepositoryCuota repoCuota = new RepositoryCuota();
        private void frmListaCuotaVencida_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            dgvListaCuotaVencida.DataSource = cuotas;
        }

        private void btnActulizarCuota_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow fila = dgvListaCuotaVencida.CurrentRow;
                int nroSocio = Convert.ToInt32(fila.Cells["IdCuota"].Value);
                repoCuota.Actualizar(new E_Cuota
                {
                    IdCuota = nroSocio,
                    NroSocio = Convert.ToInt32(fila.Cells["NroSocio"].Value),
                    FechaVencimiento = Convert.ToDateTime(fila.Cells["FechaVencimiento"].Value),
                    Monto = Convert.ToDouble(fila.Cells["Monto"].Value),
                    MetodoPago = fila.Cells["MetodoPago"].Value.ToString(),
                    Mes = DateTime.Now.Month,
                    Anio = DateTime.Now.Year,
                    //FechaPago = DateTime.Now.AddDays(1),
                    FechaPago = DateTime.Now,
                    EstadoPago = true,
                });

                E_Socio socio = repoSocio.ObtenerConUsuario(nroSocio);
                repoSocio.CambiarEstadoHabilitacion(nroSocio, "activo");
              
                frmComprobantePago pago = new frmComprobantePago()
                {
                    nroSocio = socio.NroSocio,
                    apellido = socio.Usuario.Apellido,
                    nombre = socio.Usuario.Nombre,
                    socio = true,
                    importe = socio.CuotaMensual.ToString(),
                };


                repoCuota.Insertar(new E_Cuota
                {
                    NroSocio = Convert.ToInt32(fila.Cells["NroSocio"].Value),
                    FechaVencimiento = DateTime.Now.AddMonths(1),
                    Monto = Convert.ToDouble(fila.Cells["Monto"].Value),
                    MetodoPago = fila.Cells["MetodoPago"].Value.ToString(),
                    Mes = DateTime.Now.Month,
                    Anio = DateTime.Now.Year,
                    //FechaPago = DateTime.Now.AddDays(1),
                    EstadoPago = false,


                });
                pago.ShowDialog();
                frmCtrlVen.CargarVencimientos();
                MessageBox.Show("Se actualizo el pago y generó la cuota para el mes Proximo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarGrilla()
        {
            dgvListaCuotaVencida.AllowUserToAddRows = false;
            dgvListaCuotaVencida.AllowUserToDeleteRows = false;
            dgvListaCuotaVencida.ReadOnly = true;
            dgvListaCuotaVencida.RowHeadersVisible = false;
            dgvListaCuotaVencida.MultiSelect = false;
            dgvListaCuotaVencida.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaCuotaVencida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListaCuotaVencida.AutoGenerateColumns = true;

            dgvListaCuotaVencida.EnableHeadersVisualStyles = false;
            dgvListaCuotaVencida.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvListaCuotaVencida.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListaCuotaVencida.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvListaCuotaVencida.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvListaCuotaVencida.DefaultCellStyle.SelectionForeColor = Color.White;

            // evento: cuando se termine de enlazar, limpiar selección inicial
            dgvListaCuotaVencida.DataBindingComplete += (s, e) => dgvListaCuotaVencida.ClearSelection();
        }
    }
}
