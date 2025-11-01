﻿using ClubDeportivo.Datos;
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
            //tomar los datos del grid seleccionado
            //buscar cuotas pendientes
            //cargar un grid con dichas cuotas 
            //en el formulario  con las cuotas al seleccionar permitir pagarlas
            //actualizar la tabla de cuotas con el proximo vencimiento

        }
    }
}
