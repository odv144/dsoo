using ClubDeportivo.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmApartadoSocio : Form
    {
        

        public frmApartadoSocio()
        {
            InitializeComponent();

            
           
            this.Load += frmApartadoSocio_Load;
        }

        private RepositorySocio repoSocio = new RepositorySocio();

        internal string rol;
        internal string usuario;
        private void btnRegistrarSocio_Click(object sender, EventArgs e)
        {
            frmRegistro registro = new frmRegistro(this);
            registro.ShowDialog();

            CargarSocios();
        }

        // cargo los socios 
        public void CargarSocios()
        {
            try
            {
                DataTable socios = repoSocio.ListarSocios();

                if (socios.Rows.Count > 0)
                {
                    dgvListaSocio.DataSource = socios;
                    dgvListaSocio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvListaSocio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvListaSocio.ReadOnly = true;  
                }
                else
                {
                    dgvListaSocio.DataSource = null;
                    MessageBox.Show("No hay socios registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los socios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgvListaSocio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          CargarSocios();
        }

        // Agrega el método frmApartadoSocio_Load para solucionar el error CS010



        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmApartadoSocio_Load(object sender, EventArgs e)
        {
            CargarSocios();

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            //Tomamos los datos de la grilla y eso se usa para el comprobante de pago
            DataGridViewRow fila = dgvListaSocio.CurrentRow;
            if ( fila!=null)
            {
                try
                {
                  frmComprobantePago pago = new frmComprobantePago() 
                    {
                        nroSocio = Convert.ToInt32(fila.Cells["NroSocio"].Value),
                        apellido = Convert.ToString(fila.Cells["Apellido"].Value),
                        nombre = Convert.ToString(fila.Cells["Nombre"].Value),
                        socio = true,
                        importe = Convert.ToDouble(fila.Cells["CuotaMensual"].Value).ToString(),
                    };
                    pago.ShowDialog();
                }catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
            
            //actualizar la tabla de cuota cambiando estadoPago a true 
            //crear un nuevo registro de cuota del socio con la nueva fecha de vencimiento


        }
    }
}
