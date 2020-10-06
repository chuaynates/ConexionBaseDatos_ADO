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
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtIngresar_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
            
                String sql = "SELECT * FROM Usuario WHERE nombre Like '%'+@param+'%' and password Like '%'+@param2+'%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@param", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@param2", txtContraseña.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    //DESKTOP-B1UNEM2\SQLEXPRESS
                    MessageBox.Show("Login Exitoso");
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Este usuario no existe");
                    reader.Close();
                }
            }
            else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
