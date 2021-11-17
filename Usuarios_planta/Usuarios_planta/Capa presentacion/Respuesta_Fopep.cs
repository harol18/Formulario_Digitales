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
using System.IO;

namespace Usuarios_planta.Capa_presentacion
{
    public partial class Respuesta_Fopep : Form
    {
        MySqlConnection Con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");

        Comandos cmds = new Comandos();
        public Respuesta_Fopep()
        {
            InitializeComponent();
        }

        private void BtnCargar_Inactivaciones_Click(object sender, EventArgs e)
        {

            cmds.Limpiar_Tabla_Inactivaciones();
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Importar archivo (.txt, .txt)";
            d.Filter = "txt|*.txt";
            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(d.FileName))
                    {                        
                        string line;  //Variable para almacenar
                        while ((line = reader.ReadLine()) != null)
                        {   //Mientras haya mas archivo, leemos mas

                            string tercero = line.Substring(55, 12);
                            string descripcion = line.Substring(178);
                            Con.Open();
                            MySqlCommand cmd = Con.CreateCommand();
                            cmd.CommandText = "INSERT INTO fopep_inactivaciones (tercero,descripcion) value ";
                            cmd.CommandText += "(\"" + tercero + "\",\"" + descripcion + "\")";
                            cmd.ExecuteNonQuery();
                            Con.Close();                            
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Con.Close();
                }
                MessageBox.Show("Ok archivo cargado");

            }
        }

        private void BtnCargar_Descuentos_Click(object sender, EventArgs e)
        {
            cmds.Limpiar_Tabla_Descuentos();
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Importar archivo (.txt, .txt)";
            d.Filter = "txt|*.txt";
            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(d.FileName))
                    {
                        string line;  //Variable para almacenar                        
                        while ((line = reader.ReadLine()) != null)
                        {   //Mientras haya mas archivo, leemos mas

                            string Tipo_Doc = line.Substring(0, 2);
                            string Cedula = line.Substring(2,12);
                            string Cod = line.Substring(14,4);
                            string AÑO_MES = line.Substring(18,4);
                            string SALDO = line.Substring(22,10);
                            string Campo_0 = line.Substring(32,7);
                            string Campo_1 = line.Substring(39,1);
                            string Pagare = line.Substring(40,12);
                            string Dictamen = line.Substring(52,3);                            
                            Con.Open();
                            MySqlCommand cmd = Con.CreateCommand();
                            cmd.CommandText = "INSERT INTO fopep_descuentos (Tipo_Doc,Cedula,Cod,AÑO_MES,SALDO,Campo_0,Campo_1,Pagare,Dictamen,Dictamen_2) value ";
                            cmd.CommandText += "(\"" + Tipo_Doc + "\",\"" + Cedula + "\",\"" + Cod + "\",\"" + AÑO_MES + "\",\"" + SALDO + "\",\"" + Campo_0 + "\",\"" + Campo_1 + "\",\"" + Pagare + "\",\"" + Dictamen + "\",\"" + Dictamen + "\")";
                            cmd.ExecuteNonQuery();
                            Con.Close();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Con.Close();
                }
                MessageBox.Show("Ok archivo cargado");
            }
        }

        private void ExportarDatos(DataGridView dgvDatos)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                int IndiceColumna = 0;
                foreach (DataGridViewColumn columna in dgvDatos.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                {
                    IndiceColumna++;
                    excel.Cells[1, IndiceColumna] = columna.Name;
                    excel.Cells[1, IndiceColumna].Font.Bold = true;
                    excel.Cells[1, IndiceColumna].Interior.Color = System.Drawing.Color.FromArgb(219, 229, 241);
                }
                int IndiceFila = 0;
                foreach (DataGridViewRow fila in dgvDatos.Rows) //Aquí leemos las filas de las columnas leídas
                {
                    IndiceFila++;
                    IndiceColumna = 0;
                    foreach (DataGridViewColumn columna in dgvDatos.Columns)
                    {
                        IndiceColumna++;
                        excel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                    }
                }
                excel.Columns.AutoFit();
                excel.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No hay Registros a Exportar.");
            }
        }
        private void BtnDescargar_Excel_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvDatos);
        }

        private void BtnVer_Inactivaciones_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                MySqlCommand cmd = new MySqlCommand("Select tercero,descripcion from fopep_inactivaciones", Con);                
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvDatos.DataSource = dt;
                Con.Close();         
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                Con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVer_Descuentos_Click(object sender, EventArgs e)
        {

            try
            {
                Con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("descuentos_fopep", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@_Fecha_desembolso", dtp_fecha.Text);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvDatos.DataSource = dt;
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                Con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
