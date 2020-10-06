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
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            String servidor = txtServidor.Text;//DESKTOP-B1UNEM2
            String bd = txtBaseDatos.Text;
            String user = txtUsuario.Text;  
            String pwd = txtPassword.Text;

            String str = "Server="+ servidor + ";DataBase=" + bd + ";";


            if (chkAutenticacion.Checked)
                str += "Integrated Security=true";
            else
                str += "User Id=" + user + ";Password=" + pwd + ";";
        
         try
            {
                conn = new SqlConnection(str);
                conn.Open();
                MessageBox.Show("Conectado Satisfactoriamente");
                btnDesconectar.Enabled = true;
                btnEstado.Enabled = true;
            }
        catch(Exception ex)
            {
                MessageBox.Show("Error al conectar al servidor: \n" + ex.ToString());

            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Closed) 
                {
                    conn.Close();
                    MessageBox.Show("Conexión cerrada satisfactoriamente");
                }
            else
                    MessageBox.Show("La conexión ya esta cerrada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cerrar la conexión: \n" + ex.ToString());
            } }

        private void txtEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    MessageBox.Show("Estado del servidor : " + conn.State +
                        "\nVersión del servidor: " + conn.ServerVersion + "\nBase de Datos: "
                        + conn.Database);
                else
                    MessageBox.Show("Estado del servidor: " + conn.State);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Imposible determinar el estado del servidor: \n" +
                    ex.ToString());
            }
        }

        private void chkAutenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAutenticacion.Checked)
            {
                txtUsuario.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
           Form2 persona = new Form2(conn);
            persona.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login log = new Login(conn);
            log.Show();
        }
    }
}
