using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Usuarios_planta
{
    public partial class FormEstado_Operaciones : Form
    {
        Comandos cmds = new Comandos();        
        public FormEstado_Operaciones()
        {
            InitializeComponent();
        }       

        private void btnVer_pte_Correos_Click(object sender, EventArgs e)
        {
            cmds.Estado_Operaciones(dgvDatos,cmbEstado_Operacion);           
        }

        private void Txt_Nombreprocesobusqueda_TextChanged(object sender, EventArgs e)
        {
            string filterField = "Codigo_Convenio";
            ((DataTable)dgvDatos.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, Txt_Nombreprocesobusqueda.Text);
        }
      
        private void Exportar_Txt(DataGridView dgvDatos)
        {
            //Esta línea de código crea un archivo de texto para la exportación de datos.
            //StreamWriter file = new StreamWriter(@"C:\\Users\\BBVA\\Desktop\\Colpensiones\\" + "base_desembolso.txt");
            StreamWriter file = new StreamWriter(@"D:\\" + "Estado Operaciones.txt");
            try
            {
                string sLine = "";
                //Este bucle for recorre cada fila de la tabla
                for (int r = 0; r <= dgvDatos.Rows.Count - 1; r++)
                {
                    //Este bucle for recorre cada columna y el número de fila
                    //se pasa desde el bucle for arriba.
                    for (int c = 0; c <= dgvDatos.Columns.Count - 1; c++)
                    {
                        sLine = sLine + dgvDatos.Rows[r].Cells[c].Value;
                        if (c != dgvDatos.Columns.Count - 1)
                        {
                            //Una coma se agrega como delimitador de texto para
                            //para separar cada campo en el archivo de texto.
                            //Puede elegir otro carácter como delimitador, para este caso no se pone delimitador dado
                            //que el plano va toda la informacion pegada sin espacios ni caracteres.
                            sLine = sLine + "|";
                        }
                    }
                    //El texto exportado se escribe en el archivo de texto, una línea a la vez.
                    file.WriteLine(sLine);
                    sLine = "";
                }

                file.Close();
                MessageBox.Show("Ok archivo plano creado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                file.Close();
            }
        }

        private void BtnExportarTxt_Click(object sender, EventArgs e)
        {
            Exportar_Txt(dgvDatos);
        }
    }
}
