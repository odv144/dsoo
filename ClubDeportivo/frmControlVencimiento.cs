using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmControlVencimiento : Form
    {
        private string connectionString = "server=localhost;database=proyecto;uid=root;pwd=1234;";

        public frmControlVencimiento()
        {
            InitializeComponent();
        }
  
        private void CargarVencimientos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        s.nrosocio,
                        CONCAT(u.nombre, ' ', u.apellido) AS NombreCompleto,
                        c.mes,
                        c.anio,
                        c.monto,
                        c.fechavencimiento,
                        CASE 
                            WHEN CURDATE() > c.fechavencimiento THEN 'VENCIDO'
                            WHEN DATEDIFF(c.fechavencimiento, CURDATE()) <= 3 THEN 'PRÓXIMO A VENCER'
                            ELSE 'AL DÍA'
                        END AS Estado
                    FROM cuota c
                    INNER JOIN socio s ON c.nrosocio = s.nrosocio
                    INNER JOIN usuario u ON s.idusuario = u.idusuario
                    ORDER BY c.fechavencimiento ASC;
                ";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvVencimientos.DataSource = dt;

                FormatearGrilla();
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

            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            foreach (DataGridViewRow fila in dgvVencimientos.Rows)
            {
                if (fila.Cells["Estado"].Value == null) continue;

                string estado = fila.Cells["Estado"].Value.ToString();

                if (estado == "VENCIDO")
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (estado == "PRÓXIMO A VENCER")
                    fila.DefaultCellStyle.BackColor = Color.Khaki;
                else
                    fila.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarVencimientos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvVencimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmControlVencimiento_Load(object sender, EventArgs e)
        {
            CargarVencimientos();
            CrearLeyendaColores();
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

            // 🟢 CUADRADO - AL DÍA
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

    }
}
