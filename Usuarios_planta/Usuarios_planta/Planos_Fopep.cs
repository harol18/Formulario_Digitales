using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Usuarios_planta
{
    public partial class Planos_Fopep : Form
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");


        Comandos cmds = new Comandos();
        public Planos_Fopep()
        {
            InitializeComponent();
        }

        private void BtnVer_Cruce_Click(object sender, EventArgs e)
        {
            if (cmbGestion.Text=="Contabilizados")
            {
                try
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    MySqlCommand cmd = new MySqlCommand("cruce_contabilizados_fopep", con);
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                    registro.Fill(dt);
                    dgvDatos.DataSource = dt;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("", ex.ToString());
                    con.Close();
                    MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
