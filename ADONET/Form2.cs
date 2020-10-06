using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADONET
{
    public partial class Form2 : Form
    {
        SqlConnection conn;
        public Form2(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DESKTOP-B1UNEM2\SQLEXPRESS
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            
            if (conn.State == ConnectionState.Open)
            {
                String sql = "SELECT * FROM Usuario WHERE nombre Like '%'+@param+'%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@param", txtBuscar.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvListado.DataSource = dt;
                dgvListado.Refresh();
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListar_Click_1(object sender, EventArgs e)
        {

            if (conn.State == ConnectionState.Open)
            {
                String sql = "SELECT * FROM Usuario";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvListado.DataSource = dt;
                dgvListado.Refresh();
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }
    }
}
