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

namespace Usuarios_planta.Capa_presentacion
{
    public partial class Matriz_Convenios : Form
    {

        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");

        Comandos cmds = new Comandos();

        public Matriz_Convenios()
        {
            InitializeComponent();
        }

        public void Cargar_dirigido()
        {
            string cadena = TxtCodigo_Convenio.Text;
            string codigo_convenio = cadena.Substring(0, 3);

            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select Dirigido from matriz_convenios where Codigo=@Codigo", con);
            cmd.Parameters.AddWithValue("Codigo", codigo_convenio);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            DataRow dr = dt.NewRow();
            dr["Dirigido"] = "";
            dt.Rows.InsertAt(dr, 0);
            cmbDirigido.ValueMember = "Dirigido";
            cmbDirigido.DisplayMember = "Dirigido";
            cmbDirigido.DataSource = dt;
        }

        private void Buscar_Matriz(object sender, EventArgs e)
        {
            cmds.Datos_matriz_Total(TxtCod_Matriz, dgvDatos_Matriz);
            if (dgvDatos_Matriz.Rows.Count <1)
            {
                MessageBox.Show("Convenio no se encuentra creado en la matriz, por favor reportar al area encargada");
                
            }
        }


        private void cmbDirigido_Click(object sender, EventArgs e)
        {
            if (TxtCodigo_Convenio.Text != "")
            {
                Cargar_dirigido();
            }
            else if (TxtCodigo_Convenio.Text == "")
            {
                MessageBox.Show("Primero debe digitar codigo del convenio correspondiente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cmbDirigido_SelectedValueChanged(object sender, EventArgs e)
        {
            int largo = TxtCodigo_Convenio.Text.Length;

            if (largo > 2)
            {
                string cadena = TxtCodigo_Convenio.Text;
                string codigo_convenio = cadena.Substring(0, 3);

                if (cmbDirigido.Text == "")
                {
                    TxtCod_Matriz.Text = codigo_convenio;
                }
                else
                {
                    TxtCod_Matriz.Text = codigo_convenio + "-" + cmbDirigido.Text;
                }
            }
        }

        private void ExportarDatos(DataGridView dgvDatos_Matriz)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                int IndiceColumna = 0;
                foreach (DataGridViewColumn columna in dgvDatos_Matriz.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                {
                    IndiceColumna++;
                    excel.Cells[1, IndiceColumna] = columna.Name;
                    excel.Cells[1, IndiceColumna].Font.Bold = true;
                    excel.Cells[1, IndiceColumna].Interior.Color = System.Drawing.Color.FromArgb(219, 229, 241);
                }
                int IndiceFila = 0;
                foreach (DataGridViewRow fila in dgvDatos_Matriz.Rows) //Aquí leemos las filas de las columnas leídas
                {
                    IndiceFila++;
                    IndiceColumna = 0;
                    foreach (DataGridViewColumn columna in dgvDatos_Matriz.Columns)
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
        private void btnDescargar_Excel_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvDatos_Matriz);
        }

        private void Matriz_Convenios_Load(object sender, EventArgs e)
        {
            if (usuario.Perfil=="Lider" || usuario.Perfil == "Administrador")
            {
                Btn_Actualizar_matriz.Visible = true;                
            }
            else
            {
                Btn_Actualizar_matriz.Visible = false;                
            }
        }

        private void Btn_Actualizar_matriz_Click(object sender, EventArgs e)
        {
            cmds.Actualiza_Matriz(dgvDatos_Matriz,TxtCod_Matriz);
        }
    }
}
