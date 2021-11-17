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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace Usuarios_planta
{
    public partial class Cargue_Archivos_Fopep : Form
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");


        Comandos cmds = new Comandos();
        Fopep fop = new Fopep();
        public Cargue_Archivos_Fopep()
        {
            InitializeComponent();
        }

        public void Resultado_Cruce1_Fopep(DataGridView dgvDatos)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("resultado_cruce1_fopep", con);
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
        public void Resultado_Final_Fopep(DataGridView dgvDatos)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("resultado_final_fopep", con);
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

        private void BtnCargar_Contabilizados_Click(object sender, EventArgs e)
        {
            fop.Limpiar_Tablas();
            DialogResult dialogResult = MessageBox.Show("Desea Cargar Contabilizados?", "Cargue Contabilizados", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                fop.Limpiar_Tablas();
                OpenFileDialog d = new OpenFileDialog();
                d.Title = "Importar archivo (.xlsx, .xlsx)";
                d.Filter = "xlsx|*.xlsx";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO contabilizados_fopep(Convenio,consecutivo,prestamo,cedula,importe,plazo,cuota,estado) values (@Convenio,@consecutivo,@prestamo,@cedula,@importe,@plazo,@cuota,@estado)";

                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(d.FileName);
                    Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range range = xlWorksheet.UsedRange;
                    int rows = range.Rows.Count;
                    int cols = range.Columns.Count;
                    for (int i = 2; i <= rows; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Convenio", range.Cells[i, 1].Value2.ToString());
                        cmd.Parameters.AddWithValue("@consecutivo", range.Cells[i, 2].Value2.ToString());
                        cmd.Parameters.AddWithValue("@prestamo", range.Cells[i, 3].Value2);
                        cmd.Parameters.AddWithValue("@cedula", range.Cells[i, 4].Value2.ToString());
                        cmd.Parameters.AddWithValue("@importe", range.Cells[i, 5].Value2.ToString());
                        cmd.Parameters.AddWithValue("@plazo", range.Cells[i, 6].Value2.ToString());
                        cmd.Parameters.AddWithValue("@cuota", range.Cells[i, 7].Value2.ToString());
                        cmd.Parameters.AddWithValue("@estado", range.Cells[i, 8].Value2.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    ///cerrar excel///
                    Marshal.ReleaseComObject(range);
                    Marshal.ReleaseComObject(xlWorksheet);
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                    con.Close();
                    MessageBox.Show("Ok Contabilizados cargados en la base de datos");
                    fop.Ver_Cruce_Cancelados();
                    MessageBox.Show("Ok paso 1");
                    Resultado_Cruce1_Fopep(dgvDatos);
                    MessageBox.Show("Ok paso 2");
                    lbltotal.Text = dgvDatos.Rows.Count.ToString();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }           
        }

        public void Convertir_Ceros()
        {
            foreach (DataGridViewRow row in dgvDatos.Rows)
            {
                string contar3 = row.Cells["contar3"].Value.ToString();

                if (contar3=="")
                {
                    row.Cells["contar3"].Value= 0;
                }
            }
        }

        private void BtnCargar_Recaudos_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea Cargar recaudos del mes anterior", "Cargar Recaudos", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Title = "Importar archivo (.xlsx, .xlsx)";
                d.Filter = "xlsx|*.xlsx";
                if (d.ShowDialog() == DialogResult.OK)
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO recaudos_fopep(cedula,Pagare,Valor_Aplicado,Saldo) values (@cedula,@Pagare,@Valor_Aplicado,@Saldo)";

                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(d.FileName);
                    Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range range = xlWorksheet.UsedRange;
                    int rows = range.Rows.Count;
                    int cols = range.Columns.Count;
                    for (int i = 2; i <= rows; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@cedula", range.Cells[i, 1].Value2.ToString());
                        cmd.Parameters.AddWithValue("@Pagare", range.Cells[i, 2].Value2.ToString());
                        cmd.Parameters.AddWithValue("@Valor_Aplicado", range.Cells[i, 3].Value2.ToString());
                        cmd.Parameters.AddWithValue("@Saldo", range.Cells[i, 4].Value2.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    ///cerrar excel///
                    Marshal.ReleaseComObject(range);
                    Marshal.ReleaseComObject(xlWorksheet);
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                    con.Close();
                    MessageBox.Show("Ok cargue Archivo en la base de datos");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
              
            }
        }
        private void BtnDescargar_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excel = new Excel.Application(); // Instancia a la libreria de Microsoft Office
                excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                int IndiceColumna = 0;
                foreach (DataGridViewColumn columna in dgvDatos.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                {
                    IndiceColumna++;
                    excel.Cells[1, IndiceColumna] = columna.Name;
                    excel.Cells[1, IndiceColumna].Font.Bold = true;
                    excel.Cells[1, IndiceColumna].Interior.Color = Color.FromArgb(219, 229, 241);                    
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
                MessageBox.Show("Ok Archivo Excel creado");
                excel.Visible = true;

            }
            catch (Exception)
            {
                MessageBox.Show("No hay Registros a Exportar.");
            }
            
        }

        private void BtnCargar_Archivo_Final_Click(object sender, EventArgs e)
        {
            fop.Limpiar_Tabla_resultado_cruce_fopep();
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Importar archivo (.xlsx, .xlsx)";
            d.Filter = "xlsx|*.xlsx";
            if (d.ShowDialog() == DialogResult.OK)
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO resultado_cruce_fopep(Convenio,consecutivo,prestamo,cedula,contar1,contar2,contar3,importe,plazo,cuota,estado,observacion) values (@Convenio,@consecutivo,@prestamo,@cedula,@contar1,@contar2,@contar3,@importe,@plazo,@cuota,@estado,@Observacion)";

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(d.FileName);
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range range = xlWorksheet.UsedRange;
                int rows = range.Rows.Count;
                int cols = range.Columns.Count;
                for (int i = 2; i <= rows; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Convenio", range.Cells[i, 1].Value2.ToString());
                    cmd.Parameters.AddWithValue("@consecutivo", range.Cells[i, 2].Value2.ToString());
                    cmd.Parameters.AddWithValue("@prestamo", range.Cells[i, 3].Value2);
                    cmd.Parameters.AddWithValue("@cedula", range.Cells[i, 4].Value2.ToString());
                    cmd.Parameters.AddWithValue("@contar1", range.Cells[i, 5].Value2.ToString());
                    cmd.Parameters.AddWithValue("@contar2", range.Cells[i, 6].Value2.ToString());
                    cmd.Parameters.AddWithValue("@contar3", range.Cells[i, 7].Value2.ToString());
                    cmd.Parameters.AddWithValue("@importe", range.Cells[i, 8].Value2.ToString());
                    cmd.Parameters.AddWithValue("@plazo", range.Cells[i, 9].Value2.ToString());
                    cmd.Parameters.AddWithValue("@cuota", range.Cells[i, 10].Value2.ToString());
                    cmd.Parameters.AddWithValue("@estado", range.Cells[i, 11].Value2.ToString());
                    cmd.Parameters.AddWithValue("@Observacion", range.Cells[i, 12].Value2.ToString());
                    cmd.ExecuteNonQuery();
                }
                ///cerrar excel///
                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(xlWorksheet);
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                con.Close();
                MessageBox.Show("Ok cargue Archivo en la base de datos");
                //fop.Resultado_Cruce_Fopep();
                //Resultado_Final_Fopep(dgvDatos);
                //lbltotal.Text = dgvDatos.Rows.Count.ToString();
            }
        }

        private void BtnVer_Cruce_Final_Click(object sender, EventArgs e)
        {
            fop.Resultado_Cruce_Fopep();
            Resultado_Final_Fopep(dgvDatos);
            MessageBox.Show("Ok Cruces realizados");
        }

        private void BtnVer_Contabilizados_Click(object sender, EventArgs e)
        {
            Convertir_Ceros();
        }
    }
}
