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
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;
using SpreadsheetLight;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using Outlook = Microsoft.Office.Interop.Outlook;
using OfficeExcel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;


namespace Usuarios_planta
{
    public partial class FormEnvio_Correos : Form
    {
        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");

        Comandos cmds = new Comandos();

        public FormEnvio_Correos()
        {
            InitializeComponent();
        }

        DateTime hoy = DateTime.Now;

        private void FormEnvio_Correos_Load(object sender, EventArgs e)
        {
            lblfecha.Text = hoy.ToString("yyyy-MM-dd");
            lblfecha.Visible = false;
            btnVer_pte_Correos.PerformClick();
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            dgvDatos.Columns.Clear();
            string cadena = Txtcod_convenio.Text;
            string codigo_convenio = cadena.Substring(0, 3);

            MySqlCommand comando = new MySqlCommand("SELECT Correo_Convenio, Correo_GicVb, Tipo_Asunto, Asunto,Dirigido,Nombre_Convenio FROM matriz_convenios WHERE Codigo_Convenio = @Codigo_Convenio ", con);
            comando.Parameters.AddWithValue("@Codigo_Convenio", Txtcod_convenio.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {               
                TxtDestinatario_Correo.Text = registro["Correo_Convenio"].ToString();
                TxtCorreo_Gic.Text = registro["Correo_GicVb"].ToString();               
                usuario.Asunto = registro["Asunto"].ToString();
                usuario.Tipo_Asunto = registro["Tipo_Asunto"].ToString();
                usuario.Seccional = registro["Dirigido"].ToString();
                usuario.Nombre_Convenio = registro["Nombre_Convenio"].ToString();
                con.Close();
            }
            else
            {
                con.Close();
                TxtDestinatario_Correo.Text = null;
                TxtCorreo_Gic.Text = null;                
                MessageBox.Show("Consecutivo no se encuentra en la matriz, por favor reportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtAsunto.Text = "";
            }
            cmds.Enviar_correos(dtpfecha, Txtcod_convenio, dtpHora_Envio, dgvDatos);
            cmds.Copia_correos(TtxCopia_correo);
            dgvDatos.Columns.Add("DICTAMEN", "DICTAMEN");
            if (codigo_convenio == "INP")
            {
                TxtNombre_Archivo.Text = "Solicitud Vobo INP-" + usuario.Nombre_Convenio + " " + hoy.ToString("dd-MM-yyyy");
            }
            else if (codigo_convenio == "IML")
            {
                TxtNombre_Archivo.Text = "Solicitud VoBo IML-" + usuario.Seccional + " " + hoy.ToString("dd-MM-yyyy");
            }                      
            else
            {
                TxtNombre_Archivo.Text = "Envio VoBo " + Txtcod_convenio.Text + " " + hoy.ToString("dd-MM-yyyy");
            }

            if (usuario.Tipo_Asunto == "1")
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    TxtAsunto.Text = usuario.Asunto + " " + row.Cells["NOMBRE"].Value.ToString() + " " + hoy.ToString("dd-MM-yyyy");
                }
            }
            else if (usuario.Tipo_Asunto == "2")
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    TxtAsunto.Text = usuario.Asunto + " " + hoy.ToString("dd-MM-yyyy");
                }
            }           
            else if (usuario.Tipo_Asunto == "3")
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    TxtAsunto.Text = usuario.Asunto + " " + usuario.Seccional + " " + usuario.Nombre_Convenio + " " + hoy.ToString("dd-MM-yyyy");
                }
            }
            else if (usuario.Tipo_Asunto == "4")
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    TxtAsunto.Text = usuario.Asunto + " " + hoy.ToString("dd-MM-yyyy") + " DOCUMENTOS CREDITO " + row.Cells["NOMBRE"].Value.ToString() + " " + row.Cells["CEDULA"].Value.ToString();
                }
            }
            else if (usuario.Tipo_Asunto == "5")
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    TxtAsunto.Text = usuario.Asunto + " Seccional " + usuario.Seccional + " " + hoy.ToString("dd-MM-yyyy");
                }
            }
            else if (usuario.Tipo_Asunto == "6")
            {
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    TxtAsunto.Text = usuario.Asunto + " " +row.Cells["NOMBRE"].Value.ToString()+ " " + row.Cells["CEDULA"].Value.ToString() + " " + hoy.ToString("dd-MM-yyyy");
                }
            }
            else
            {
                MessageBox.Show("Validar campo tipo asunto");
            }                    
        }

        private void dgvCorreos_Pendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtcod_convenio.Text = dgvCorreos_Pendientes.CurrentRow.Cells[0].Value.ToString();
            dtpHora_Envio.Text= dgvCorreos_Pendientes.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnActualizar_BD_Click(object sender, EventArgs e)
        {
            cmds.ActualizaBD_Envio(dgvDatos);
        }

        private void btnVer_pte_Correos_Click(object sender, EventArgs e)
        {
            cmds.Pendiente_correo(dgvCorreos_Pendientes, dtpfecha);
            if (dgvCorreos_Pendientes.RowCount<1)
            {
                MessageBox.Show("No hay operaciones para remitir correo el dia seleccionado!!","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnDescargar_Excel_Click(object sender, EventArgs e)
        {
            string fileName;            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.Title = "To Excel";
            saveFileDialog1.FileName = TxtNombre_Archivo.Text;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                SLDocument sl = new SLDocument();
                SLStyle style = new SLStyle();
                style.Font.Bold = false;
                style.Font.FontSize = 10;                
                style.Font.FontName = "Roboto";
                style.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.FromArgb(141, 180, 226), System.Drawing.Color.LightGray);
                style.Alignment.Horizontal = HorizontalAlignmentValues.Center;

                int columnas = dgvDatos.Columns.Count;
                

                int i = 1;
                foreach (DataGridViewColumn columna in dgvDatos.Columns)
                {
                    sl.SetCellValue(1, i, columna.HeaderText.ToString());
                    sl.SetCellStyle(1, i, style);
                    i++;
                }
                int j = 2;

                if (columnas == 22)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                        sl.SetCellValue(j, 14, row.Cells[13].Value.ToString());
                        sl.SetCellValue(j, 15, row.Cells[14].Value.ToString());
                        sl.SetCellValue(j, 16, row.Cells[15].Value.ToString());
                        sl.SetCellValue(j, 17, row.Cells[16].Value.ToString());
                        sl.SetCellValue(j, 18, row.Cells[17].Value.ToString());
                        sl.SetCellValue(j, 19, row.Cells[18].Value.ToString());
                        sl.SetCellValue(j, 20, row.Cells[19].Value.ToString());
                        sl.SetCellValue(j, 21, row.Cells[20].Value.ToString());
                        j++;
                    }
                }

                else if (columnas == 21)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                        sl.SetCellValue(j, 14, row.Cells[13].Value.ToString());
                        sl.SetCellValue(j, 15, row.Cells[14].Value.ToString());
                        sl.SetCellValue(j, 16, row.Cells[15].Value.ToString());
                        sl.SetCellValue(j, 17, row.Cells[16].Value.ToString());
                        sl.SetCellValue(j, 18, row.Cells[17].Value.ToString());
                        sl.SetCellValue(j, 19, row.Cells[18].Value.ToString());
                        sl.SetCellValue(j, 20, row.Cells[19].Value.ToString());
                        j++;
                    }
                }

                else if (columnas == 20)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                        sl.SetCellValue(j, 14, row.Cells[13].Value.ToString());
                        sl.SetCellValue(j, 15, row.Cells[14].Value.ToString());
                        sl.SetCellValue(j, 16, row.Cells[15].Value.ToString());
                        sl.SetCellValue(j, 17, row.Cells[16].Value.ToString());
                        sl.SetCellValue(j, 18, row.Cells[17].Value.ToString());
                        sl.SetCellValue(j, 19, row.Cells[18].Value.ToString());
                        j++;
                    }
                }

                else if (columnas == 19)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                        sl.SetCellValue(j, 14, row.Cells[13].Value.ToString());
                        sl.SetCellValue(j, 15, row.Cells[14].Value.ToString());
                        sl.SetCellValue(j, 16, row.Cells[15].Value.ToString());
                        sl.SetCellValue(j, 17, row.Cells[16].Value.ToString());
                        sl.SetCellValue(j, 18, row.Cells[17].Value.ToString());
                        j++;
                    }
                }

                else if (columnas == 18)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                        sl.SetCellValue(j, 14, row.Cells[13].Value.ToString());
                        sl.SetCellValue(j, 15, row.Cells[14].Value.ToString());
                        sl.SetCellValue(j, 16, row.Cells[15].Value.ToString());
                        sl.SetCellValue(j, 17, row.Cells[16].Value.ToString());
                        j++;
                    }
                }

                else if (columnas == 17)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                        sl.SetCellValue(j, 14, row.Cells[13].Value.ToString());
                        sl.SetCellValue(j, 15, row.Cells[14].Value.ToString());
                        sl.SetCellValue(j, 16, row.Cells[15].Value.ToString());
                        j++;
                    }
                }

                else if (columnas == 16)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                        sl.SetCellValue(j, 14, row.Cells[13].Value.ToString());
                        sl.SetCellValue(j, 15, row.Cells[14].Value.ToString());
                        j++;
                    }
                }

                else if (columnas == 15)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                        sl.SetCellValue(j, 14, row.Cells[13].Value.ToString());
                        j++;
                    }
                }
                else if (columnas == 14)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        sl.SetCellValue(j, 13, row.Cells[12].Value.ToString());
                        j++;
                    }
                }
                else if (columnas == 13)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        sl.SetCellValue(j, 12, row.Cells[11].Value.ToString());
                        j++;
                    }
                }

                else if (columnas == 12)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());
                        sl.SetCellValue(j, 11, row.Cells[10].Value.ToString());
                        j++;
                    }
                }

                else if (columnas == 11)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        sl.SetCellValue(j, 10, row.Cells[9].Value.ToString());                       
                        j++;
                    }
                }
                else if (columnas == 10)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        sl.SetCellValue(j, 9, row.Cells[8].Value.ToString());
                        j++;
                    }
                }
                else if (columnas == 9)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        sl.SetCellValue(j, 8, row.Cells[7].Value.ToString());
                        j++;
                    }
                }
                else if (columnas == 8)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        sl.SetCellValue(j, 7, row.Cells[6].Value.ToString());
                        j++;
                    }
                }
                else if (columnas == 7)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        sl.SetCellValue(j, 6, row.Cells[5].Value.ToString());
                        j++;
                    }
                }
                else if (columnas == 6)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        sl.SetCellValue(j, 5, row.Cells[4].Value.ToString());
                        j++;
                    }
                }
                else if (columnas == 5)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        sl.SetCellValue(j, 4, row.Cells[3].Value.ToString());
                        j++;
                    }
                }
                else if (columnas == 4)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        sl.SetCellValue(j, 1, row.Cells[0].Value.ToString());
                        sl.SetCellValue(j, 2, row.Cells[1].Value.ToString());
                        sl.SetCellValue(j, 3, row.Cells[2].Value.ToString());
                        j++;
                    }
                }
                sl.AutoFitColumn(1, 22); // ajustar ancho columna
                sl.AutoFitRow(1, 22);
                //sl.SaveAs(@"D:\Archivos_Digitales\" + archivo);
                //sl.SaveAs(@"C:\Users\BBVA\Desktop\Archivos_Digitales\" + archivo);
                sl.SaveAs(fileName);
            }
            MessageBox.Show("Ok archivo creado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnEnviar_Correo_Click(object sender, EventArgs e)
        {
            string htmlString = GetHtml(dgvDatos);
            string archivo = TxtNombre_Archivo.Text + ".xlsx";

            try
            {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;
               
                
                oMailItem.Subject = TxtAsunto.Text;
                oMailItem.To = TxtDestinatario_Correo.Text;
                oMailItem.CC = TxtCorreo_Gic.Text + " ; " + TtxCopia_correo.Text;
                oMailItem.HTMLBody = htmlString;
                //oMailItem.Body = htmlString;
                //oMailItem.Attachments.Add(@"C:\Users\BBVA\Desktop\Archivos_Digitales\" + archivo);                
                oMailItem.BCC = usuario.Correo_Usuario;
                oMailItem.Importance = Outlook.OlImportance.olImportanceHigh;//Asignar Importancia del correo
                oMailItem.Display(true);
                //oMailItem.Send(); // se debe activar cuando se garantice como adjuntar las imagenes para los convenios
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());                
            }           
        } 

        public static string GetHtml(DataGridView grid)
        {
            try
            {
                string messageBody = "<font>Buen Día,<br><br>Adjunto relación para solicitud de VoBo de los clientes en mención..<br><br><br><br>";
                if (grid.RowCount == 0) return messageBody;
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style=\"background-color:#004254; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style=\"color:#000000;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#000000; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";
                string htmlTdparrafo = "<font><br><br><br>Cordialmente<br><br>"+"<strong>"+ usuario.Nombre +"</strong>"+ "<br>VoBo Pagador<br>Calle 75a N° 27a-28<br>Bogotá Colombia<br>Tel: +57 254050 - Ext 26924<br>" +
                    "" + "</font>";
                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;
                for (int i = 0; i < grid.Columns.Count; i++)
                {                   
                    messageBody += htmlTdStart + grid.Columns[i].HeaderText+ htmlTdEnd;
                }                
                messageBody += htmlHeaderRowEnd;

                //Loop all the rows from grid vew and added to html td
                messageBody = messageBody + htmlTrStart;
                
                for (int i = 0; i <= grid.RowCount - 1; i++)
                {
                    for (int x = 0; x < grid.Columns.Count; x++)
                    {
                        messageBody = messageBody + htmlTdStart + grid.Rows[i].Cells[x].Value; //Caso
                    }
                    messageBody = messageBody + htmlTrEnd;
                }
                messageBody = messageBody + htmlTableEnd;
                messageBody = messageBody + htmlTdparrafo;
                return messageBody; // devuelve la tabla HTML como cadena de esta función  
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Btn_Actualizadb_Click(object sender, EventArgs e)
        {
            cmds.ActualizaBD_Envio(dgvDatos);
            this.Close();
            Form formulario = new FormEnvio_Correos();
            formulario.Show();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Form formulario = new FormEnvio_Correos();
            formulario.Show();
        }

        private void BtnCorreo_Destinarios_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(TxtDestinatario_Correo.Text, true);
        }

        private void BtnCorreo_Gic_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(TxtCorreo_Gic.Text,true);
        }

        private void BtnCopia_Correos_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(TtxCopia_correo.Text,true);
        }
    }
}
