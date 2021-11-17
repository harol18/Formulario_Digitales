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
using System.Configuration;
using System.IO;
using Usuarios_planta.Capa_presentacion;

namespace Usuarios_planta
{
    public partial class Formulario_Captura : Form
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");


        Comandos cmds = new Comandos();
        Conversion c = new Conversion();
        MySqlDataReader dr;

        public Formulario_Captura()
        {
            InitializeComponent();
            Cargar_Grados();
        }

        //validar esta funcion que hace
        public void Ejecutar(string texto)
        {
            TxtRadicado.Text = texto;
        }

        DateTime fecha = DateTime.Now;
        private Timer timer;
               

        private void Enviar_Correos(object sender, EventArgs e)
        {
            Form formulario = new FormEnvio_Correos();
            formulario.Show();
        }

        public void Cargar_dirigido()
        {
            string cadena = TxtCodigo_Convenio.Text;
            string codigo_convenio = cadena.Substring(0, 3);

            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select Dirigido from matriz_convenios where Codigo=@Codigo",con);
            cmd.Parameters.AddWithValue("Codigo", codigo_convenio);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            DataRow dr = dt.NewRow();
            dr["Dirigido"] = "";
            dt.Rows.InsertAt(dr,0);
            cmbDirigido.ValueMember = "Dirigido";
            cmbDirigido.DisplayMember = "Dirigido";
            cmbDirigido.DataSource = dt;
        }

        public void Cargar_Grados()
        {
            con.Open();
            string query = "SELECT Grado from grados_militares order by Grado desc";
            MySqlCommand comando = new MySqlCommand(query, con);
            MySqlDataAdapter da1 = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            DataRow fila = dt.NewRow();
            fila["Grado"] = "Seleccione grado";
            dt.Rows.InsertAt(fila, 0);
            cmbGrado.ValueMember = "Grado";
            cmbGrado.DisplayMember = "Grado";
            cmbGrado.DataSource = dt;
        }

        private void Buscar_Registro(object sender, EventArgs e)
        {
            cmds.Buscar_vobo(TxtRadicado, TxtCedula_Cliente, TxtNombre_Cliente, dtpFecha_Nacimiento, TxtEdad_Cliente, TxtEstatura, TxtPeso, TxtScoring, cmbFuerza_Venta, TxtCodigo_Convenio, cmbDirigido, 
                             TxtCod_Matriz, TxtConsecutivo, cmbGrado, TxtCod_Militar1, cmbDestino, TxtSubproducto, TxtTasa_E_A, TxtTasa_N_M, TxtMonto_Aprobado, TxtPlazo_Aprobado,
                             TxtValor_Cuota, TxtValor_Cuota1, TxtTotal_Credito, TxtMonto_Letras, TxtTotal_Letras, TxtCartera1, TxtCartera2, TxtCartera3, TxtCartera4, TxtCartera5, TxtCartera6, TxtCartera7, 
                             TxtCartera8, TxtObligacion1, TxtObligacion2, TxtObligacion3, TxtObligacion4, TxtObligacion5, TxtObligacion6, TxtObligacion7, TxtObligacion8, TxtValor1, TxtValor2,
                             TxtValor3, TxtValor4, TxtValor5, TxtValor6, TxtValor7, TxtValor8, TxtValor_Seguro, TxtGestor, TxtCoordinador, TxtOficina, cmbFormato_Seguros, cmbReporte_Enfermedad,
                             cmbSeguros_Monto, cmbSobrepeso, cmbEstado_Reporte,dtpFecha_Envio, cmbCorte_Envio, dtpHora_Envio,
                             dtpFecha_Posible_Rta, dtpFecha_Restriccion, cmbEstado_Operacion, cmbTipologia, TxtEstado_Correo, TtxRespuesta_Correo, dtpFecha_Cierre_Etapa,
                             TxtComentarios, TxtObservaciones);
            if (TxtCodigo_Convenio.Text=="NEJ")
            {
                cmbGrado.Enabled = true;
                TxtCod_Militar1.Enabled = true;
            }
            else
            {
                cmbGrado.Enabled = false;
                TxtCod_Militar1.Enabled = false;
            }
            if (TxtCod_Matriz.Text =="CAS" || TxtCod_Matriz.Text == "RFM")
            {                
                dtpFecha_Envio.Enabled = false;
                cmbCorte_Envio.Enabled = false;
                dtpHora_Envio.Enabled = false;
                dtpFecha_Posible_Rta.Enabled = false;
                TxtEstado_Correo.Enabled = false;
                TtxRespuesta_Correo.Enabled = false;
            }
            else
            {
                dtpFecha_Envio.Enabled = true;
                cmbCorte_Envio.Enabled = true;
                dtpHora_Envio.Enabled = true;
                dtpFecha_Posible_Rta.Enabled = true;
                TxtEstado_Correo.Enabled = true;
                TtxRespuesta_Correo.Enabled = true;
            }
            
            string largo = TxtMonto_Aprobado.Text;            
            int length =largo.Length;

            if (TxtMonto_Aprobado.Text != "")
            {
                TxtMonto_Aprobado.Text = string.Format("{0:#,##0.##}", double.Parse(TxtMonto_Aprobado.Text));
            }
            if (TxtValor_Cuota.Text != "")
            {
                TxtValor_Cuota.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_Cuota.Text));
            }
            if (TxtValor_Cuota1.Text != "")
            {
                TxtValor_Cuota1.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_Cuota1.Text));
            }
            if (TxtValor_Seguro.Text != "")
            {
                TxtValor_Seguro.Text = string.Format("{0:#,##0.##}", double.Parse(TxtValor_Seguro.Text));
            }
            if (TxtTotal_Credito.Text != "")
            {
                TxtTotal_Credito.Text = string.Format("{0:#,##0.##}", double.Parse(TxtTotal_Credito.Text));
            }
        }

        private void Formulario_Captura_Load(object sender, EventArgs e)
        {
            TxtRadicado.Focus();
            timer1.Enabled = true;
            lblfecha.Text = fecha.ToString("yyyy-MM-dd");            
            dtpFecha_Envio.Text = "01/01/2021";
            dtpFecha_Posible_Rta.Text = "01/01/2021";
            dtpFecha_Restriccion.Text = "01/01/2021";
            dtpFecha_Cierre_Etapa.Text = "01/01/2021";
            dtpFecha_Nacimiento.Text = "2021-01-01";
            TxtCod_Militar1.Enabled = false;
            cmbGrado.Enabled = false;           
            MySqlCommand cmd = new MySqlCommand("SELECT nombre_entidad FROM tf_entidades", con);
            con.Open();
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                Collection.Add(dr.GetString(0));
            }
            TxtCartera1.AutoCompleteCustomSource = Collection;
            TxtCartera2.AutoCompleteCustomSource = Collection;
            TxtCartera3.AutoCompleteCustomSource = Collection;
            TxtCartera4.AutoCompleteCustomSource = Collection;
            TxtCartera5.AutoCompleteCustomSource = Collection;
            TxtCartera6.AutoCompleteCustomSource = Collection;
            TxtCartera7.AutoCompleteCustomSource = Collection;
            TxtCartera8.AutoCompleteCustomSource = Collection;
            dr.Close();
            con.Close();
            try
            {
               cmds.Pendiente_correo4(dgvCorreos_Pendientes, lblfecha);
               cmds.Pendiente_correo2(lblfecha,lbltotal);
               cmds.Pendiente_correo3(lblfecha, lblanterior);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void EventoTemporizador(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Prueba");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TxtTotal_Credito_TextChanged(object sender, EventArgs e)
        {
            TxtTotal_Letras.Text = c.enletras(TxtTotal_Credito.Text).ToUpper() + " PESOS";
        }

        private void BtnCopiar_Monto_letras_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(TxtMonto_Letras.Text, true);
        }

        private void BtnCopiar_Total_Letras_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(TxtTotal_Letras.Text, true);
        }

        private void BtnCopiar_Comentarios_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(TxtComentarios.Text, true);
        }

        private void TxtMonto_Aprobado_Validated(object sender, EventArgs e)
        {
            if (cmbFuerza_Venta.Text== "Red Oficina")
            {
                if (Convert.ToDouble(TxtMonto_Aprobado.Text) > 0)
                {
                    TxtMonto_Aprobado.Text = string.Format("{0:#,##0}", double.Parse(TxtMonto_Aprobado.Text));
                }
                else if (TxtMonto_Aprobado.Text == "")
                {
                    TxtMonto_Aprobado.Text = Convert.ToString(0);
                }
            }
            else
            {

                int Edad = Convert.ToInt32(TxtEdad_Cliente.Text);
                if (Convert.ToDouble(TxtMonto_Aprobado.Text) > 0)
                {
                    TxtMonto_Aprobado.Text = string.Format("{0:#,##0}", double.Parse(TxtMonto_Aprobado.Text));
                    if (Convert.ToDouble(TxtMonto_Aprobado.Text) >= 500000000)
                    {
                        MessageBox.Show("Reportar operación a SEGUROS BBVA, Monto igual o mayor a $500 Millones de pesos");
                        cmbSeguros_Monto.Text = "Reportar";
                        cmbEstado_Reporte.Text = "Pte Preformalizacion";

                    }
                    else if (Convert.ToDouble(TxtMonto_Aprobado.Text) >= 300000000 && Convert.ToDouble(TxtMonto_Aprobado.Text) < 500000000 && Edad >= 70)
                    {
                        MessageBox.Show("Reportar operación a SEGUROS BBVA, Monto igual o mayor a $300 Millones de pesos y cliente con mas de 70 años");
                        cmbSeguros_Monto.Text = "Reportar";
                        cmbEstado_Reporte.Text = "Pte Preformalizacion";
                    }
                    else if (Convert.ToDouble(TxtMonto_Aprobado.Text) >= 50000000 && Edad >= 72)
                    {
                        MessageBox.Show("Reportar operación a SEGUROS BBVA, Monto igual o mayor a $50 Millones de pesos y cliente con mas de 72 años");
                        cmbSeguros_Monto.Text = "Reportar";
                        cmbEstado_Reporte.Text = "Pte Preformalizacion";
                    }
                    else
                    {
                        cmbSeguros_Monto.Text = "No Aplica";
                    }
                }
                else if (TxtMonto_Aprobado.Text == "")
                {
                    TxtMonto_Aprobado.Text = Convert.ToString(0);
                }
            }
        }

        private void TeclaEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void BorrarMensajeErrorRedOficina()
        {
            epError.SetError(TxtScoring, "");
            epError.SetError(TxtMonto_Aprobado, "");
            epError.SetError(TxtPlazo_Aprobado, "");
            epError.SetError(TxtCedula_Cliente, "");
            epError.SetError(TxtNombre_Cliente, "");
            epError.SetError(TxtValor_Cuota1, "");
            epError.SetError(TxtCod_Matriz, "");            
        }
        private void BorrarMensajeError()
        {
            epError.SetError(TxtScoring, "");
            epError.SetError(TxtMonto_Aprobado, "");
            epError.SetError(TxtPlazo_Aprobado, "");
            epError.SetError(TxtCedula_Cliente, "");
            epError.SetError(TxtNombre_Cliente, "");
            epError.SetError(TxtValor_Cuota1, "");
            epError.SetError(TxtCod_Matriz, "");
            epError.SetError(dtpFecha_Nacimiento, "");
            epError.SetError(cmbFormato_Seguros, "");
            epError.SetError(cmbReporte_Enfermedad, "");
            epError.SetError(cmbSeguros_Monto, "");
        }

        private bool validar_Red_Oficina()
        {
            bool ok = true;

            if (TxtCedula_Cliente.Text == "")
            {
                ok = false;
                epError.SetError(TxtCedula_Cliente, "Debes diligenciar cedula del cliente");
            }
            if (TxtNombre_Cliente.Text == "")
            {
                ok = false;
                epError.SetError(TxtNombre_Cliente, "Debes diligenciar nombre del cliente");
            }
            if (TxtValor_Cuota1.Text == "")
            {
                ok = false;
                epError.SetError(TxtValor_Cuota1, "Debes diligenciar valor de la cuota en ambos campos");
            }
            if (TxtValor_Cuota.Text == "")
            {
                ok = false;
                epError.SetError(TxtValor_Cuota, "Debes diligenciar valor de la cuota en ambos campos");
            }
            if (TxtScoring.Text == "")
            {
                ok = false;
                epError.SetError(TxtScoring, "Debes digitar N° Scoring");
            }
            if (TxtMonto_Aprobado.Text == "")
            {
                ok = false;
                epError.SetError(TxtMonto_Aprobado, "Debes digitar Monto");
            }
            if (TxtPlazo_Aprobado.Text == "")
            {
                ok = false;
                epError.SetError(TxtPlazo_Aprobado, "Debes digitar Plazo");
            }
            if (TxtCod_Matriz.Text == "")
            {
                ok = false;
                epError.SetError(TxtCod_Matriz, "Debes seleccionar el campo dirigido");
            }            
            return ok;
        }
        private bool validar()
        {
            bool ok = true;

            if (TxtCedula_Cliente.Text == "")
            {
                ok = false;
                epError.SetError(TxtCedula_Cliente, "Debes diligenciar cedula del cliente");
            }
            if (TxtNombre_Cliente.Text == "")
            {
                ok = false;
                epError.SetError(TxtNombre_Cliente, "Debes diligenciar nombre del cliente");
            }
            if (TxtValor_Cuota1.Text == "")
            {
                ok = false;
                epError.SetError(TxtValor_Cuota1, "Debes diligenciar valor de la cuota en ambos campos");
            }
            if (TxtValor_Cuota.Text == "")
            {
                ok = false;
                epError.SetError(TxtValor_Cuota, "Debes diligenciar valor de la cuota en ambos campos");
            }
            if (TxtScoring.Text == "")
            {
                ok = false;
                epError.SetError(TxtScoring, "Debes digitar N° Scoring");
            }
            if (TxtMonto_Aprobado.Text == "")
            {
                ok = false;
                epError.SetError(TxtMonto_Aprobado, "Debes digitar Monto");
            }
            if (TxtPlazo_Aprobado.Text == "")
            {
                ok = false;
                epError.SetError(TxtPlazo_Aprobado, "Debes digitar Plazo");
            }
            if (TxtCod_Matriz.Text == "")
            {
                ok = false;
                epError.SetError(TxtCod_Matriz, "Debes seleccionar el campo dirigido");
            }
            if (dtpFecha_Nacimiento.Text == "2021-01-01")
            {
                ok = false;
                epError.SetError(dtpFecha_Nacimiento, "Debes seleccionar fecha de nacimiento del cliente");
            }
            if (cmbFormato_Seguros.Text == "")
            {
                ok = false;
                epError.SetError(cmbFormato_Seguros, "El campo Formato de seguros BBVA no debe ir vacio");
            }
            if (cmbReporte_Enfermedad.Text == "")
            {
                ok = false;
                epError.SetError(cmbReporte_Enfermedad, "El campo Enfermedad no debe ir vacio");
            }
            if (cmbSeguros_Monto.Text == "")
            {
                ok = false;
                epError.SetError(cmbSeguros_Monto, "El campo Monto seguros no debe ir vacio");
            }
            if (cmbEstado_Reporte.Text == "")
            {
                ok = false;
                epError.SetError(cmbEstado_Reporte, "El campo Preformalizacion no debe ir vacio");
            }

            if (TxtEstatura.Text == "")
            {
                ok = false;
                epError.SetError(TxtEstatura, "Diligenciar el campo estatura, debe ir sin el punto de la separacion");
            }

            if (TxtPeso.Text == "")
            {
                ok = false;
                epError.SetError(TxtPeso, "Debe diligenciar peso del cliente");
            }
            return ok;
        }
        private void Guardar(object sender, EventArgs e)
        {
            if (cmbFuerza_Venta.Text== "Red Oficina")
            {
                BorrarMensajeErrorRedOficina();
                if (validar_Red_Oficina())
                {
                    if (cmbEstado_Operacion.Text == "Aprobado" && cmbEstado_Reporte.Text == "Pte Preformalizacion")
                    {
                        MessageBox.Show("Caso no puede avanzar como aprobado si el estado de seguros no esta Ok Preformalizado");
                    }
                    else
                    {
                        cmds.Guardar_vobo(TxtRadicado, TxtCedula_Cliente, TxtNombre_Cliente, dtpFecha_Nacimiento, TxtEdad_Cliente, TxtEstatura, TxtPeso, TxtScoring, cmbFuerza_Venta, TxtCodigo_Convenio,
                                                          cmbDirigido, TxtCod_Matriz, TxtConsecutivo, cmbGrado, TxtCod_Militar1, cmbDestino, TxtSubproducto, TxtTasa_E_A, TxtTasa_N_M,
                                                          TxtMonto_Aprobado, TxtPlazo_Aprobado, TxtValor_Cuota, TxtTotal_Credito, TxtMonto_Letras, TxtTotal_Letras, TxtCartera1, TxtCartera2,
                                                          TxtCartera3, TxtCartera4, TxtCartera5, TxtCartera6, TxtCartera7, TxtCartera8, TxtObligacion1, TxtObligacion2, TxtObligacion3, TxtObligacion4,
                                                          TxtObligacion5, TxtObligacion6, TxtObligacion7, TxtObligacion8, TxtValor1, TxtValor2, TxtValor3, TxtValor4, TxtValor5, TxtValor6,
                                                          TxtValor7, TxtValor8, TxtValor_Seguro, TxtGestor, TxtCoordinador, TxtOficina, cmbFormato_Seguros, cmbReporte_Enfermedad, cmbSeguros_Monto, cmbSobrepeso, cmbEstado_Reporte,
                                                          dtpFecha_Envio, cmbCorte_Envio, dtpHora_Envio, dtpFecha_Posible_Rta,
                                                          dtpFecha_Restriccion, cmbEstado_Operacion, cmbTipologia, TxtEstado_Correo, TtxRespuesta_Correo, dtpFecha_Cierre_Etapa,
                                                          TxtComentarios, TxtObservaciones);
                        //Btn_Nuevo.PerformClick();
                    }
                }
            }
            else
            {
                BorrarMensajeError();
                if (validar())
                {
                    if (cmbEstado_Operacion.Text == "Aprobado" && cmbEstado_Reporte.Text == "Pte Preformalizacion")
                    {
                        MessageBox.Show("Caso no puede avanzar como aprobado si el estado de seguros no esta Ok Preformalizado");
                    }
                    else
                    {
                        cmds.Guardar_vobo(TxtRadicado, TxtCedula_Cliente, TxtNombre_Cliente, dtpFecha_Nacimiento, TxtEdad_Cliente, TxtEstatura, TxtPeso, TxtScoring, cmbFuerza_Venta, TxtCodigo_Convenio,
                                                          cmbDirigido, TxtCod_Matriz, TxtConsecutivo, cmbGrado, TxtCod_Militar1, cmbDestino, TxtSubproducto, TxtTasa_E_A, TxtTasa_N_M,
                                                          TxtMonto_Aprobado, TxtPlazo_Aprobado, TxtValor_Cuota, TxtTotal_Credito, TxtMonto_Letras, TxtTotal_Letras, TxtCartera1, TxtCartera2,
                                                          TxtCartera3, TxtCartera4, TxtCartera5, TxtCartera6, TxtCartera7, TxtCartera8, TxtObligacion1, TxtObligacion2, TxtObligacion3, TxtObligacion4,
                                                          TxtObligacion5, TxtObligacion6, TxtObligacion7, TxtObligacion8, TxtValor1, TxtValor2, TxtValor3, TxtValor4, TxtValor5, TxtValor6,
                                                          TxtValor7, TxtValor8, TxtValor_Seguro, TxtGestor, TxtCoordinador, TxtOficina, cmbFormato_Seguros, cmbReporte_Enfermedad, cmbSeguros_Monto, cmbSobrepeso, cmbEstado_Reporte,
                                                          dtpFecha_Envio, cmbCorte_Envio, dtpHora_Envio, dtpFecha_Posible_Rta,
                                                          dtpFecha_Restriccion, cmbEstado_Operacion, cmbTipologia, TxtEstado_Correo, TtxRespuesta_Correo, dtpFecha_Cierre_Etapa,
                                                          TxtComentarios, TxtObservaciones);
                        //Btn_Nuevo.PerformClick();
                    }
                }
            }          
        }

        private void TxtScoring_Validated(object sender, EventArgs e)
        {
            string largo = TxtScoring.Text;
            string length = Convert.ToString(largo.Length);

            if (Convert.ToInt32(length) < 20)
            {
                MessageBox.Show("Numero de scoring no cuenta con los 20 digitos correspondientes !! por favor revisar");                
            }
        }
        
        private void TxtCodigo_Convenio_Validated(object sender, EventArgs e)
        {
            string cadena = TxtCodigo_Convenio.Text;
            int largo = TxtCodigo_Convenio.Text.Length;

            if (largo > 2)
            {
                string codigo_convenio = cadena.Substring(0, 3);
                if (codigo_convenio == "NEJ")
                {
                    cmbGrado.Enabled = true;
                    TxtCod_Militar1.Enabled = true;                    
                }
                else if (codigo_convenio == "CAS" || codigo_convenio == "RFM")
                {
                    cmbGrado.Enabled = false;
                    TxtCod_Militar1.Enabled = false;                    
                    dtpFecha_Envio.Enabled = false;
                    cmbCorte_Envio.Enabled = false;
                    dtpHora_Envio.Enabled = false;
                    dtpFecha_Posible_Rta.Enabled = false;
                    TxtEstado_Correo.Enabled = false;
                    TtxRespuesta_Correo.Enabled = false;
                }
                else
                {
                    dtpFecha_Envio.Enabled = true;
                    cmbCorte_Envio.Enabled = true;
                    dtpHora_Envio.Enabled = true;
                    dtpFecha_Posible_Rta.Enabled = true;
                    TxtEstado_Correo.Enabled = true;
                    TtxRespuesta_Correo.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("debe digitar correctamente el codigo del convenio");
            }          
        }
        private void TxtMonto_Aprobado_TextChanged(object sender, EventArgs e)
        {
            TxtMonto_Letras.Text = c.enletras(TxtMonto_Aprobado.Text).ToUpper() + " PESOS";
        }

        private void TxtValor_Cuota_Validated(object sender, EventArgs e)
        {
            TxtValor_Cuota.Text = string.Format("{0:#,##0}", double.Parse(TxtValor_Cuota.Text));
            TxtTotal_Credito.Text = (double.Parse(TxtValor_Cuota.Text) * double.Parse(TxtPlazo_Aprobado.Text)).ToString();

            if (Convert.ToDouble(TxtTotal_Credito.Text) > 0)
            {
                TxtTotal_Credito.Text = string.Format("{0:#,##0}", double.Parse(TxtTotal_Credito.Text));

            }
            else if (TxtTotal_Credito.Text == "")
            {
                TxtTotal_Credito.Text = Convert.ToString(0);
            }

            if (TxtValor_Cuota1.Text == TxtValor_Cuota.Text)
            {

            }                
            else
            {
                MessageBox.Show("Valor de la cuota no coincide");
                TxtValor_Cuota1.Focus();
                TxtValor_Cuota1.Text = "";
                TxtValor_Cuota.Text = "";
            }     
        }
       
        private void Nuevo() 
        {
            dgvCasos_Cliente.DataSource = null;
            TxtCedula_Casos.Text = "";
            cmbEstado_Operacion.Text = null;
            cmbTipologia.Text = "";
            cmbCorte_Envio.Text = null;
            TxtEstado_Correo.Text = null;
            TtxRespuesta_Correo.Text = null;
            TxtComentarios.Text = null;
            TxtNombre_Conveniomt.Text = null;
            TxtRestriccionmt.Text = null;
            Txt_Horarios_gestionmt.Text = null;
            dtpFecha_Envio.Text = "01/01/2020";
            dtpHora_Envio.Text = "00:00";
            dtpFecha_Posible_Rta.Text = "01/01/2020";
            dtpFecha_Restriccion.Text = "01/01/2020";
            dtpFecha_Cierre_Etapa.Text = "01/01/2020";
            TxtRadicado.Text = null;
            TxtCedula_Cliente.Text = null;
            TxtNombre_Cliente.Text = null;
            TxtEdad_Cliente.Text = "0";
            TxtScoring.Text = null;
            cmbFuerza_Venta.Text = null;
            TxtCodigo_Convenio.Text = null;
            cmbDirigido.Text = null;
            TxtCod_Matriz.Text = null;
            TxtConsecutivo.Text = null;
            cmbGrado.Text = null;
            TxtCod_Militar1.Text = null;            
            cmbDestino.Text = null;
            TxtSubproducto.Text = null;
            TxtTasa_E_A.Text = null;
            TxtTasa_N_M.Text = null;
            TxtMonto_Aprobado.Text = null;
            TxtValor_Cuota.Text = null;
            TxtValor_Cuota1.Text = null;
            TxtTotal_Credito.Text = null;
            TxtMonto_Letras.Text = null;
            TxtTotal_Letras.Text = null;
            TxtPlazo_Aprobado.Text = null;
            TxtCartera1.Text = "";
            TxtCartera2.Text = "";
            TxtCartera3.Text = "";
            TxtCartera4.Text = "";
            TxtCartera5.Text = "";
            TxtCartera6.Text = "";
            TxtCartera7.Text = "";
            TxtCartera8.Text = "";
            TxtObligacion1.Text = "";
            TxtObligacion2.Text = "";
            TxtObligacion3.Text = "";
            TxtObligacion4.Text = "";
            TxtObligacion5.Text = "";
            TxtObligacion6.Text = "";
            TxtObligacion7.Text = "";
            TxtObligacion8.Text = "";
            TxtValor1.Text = null;
            TxtValor2.Text = null;
            TxtValor3.Text = null;
            TxtValor4.Text = null;
            TxtValor5.Text = null;
            TxtValor6.Text = null;
            TxtValor7.Text = null;
            TxtValor8.Text = null;
            TxtValor_Seguro.Text = null;
            TxtGestor.Text = null;
            TxtCoordinador.Text = null;
            TxtOficina.Text = null;
            TxtObservaciones.Text = null;
            TxtEstatura.Text = null;
            TxtPeso.Text = null;            
            cmbFormato_Seguros.Text = "";
            cmbReporte_Enfermedad.Text = "";
            cmbSeguros_Monto.Text = "";
            cmbSobrepeso.Text = "";
            cmbEstado_Reporte.Text = "";
            dtpFecha_Nacimiento.Text = "2021-01-01";
            TxtEdad_Cliente.Text = "";
            cmds.Pendiente_correo4(dgvCorreos_Pendientes, lblfecha);
            cmds.Pendiente_correo2(lblfecha, lbltotal);
            cmds.Pendiente_correo3(lblfecha, lblanterior);
            Clipboard.Clear();
        }

        private void cmbEstado_Operacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string extrae_codfuncionario;
            int largo = TxtCodigo_Convenio.Text.Length;
            Console.WriteLine(largo);

            if (largo>2)
            {

                string cadena = TxtCodigo_Convenio.Text;
                string codigo_convenio = cadena.Substring(0, 3);


                extrae_codfuncionario = usuario.Identificacion.Substring(usuario.Identificacion.Length - 3); // extrae los ultimos 5 digitos del textbox 

                if (cmbEstado_Operacion.Text == "Aprobado")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Crédito aprobado scoring " + TxtScoring.Text + " Monto " + TxtMonto_Aprobado.Text + " Plazo " + TxtPlazo_Aprobado.Text + " Meses Destino " + cmbDestino.Text + " " + extrae_codfuncionario;
                    dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                }
                else if (cmbEstado_Operacion.Text == "Negado")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Crédito negado por el pagador scoring " + TxtScoring.Text + " "+ extrae_codfuncionario;
                }
                else if (cmbEstado_Operacion.Text == "Devuelto 1")
                {

                    if (codigo_convenio == "RFM")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Gestionar con el pensionado la autorización para la consulta de cupo y reactivar el caso adjuntando el pantallazo de autorizacion en pdf que arroja la herramienta. " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else if (codigo_convenio == "CAS")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Por favor gestionar con el pensionado la radicación de la solicitud de crédito libranza a través de la plataforma Dibanka y reactivar caso para continuar proceso " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else if (codigo_convenio == "MUM")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Gestionar con el pensionado la autorización para la consulta de cupo y reactivar el caso adjuntando el pantallazo de autorizacion en pdf que arroja la herramienta. " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else if (codigo_convenio == "SEB")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Gestionar con el cliente la autorización para la consulta de cupo y reactivar el caso adjuntando el pantallazo de autorizacion en pdf que arroja la herramienta. " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else
                    {

                    }
                }
                else if (cmbEstado_Operacion.Text == "Devuelto 2")
                {

                    if (codigo_convenio == "RFM")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Gestionar con el cliente la confirmación de la libranza a través de www.sygnus.co el Plazo máximo para la confirmación es de 48 Horas y reactivar el caso para continuar el proceso de lo contrario se tendrá que reprocesar nuevamente en plataforma. " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else if (codigo_convenio == "CAS")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Gestionar con el pensionado la aceptación de las nuevas condiciones del crédito a través de casur.dibanka.co y reactivar caso informando la aceptación o negación por parte del pensionado " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else if (codigo_convenio == "MUM")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Gestionar con el cliente la confirmación de la libranza a través de www.sygnus.co el Plazo máximo para la confirmación es de 48 Horas y reactivar el caso para continuar el proceso de lo contrario se tendrá que reprocesar nuevamente en plataforma. " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else if (codigo_convenio == "SEB")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Gestionar con el cliente la confirmación de la libranza a través de www.sygnus.co el Plazo máximo para la confirmación es de 48 Horas y reactivar el caso para continuar el proceso de lo contrario se tendrá que reprocesar nuevamente en plataforma. " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else
                    {

                    }
                }
                else if (cmbEstado_Operacion.Text == "Devuelto 3")
                {

                    if (codigo_convenio == "RFM")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Se realiza devolución ya que al ingresar a la plataforma Sygnus esta indica que el afiliado debe actualizar sus datos personales. Realizar proceso de actualización con el cliente y reactivar operación. " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else if (codigo_convenio == "CAS")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Gestionar con el pensionado la confirmación y/o aceptación de libranza digital a través de casur.dibanka.co y reactivar caso para continuar proceso " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else if (codigo_convenio == "MUM")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Se realiza devolución ya que al ingresar a la plataforma Sygnus esta indica que el afiliado debe actualizar sus datos personales. Realizar proceso de actualización con el cliente y reactivar operación. " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else if (codigo_convenio == "SEB")
                    {
                        TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Se realiza devolución ya que al ingresar a la plataforma Sygnus esta indica que el afiliado debe actualizar sus datos personales. Realizar proceso de actualización con el cliente y reactivar operación. " + extrae_codfuncionario;
                        dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                    }
                }

                else if (cmbEstado_Operacion.Text == "Devuelto")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Se realiza devolución por " + extrae_codfuncionario;
                    dtpFecha_Cierre_Etapa.Text = fecha.ToString("dd/MM/yyyy");
                }
            }
            else
            {
               
            }
        }

        private void cmbTipologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado_Operacion.Text == "Suspendido" && cmbTipologia.Text == "924")
            {
                string extrae_codfuncionario;
                extrae_codfuncionario = usuario.Identificacion.Substring(usuario.Identificacion.Length - 3); // extrae los ultimos 3 digitos del textbox 

                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " SEÑOR GESTOR POR FAVOR INDICARLE AL CLIENTE LAS CONDICIONES DE LA APROBACIÓN $" + TxtMonto_Aprobado.Text + " , " + TxtPlazo_Aprobado.Text + " MESES , $ " + TxtValor_Cuota.Text + " , " + cmbDestino.Text+ " PARA QUE DE ACUERDO A ESTAS CONDICIONES, EL CLIENTE REMITA CORREO AUTORIZANDO EL DESCUENTO POR CONCEPTO DE LIBRANZA DE SU NOMINA AL BUZON  juanc.castellar@contraloria.gov.co, DONDE DEBERA INDICAR QUE DE ACUERDO A SU CAPACIDAD DE DESCUENTO Y A LO CONTEMPLADO EN LA LEY 1527 DE 2012, AUTORIZA GRABAR EN SU NOMINA EL DESCUENTO DE SU CUOTA MENSUAL. " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
            }

            if (cmbEstado_Operacion.Text == "Suspendido")
            {
                string extrae_codfuncionario;

                extrae_codfuncionario = usuario.Identificacion.Substring(usuario.Identificacion.Length - 3); // extrae los ultimos 3 digitos del textbox 
                
                if (cmbTipologia.Text == "624")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Paz y salvo en validacion " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                if (cmbTipologia.Text == "900")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " " + cmbDestino.Text + " " + " se envía a VoBo Pagador el " + dtpFecha_Envio.Text + " " + " Con posible fecha de respuesta el " + dtpFecha_Posible_Rta.Text + " " + extrae_codfuncionario + " " + cmbTipologia.Text;
                    TxtEstado_Correo.Text = "Pendiente Enviar";
                }
                else if (cmbTipologia.Text == "901")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Se envia a VoBo Gic planilla en el " + cmbCorte_Envio.Text + " " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "902")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " Se envia planilla para gestión centro de acopio el " + dtpFecha_Envio.Text + " " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "903")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " En espera de respuesta recibida por parte del convenio: fecha estimada del 01 al 05 del mes de  "+ extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "904")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " Convenio en periodo de restricción hasta el " + dtpFecha_Restriccion.Text + " " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "905")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " Se radicará en plataforma el día lunes puesto que de acuerdo al circuito no se puede radicar los días viernes. " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "906")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Centro de acopio informa: " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "906-1")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Crédito se radica en el convenio " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "906-2")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Crédito radicado en el convenio en espera de respuesta " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "906-3")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Crédito radicado en el convenio con posible respuesta " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "906-4")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Pendiente llegada de documentación original para envió al convenio " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "906-5")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio en Restricción " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "906-22")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Crédito radicado en el convenio tiempo de respuesta superado " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "906-23")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Novedad en el convenio " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "907")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio se encuentra en periodo de restriccion desde " + dtpFecha_Envio.Text + " Hasta " + dtpFecha_Restriccion.Text + " " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "909")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " se reporta demora convenio al GIC: en espera de respuesta nuevamente del convenio. " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "910")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " se solicitan documentos al archivo para tramite con el convenio. " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "911")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " área archivo informa que no se han recibido documentos, se solicitaran nuevamente el dia (fecha solicitud documentos archivo). " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "912")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " en espera de llegada de documentación física por parte de la oficina para proceder con el tramite VoBo (3 días hábiles). " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "913")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " en espera de llegada de copias de cedula al 150% a color  física por parte de la oficina para proceder con el tramite VoBo (3 días hábiles) " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "914")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Operación reportada al area de retoques por novedad evaluacion y sancion " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "915")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Operación con novedad en validacion con el centro de acopio " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "917")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " se reporta operacion al area encargada bajar monto segmentacion " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "918")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Operación con recuperación de descuento se gestionará en la próxima apertura de plataforma " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "919")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " se reporta al area de scoring / cierre operativo para ratificacion de condiciones del credito " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "920")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " se reporta novedad a área encargada. " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "921")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " información de libranza visada en validación. " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "922")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " Destino " + cmbDestino.Text + " solicitud de VoBo enviada a la nómina el día " + dtpFecha_Envio.Text + " tiempo máximo de respuesta superado. " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "923")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Tiempo de respuesta superado gic planilla "  + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "925")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " se reporta novedad en herramienta " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "927")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " pendiente notificacion por cambio de circuito de vobo " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "928")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Se reporta al área de seguros BBVA en espera de respuesta para continuar tramite de visto bueno pagador convenio. " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "930")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Novedad en el convenio, dirección que indica matriz no se ajusta (esto lo indica el funcionario de domesa). " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "931")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " se remite informacion del credito al comercial para tramite de vobo ante el convenio " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "932")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " se reporta operación al gic cambio de condiciones (bajar monto) " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "934")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " operacion validada para gestion de envio al convenio " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
                else if (cmbTipologia.Text == "940")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Novedad reportada al area de calidad " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
            }
            else if (cmbEstado_Operacion.Text == "Gestion Comercial VoBo" && cmbTipologia.Text == "729")
            {
                string extrae_codfuncionario;
                extrae_codfuncionario = usuario.Identificacion.Substring(usuario.Identificacion.Length - 3); // extrae los ultimos 3 digitos del textbox 
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Para la consecución del VoBo se informa Monto " + TxtMonto_Aprobado.Text + " Plazo " + TxtPlazo_Aprobado.Text + " Meses por un valor de cuota de " + TxtValor_Cuota.Text + " Valor total crédito " + TxtTotal_Credito.Text + " Gracias " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }
            }            
            else
            {
                //MessageBox.Show("Antes de seleccionar una tipologia debe indicar en el estado de la operacion Suspendido");
                cmbTipologia.Text = null;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(TxtTotal_Credito.Text, true);
        }

        private void btnMatriz_Click(object sender, EventArgs e)
        {
            Form formulario = new Capa_presentacion.Matriz_Convenios();
            formulario.Show();
        }
        private void btnAbrir_Correos_Click(object sender, EventArgs e)
        {
            Form formulario = new FormEnvio_Correos();
            formulario.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            try
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["IntervaloEjecucion"]);
                timer.Enabled = true;
                this.timer.Tick += new EventHandler(EventoTemporizador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDetenerServicio_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            timer.Stop();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(TxtValor_Cuota.Text,true);
        }

        private void TxtConsecutivo_Validated_1(object sender, EventArgs e)
        {
            string largo = TxtConsecutivo.Text;
            string length = Convert.ToString(largo.Length);

            if (length == "1")
            {
                TxtConsecutivo.Text = "0000" + TxtConsecutivo.Text;
            }
            else if (length == "2")
            {
                TxtConsecutivo.Text = "000" + TxtConsecutivo.Text;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            string cadena = TxtCodigo_Convenio.Text;
            string codigo_convenio = cadena.Substring(0, 3);
            cmds.Datos_matriz(TxtNombre_Conveniomt, TxtRestriccionmt, Txt_Horarios_gestionmt, TxtTipo_vobo, TxtCod_Matriz);
        }

        private void cmbDirigido_Click(object sender, EventArgs e)
        {
            if (TxtCodigo_Convenio.Text!= "")
            {
                Cargar_dirigido();                
            }
            else if (TxtCodigo_Convenio.Text == "")
            {
                MessageBox.Show("Primero debe digitar codigo del convenio correspondiente","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }            
        }

        private void BtnEstado_Operaciones_Click(object sender, EventArgs e)
        {
            Form formulario = new FormEstado_Operaciones();
            formulario.Show();
        }
        private void dtpFecha_Posible_Rta_ValueChanged(object sender, EventArgs e)
        {
            string extrae_codfuncionario;
            extrae_codfuncionario = usuario.Identificacion.Substring(usuario.Identificacion.Length - 3); // extrae los ultimos 3 digitos del textbox 

            if (cmbEstado_Operacion.Text == "Suspendido" && cmbTipologia.Text == "900")
            {                
             TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " " + cmbDestino.Text + " " + " se envía a VoBo Pagador el " + dtpFecha_Envio.Text + " " + " Con posible fecha de respuesta el " + dtpFecha_Posible_Rta.Text + " " + extrae_codfuncionario + " " + cmbTipologia.Text;                
            }
        }

        private void cmbFuerza_Venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbEstado_Operacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbTipologia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbCorte_Envio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtEstado_Correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TtxRespuesta_Correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dtpFecha_Envio_ValueChanged(object sender, EventArgs e)
        {
            string extrae_codfuncionario;
            extrae_codfuncionario = usuario.Identificacion.Substring(usuario.Identificacion.Length - 3); // extrae los ultimos 3 digitos del textbox 

            if (cmbEstado_Operacion.Text == "Suspendido" & cmbTipologia.Text == "900")
                {
                cmds.DiasRta_matriz(TxtCod_Matriz);
                 string d = dtpFecha_Envio.Value.DayOfWeek.ToString();
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(dtpFecha_Envio.Value);
                dt = dt.AddDays(0);
                int dias_rta = Convert.ToInt32(usuario.dias_rta_matriz);

                if (d == "Monday" )
                {
                    if (dias_rta >1 && dias_rta<=4)
                    {
                        dtpFecha_Posible_Rta.Value = dt.AddDays(dias_rta);
                    }
                    else if(dias_rta > 4)
                    {
                        dtpFecha_Posible_Rta.Value = dt.AddDays(dias_rta+2);
                    }
                    else if (dias_rta == 0)
                    {
                        MessageBox.Show("convenio no indica dias tiempo de respuesta");
                    }                                     
                }
                else if (d == "Tuesday")
                {
                    if (dias_rta > 1 && dias_rta <= 3)
                    {
                        dtpFecha_Posible_Rta.Value = dt.AddDays(dias_rta);
                    }
                    else if (dias_rta > 3)
                    {
                        dtpFecha_Posible_Rta.Value = dt.AddDays(dias_rta + 2);
                    }
                    else if (dias_rta == 0)
                    {
                        MessageBox.Show("convenio no indica dias tiempo de respuesta");
                    }
                }
                else if (d == "Wednesday")
                {
                    if (dias_rta > 1 && dias_rta <= 3)
                    {
                        dtpFecha_Posible_Rta.Value = dt.AddDays(dias_rta);
                    }
                    else if (dias_rta > 3)
                    {
                        dtpFecha_Posible_Rta.Value = dt.AddDays(dias_rta + 2);
                    }
                    else if (dias_rta == 0)
                    {
                        MessageBox.Show("convenio no indica dias tiempo de respuesta");
                    }
                }
                else if (d == "Thursday")
                {
                    if (dias_rta > 1 && dias_rta <= 3)
                    {
                        dtpFecha_Posible_Rta.Value = dt.AddDays(dias_rta);
                    }
                    else if (dias_rta > 3)
                    {
                        dtpFecha_Posible_Rta.Value = dt.AddDays(dias_rta + 2);
                    }
                    else if (dias_rta == 0)
                    {
                        MessageBox.Show("convenio no indica dias tiempo de respuesta");
                    }
                }
                else if (d == "Friday")
                {
                    dtpFecha_Posible_Rta.Value = dt.AddDays(dias_rta + 2);
                }                
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Convenio " + TxtCodigo_Convenio.Text + " " + cmbDestino.Text + " " + " se envía a VoBo Pagador el " + dtpFecha_Envio.Text + " " + " Con posible fecha de respuesta el " + dtpFecha_Posible_Rta.Text + " " + extrae_codfuncionario + " " + cmbTipologia.Text;                                  
            }
        }

        private void TxtValor1_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtValor1.Text) > 0)
            {
                TxtValor1.Text = string.Format("{0:#,##0}", double.Parse(TxtValor1.Text));
            }
            else if (TxtValor1.Text == "")
            {
                TxtValor1.Text = Convert.ToString(0);
            }
        }

        private void TxtValor2_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtValor2.Text) > 0)
            {
                TxtValor2.Text = string.Format("{0:#,##0}", double.Parse(TxtValor2.Text));
            }            
        }

        private void TxtValor3_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtValor3.Text) > 0)
            {
                TxtValor3.Text = string.Format("{0:#,##0}", double.Parse(TxtValor3.Text));
            }
        }

        private void TxtValor4_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtValor4.Text) > 0)
            {
                TxtValor4.Text = string.Format("{0:#,##0}", double.Parse(TxtValor4.Text));
            }
        }

        private void TxtValor5_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtValor5.Text) > 0)
            {
                TxtValor5.Text = string.Format("{0:#,##0}", double.Parse(TxtValor5.Text));
            }
        }

        private void TxtValor6_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtValor6.Text) > 0)
            {
                TxtValor6.Text = string.Format("{0:#,##0}", double.Parse(TxtValor6.Text));
            }
        }

        private void TxtValor7_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtValor7.Text) > 0)
            {
                TxtValor7.Text = string.Format("{0:#,##0}", double.Parse(TxtValor7.Text));
            }
        }

        private void TxtValor8_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TxtValor8.Text) > 0)
            {
                TxtValor8.Text = string.Format("{0:#,##0}", double.Parse(TxtValor8.Text));
            }
        }
        
        private void BtnEntidades_Click(object sender, EventArgs e)
        {
            cmds.Entidades(dgvEntidades);
        }

        private void TxtEntidad_TextChanged(object sender, EventArgs e)
        {
            string filterField = "nombre_entidad";
            ((DataTable)dgvEntidades.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, TxtEntidad.Text);
        }

        private void TxtValor_Seguro_Validated(object sender, EventArgs e)
        {
            TxtValor_Seguro.Text = string.Format("{0:#,##0}", double.Parse(TxtValor_Seguro.Text));
        }

        private void cmbDirigido_SelectedValueChanged(object sender, EventArgs e)
        {
            int largo = TxtCodigo_Convenio.Text.Length;

            if (largo > 2)
            {
                string cadena = TxtCodigo_Convenio.Text;
                string codigo_convenio = cadena.Substring(0, 3);

                if (cmbDirigido.Text=="")
                {
                    TxtCod_Matriz.Text = codigo_convenio ;
                }
                else
                {
                    TxtCod_Matriz.Text = codigo_convenio + "-" + cmbDirigido.Text;
                }               
            }
        }

        private void TxtValor_Cuota1_Validated(object sender, EventArgs e)
        {
            TxtValor_Cuota1.Text = string.Format("{0:#,##0}", double.Parse(TxtValor_Cuota1.Text));
        }

        private void cmbCorte_Envio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado_Operacion.Text == "Suspendido")
            {
                string extrae_codfuncionario;

                extrae_codfuncionario = usuario.Identificacion.Substring(usuario.Identificacion.Length - 3); // extrae los ultimos 3 digitos del textbox 

                if (cmbTipologia.Text == "901")
                {
                    TxtComentarios.Text = fecha.ToString("dd/MM/yyyy") + " Se envia a VoBo Gic planilla en el " + cmbCorte_Envio.Text + " " + extrae_codfuncionario + " " + cmbTipologia.Text;
                }               
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFecha_Nacimiento.Text != "2021-01-01")
            {
                DateTime nacimiento = Convert.ToDateTime(dtpFecha_Nacimiento.Text); //Fecha de nacimiento del cliente.
                int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                TxtEdad_Cliente.Text = Convert.ToString(edad);
            }
            else
            {

            }
        }

        private void BtnVer_Antecedentes_Click(object sender, EventArgs e)
        {
            Form formulario = new Reporte_Seguros();
            formulario.Show(); 
        }

        private void cmbFormato_Seguros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato_Seguros.Text== "Enfermedad")
            {
                MessageBox.Show("Validar cuadro de antecedentes y revisar si aplica o no reporte al area de Seguros BBVA");
                cmbReporte_Enfermedad.Text = "";
            }
            else
            {
                cmbReporte_Enfermedad.Text = "No Aplica";
            }

            if (cmbFormato_Seguros.Text== "No Aplica" && cmbReporte_Enfermedad.Text== "No Aplica" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
            else if (cmbFormato_Seguros.Text == "No Aplica" && cmbReporte_Enfermedad.Text == "Reportar" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
        }

        private void TxtPeso_Validated(object sender, EventArgs e)
        {
            string extrae_estatura;
            int sobrepeso;
            string resultado;
            extrae_estatura = TxtEstatura.Text.Substring(TxtEstatura.Text.Length - 2);
            sobrepeso = Convert.ToInt32(TxtPeso.Text) - Convert.ToInt32(extrae_estatura);
            resultado = Convert.ToString(sobrepeso);
            if (sobrepeso >= 21)
            {
                MessageBox.Show("Cliente presenta sobrepeso, total diferencia " + resultado + " Kilos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSobrepeso.Text = "Reportar";
                cmbEstado_Reporte.Text = "Pte Preformalizacion";
            }
            else
            {
                cmbSobrepeso.Text = "No Aplica";
            }
        }

        private void cmbReporte_Enfermedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato_Seguros.Text == "No Aplica" && cmbReporte_Enfermedad.Text == "No Aplica" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
        }

        private void cmbSeguros_Monto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato_Seguros.Text == "No Aplica" && cmbReporte_Enfermedad.Text == "No Aplica" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
        }

        private void cmbSobrepeso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato_Seguros.Text == "No Aplica" && cmbReporte_Enfermedad.Text == "No Aplica" && cmbSeguros_Monto.Text == "No Aplica" && cmbSobrepeso.Text == "No Aplica")
            {
                cmbEstado_Reporte.Text = "No Aplica";
            }
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            Nuevo();            
        }

        private void TxtCod_Militar1_Validated(object sender, EventArgs e)
        {

            string Codigo_Militar = Microsoft.VisualBasic.Interaction.InputBox("Digite nuevamente el Codigo Militar", "Confirmar Codigo Militar", ""); //inputbox de visual basic, se debe referenciar microsoft.visualbasic 
            if (Codigo_Militar == TxtCod_Militar1.Text)
            {
                cmbDestino.Focus();
            }
            else
            {
                MessageBox.Show("Codigo Militar no coincide, por favor diligenciar nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCod_Militar1.Text = "";
                TxtCod_Militar1.Focus();
            }
        }

        private void btnCasos_Cedula_Click(object sender, EventArgs e)
        {
            cmds.Casos_Cedula(TxtCedula_Casos,dgvCasos_Cliente);
        }
        private void cmbGrado_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT Grado FROM grados_militares", con);
            con.Open();
            dr = cmd.ExecuteReader();
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                Collection.Add(dr.GetString(0));
            }
            cmbGrado.AutoCompleteCustomSource = Collection;
            dr.Close();
            con.Close();
        }

        private void cmbFuerza_Venta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFuerza_Venta.Text== "Red Oficina")
            {
                cmbFormato_Seguros.Enabled = false;
                cmbReporte_Enfermedad.Enabled = false;                
                cmbEstado_Reporte.Enabled = false;
                TxtEstatura.Enabled = false;
                TxtPeso.Enabled = false;
                dtpFecha_Nacimiento.Enabled = false;
                TxtEstatura.Text = "0";
                TxtPeso.Text = "0";
                TxtEdad_Cliente.Text = "0";

            }
            else if(cmbFuerza_Venta.Text == "Gestor Movil" || cmbFuerza_Venta.Text == "Gestor Remoto")
            {   
                cmbFormato_Seguros.Enabled = true;
                cmbReporte_Enfermedad.Enabled = true;                
                cmbEstado_Reporte.Enabled = true;
                TxtEstatura.Enabled = true;
                TxtPeso.Enabled = true;
                dtpFecha_Nacimiento.Enabled = true;
            }
            else 
            {
                cmbFormato_Seguros.Enabled = false;
                cmbReporte_Enfermedad.Enabled = false;                
                cmbEstado_Reporte.Enabled = false;
                TxtEstatura.Enabled = false;
                TxtPeso.Enabled = false;
                dtpFecha_Nacimiento.Enabled = false;
            }
        }
    }
}
