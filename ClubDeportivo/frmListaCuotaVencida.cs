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
            dgvListaCuotaVencida.DataSource = cuotas;
        }

        private void btnActulizarCuota_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                if (dgvListaCuotaVencida.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una actividad para editar.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }*/
                //DataGridViewRow fila = dgvListaCuotaVencida.SelectedRows[0];
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
    }
}
