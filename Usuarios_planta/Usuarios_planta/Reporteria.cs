using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usuarios_planta
{
    public partial class Reporteria : Form
    {

        Comandos cmds = new Comandos();

        public Reporteria()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            cmds.Reporteria1(dgvDatos, Txtcod_convenio, cmbEstado_Operacion, cmbDestino, dtpFecha_Inicio, dtpFecha_Final);
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

        private void Exportar_Txt(DataGridView dgvDatos)
        {
            //Esta línea de código crea un archivo de texto para la exportación de datos.
            //StreamWriter file = new StreamWriter(@"C:\\Users\\BBVA\\Desktop\\Colpensiones\\" + "base_desembolso.txt");
            StreamWriter file = new StreamWriter(@"D:\\" + "sabana_carlos.txt");
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

        private void btnDescargar_Excel_Click(object sender, EventArgs e)
        {
            if (cmbEstado_Operacion.Text=="Sabana Carlos Zarate")
            {
                Exportar_Txt(dgvDatos);
            }
            else
            {
                ExportarDatos(dgvDatos);
            }          
        }
    }
}
