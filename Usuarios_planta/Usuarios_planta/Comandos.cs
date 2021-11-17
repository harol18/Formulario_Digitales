using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using MySql.Data.MySqlClient;


namespace Usuarios_planta
{
    class Comandos
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");

        public void Accesso_Aplicacion()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("control_acceso_aplicaciones", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Usuario", usuario.Nombre);
                cmd.Parameters.AddWithValue("@_Aplicacion", "Digitales");
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void Limpiar_Tabla_Inactivaciones()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("limpiar_tabla_inactivaciones", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        public void Limpiar_Tabla_Descuentos()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("limpiar_tabla_descuentos", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void Guardar_vobo(TextBox TxtRadicado, TextBox TxtCedula_Cliente, TextBox TxtNombre_Cliente, DateTimePicker dtpFecha_Nacimiento, TextBox TxtEdad_Cliente, TextBox TxtEstatura, TextBox TxtPeso,
                                 TextBox TxtScoring, ComboBox cmbFuerza_Venta, TextBox TxtCodigo_Convenio, ComboBox cmbDirigido, TextBox TxtCod_Matriz, TextBox TxtConsecutivo,
                                 ComboBox cmbGrado, TextBox TxtCod_Militar1, ComboBox cmbDestino, TextBox TxtSubproducto, TextBox TxtTasa_E_A,
                                 TextBox TxtTasa_N_M, TextBox TxtMonto_Aprobado, TextBox TxtPlazo_Aprobado, TextBox TxtValor_Cuota, TextBox TxtTotal_Credito,
                                 TextBox TxtMonto_Letras, TextBox TxtTotal_Letras, TextBox TxtCartera1, TextBox TxtCartera2, TextBox TxtCartera3, TextBox TxtCartera4,
                                 TextBox TxtCartera5, TextBox TxtCartera6, TextBox TxtCartera7, TextBox TxtCartera8, TextBox TxtObligacion1, TextBox TxtObligacion2,
                                 TextBox TxtObligacion3, TextBox TxtObligacion4, TextBox TxtObligacion5, TextBox TxtObligacion6, TextBox TxtObligacion7, TextBox TxtObligacion8,
                                 TextBox TxtValor1, TextBox TxtValor2, TextBox TxtValor3, TextBox TxtValor4, TextBox TxtValor5, TextBox TxtValor6, TextBox TxtValor7,
                                 TextBox TxtValor8, TextBox TxtValor_Seguro, TextBox TxtGestor, TextBox TxtCoordinador, TextBox TxtOficina, ComboBox cmbFormato_Seguros,
                                 ComboBox cmbReporte_Enfermedad, ComboBox cmbSeguros_Monto, ComboBox cmbSobrepeso, ComboBox cmbEstado_Reporte, DateTimePicker dtpFecha_Envio,
                                 ComboBox cmbCorte_Envio, DateTimePicker dtpHora_Envio, DateTimePicker dtpFecha_Posible_Rta, DateTimePicker dtpFecha_Restriccion,
                                 ComboBox cmbEstado_Operacion, ComboBox cmbTipologia, ComboBox TxtEstado_Correo, ComboBox TtxRespuesta_Correo, DateTimePicker dtpFecha_Cierre_Etapa, TextBox TxtComentarios, TextBox TxtObservaciones)

        {
            con.Open(); 
            MySqlCommand cmd = new MySqlCommand("guardar_vobo", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {
                dtpFecha_Envio.Format = DateTimePickerFormat.Custom;
                dtpFecha_Envio.CustomFormat = "yyyy-MM-dd";
                dtpFecha_Posible_Rta.Format = DateTimePickerFormat.Custom;                
                dtpFecha_Posible_Rta.CustomFormat = "yyyy-MM-dd";
                dtpFecha_Restriccion.Format = DateTimePickerFormat.Custom;
                dtpFecha_Restriccion.CustomFormat = "yyyy-MM-dd";
                dtpFecha_Cierre_Etapa.Format = DateTimePickerFormat.Custom;
                dtpFecha_Cierre_Etapa.CustomFormat = "yyyy-MM-dd";                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", TxtRadicado.Text);
                cmd.Parameters.AddWithValue("@_Cedula_Cliente", TxtCedula_Cliente.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Cliente", TxtNombre_Cliente.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Nacimiento_Cliente", dtpFecha_Nacimiento.Text);
                cmd.Parameters.AddWithValue("@_Edad_Cliente", TxtEdad_Cliente.Text);
                cmd.Parameters.AddWithValue("@_Estatura", TxtEstatura.Text);
                cmd.Parameters.AddWithValue("@_Peso", TxtPeso.Text);
                cmd.Parameters.AddWithValue("@_Scoring", TxtScoring.Text);
                cmd.Parameters.AddWithValue("@_Fuerza_Venta", cmbFuerza_Venta.Text);
                cmd.Parameters.AddWithValue("@_Codigo_Convenio", TxtCodigo_Convenio.Text);
                cmd.Parameters.AddWithValue("@_Dirigido", cmbDirigido.Text);
                cmd.Parameters.AddWithValue("@_Cod_Matriz", TxtCod_Matriz.Text);
                cmd.Parameters.AddWithValue("@_Consecutivo", TxtConsecutivo.Text);               
                cmd.Parameters.AddWithValue("@_Grado", cmbGrado.Text);
                cmd.Parameters.AddWithValue("@_Cod_Militar1", TxtCod_Militar1.Text);                              
                cmd.Parameters.AddWithValue("@_Destino", cmbDestino.Text);
                cmd.Parameters.AddWithValue("@_Subproducto", TxtSubproducto.Text);
                cmd.Parameters.AddWithValue("@_Tasa_E_A", TxtTasa_E_A.Text);
                cmd.Parameters.AddWithValue("@_Tasa_N_M", TxtTasa_N_M.Text);
                cmd.Parameters.AddWithValue("@_Monto_Aprobado", string.Format("{0:#}", double.Parse(TxtMonto_Aprobado.Text)));
                cmd.Parameters.AddWithValue("@_Plazo_Aprobado", TxtPlazo_Aprobado.Text);
                cmd.Parameters.AddWithValue("@_Valor_Cuota", string.Format("{0:#}", double.Parse(TxtValor_Cuota.Text)));
                cmd.Parameters.AddWithValue("@_Total_Credito", string.Format("{0:#}", double.Parse(TxtTotal_Credito.Text)));
                cmd.Parameters.AddWithValue("@_Monto_Letras", TxtMonto_Letras.Text);
                cmd.Parameters.AddWithValue("@_Total_Letras", TxtTotal_Letras.Text);
                cmd.Parameters.AddWithValue("@_Cartera1", TxtCartera1.Text);
                cmd.Parameters.AddWithValue("@_Cartera2", TxtCartera2.Text);
                cmd.Parameters.AddWithValue("@_Cartera3", TxtCartera3.Text);
                cmd.Parameters.AddWithValue("@_Cartera4", TxtCartera4.Text);
                cmd.Parameters.AddWithValue("@_Cartera5", TxtCartera5.Text);
                cmd.Parameters.AddWithValue("@_Cartera6", TxtCartera6.Text);
                cmd.Parameters.AddWithValue("@_Cartera7", TxtCartera7.Text);
                cmd.Parameters.AddWithValue("@_Cartera8", TxtCartera8.Text);
                cmd.Parameters.AddWithValue("@_obligacion1", TxtObligacion1.Text);
                cmd.Parameters.AddWithValue("@_obligacion2", TxtObligacion2.Text);
                cmd.Parameters.AddWithValue("@_obligacion3", TxtObligacion3.Text);
                cmd.Parameters.AddWithValue("@_obligacion4", TxtObligacion4.Text);
                cmd.Parameters.AddWithValue("@_obligacion5", TxtObligacion5.Text);
                cmd.Parameters.AddWithValue("@_obligacion6", TxtObligacion6.Text);
                cmd.Parameters.AddWithValue("@_obligacion7", TxtObligacion7.Text);
                cmd.Parameters.AddWithValue("@_obligacion8", TxtObligacion8.Text);
                cmd.Parameters.AddWithValue("@_valor1", TxtValor1.Text);
                cmd.Parameters.AddWithValue("@_valor2", TxtValor2.Text);
                cmd.Parameters.AddWithValue("@_valor3", TxtValor3.Text);
                cmd.Parameters.AddWithValue("@_valor4", TxtValor4.Text);
                cmd.Parameters.AddWithValue("@_valor5", TxtValor5.Text);
                cmd.Parameters.AddWithValue("@_valor6", TxtValor6.Text);
                cmd.Parameters.AddWithValue("@_valor7", TxtValor7.Text);
                cmd.Parameters.AddWithValue("@_valor8", TxtValor8.Text);
                cmd.Parameters.AddWithValue("@_valor_seguro", TxtValor_Seguro.Text);
                cmd.Parameters.AddWithValue("@_nombre_gestor", TxtGestor.Text);
                cmd.Parameters.AddWithValue("@_nombre_coordinador", TxtCoordinador.Text);
                cmd.Parameters.AddWithValue("@_oficina", TxtOficina.Text);
                cmd.Parameters.AddWithValue("@_Formato_Seguros", cmbFormato_Seguros.Text);
                cmd.Parameters.AddWithValue("@_Enfermedad", cmbReporte_Enfermedad.Text);
                cmd.Parameters.AddWithValue("@_Reporte_Monto", cmbSeguros_Monto.Text);
                cmd.Parameters.AddWithValue("@_Reporte_Sobrepeso", cmbSobrepeso.Text);
                cmd.Parameters.AddWithValue("@_Preformalizacion_Seguros", cmbEstado_Reporte.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Envio", dtpFecha_Envio.Text);
                cmd.Parameters.AddWithValue("@_Corte_Envio", cmbCorte_Envio.Text);
                cmd.Parameters.AddWithValue("@_Hora_Envio", dtpHora_Envio.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Posible_Rta", dtpFecha_Posible_Rta.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Restriccion", dtpFecha_Restriccion.Text);
                cmd.Parameters.AddWithValue("@_Estado_Operacion", cmbEstado_Operacion.Text);
                cmd.Parameters.AddWithValue("@_Tipologia", cmbTipologia.Text);
                cmd.Parameters.AddWithValue("@_Estado_Correo", TxtEstado_Correo.Text);
                cmd.Parameters.AddWithValue("@_Respuesta_Correo", TtxRespuesta_Correo.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Cierre_Etapa", dtpFecha_Cierre_Etapa.Text);
                cmd.Parameters.AddWithValue("@_Comentarios", TxtComentarios.Text);
                cmd.Parameters.AddWithValue("@_Observaciones", TxtObservaciones.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Almacenada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                
                dtpFecha_Envio.CustomFormat = "dd/MM/yyyy";
                dtpFecha_Posible_Rta.CustomFormat = "dd/MM/yyyy";
                dtpFecha_Restriccion.CustomFormat = "dd/MM/yyyy";
                dtpFecha_Cierre_Etapa.CustomFormat = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                myTrans.Rollback();                
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void Buscar_vobo(TextBox TxtRadicado, TextBox TxtCedula_Cliente, TextBox TxtNombre_Cliente, DateTimePicker dtpFecha_Nacimiento,TextBox TxtEdad_Cliente,TextBox TxtEstatura , TextBox TxtPeso, TextBox TxtScoring,
                                ComboBox cmbFuerza_Venta, TextBox TxtCodigo_Convenio, ComboBox cmbDirigido, TextBox TxtCod_Matriz, TextBox TxtConsecutivo, ComboBox cmbGrado, TextBox TxtCod_Militar1,
                                ComboBox cmbDestino, TextBox TxtSubproducto, TextBox TxtTasa_E_A, TextBox TxtTasa_N_M, TextBox TxtMonto_Aprobado, TextBox TxtPlazo_Aprobado,
                                TextBox TxtValor_Cuota,TextBox TxtValor_Cuota1, TextBox TxtTotal_Credito,TextBox TxtMonto_Letras, TextBox TxtTotal_Letras, TextBox TxtCartera1, TextBox TxtCartera2, 
                                TextBox TxtCartera3, TextBox TxtCartera4, TextBox TxtCartera5, TextBox TxtCartera6,TextBox TxtCartera7, TextBox TxtCartera8, TextBox TxtObligacion1, 
                                TextBox TxtObligacion2, TextBox TxtObligacion3, TextBox TxtObligacion4, TextBox TxtObligacion5, TextBox TxtObligacion6,TextBox TxtObligacion7, TextBox TxtObligacion8, 
                                TextBox TxtValor1, TextBox TxtValor2, TextBox TxtValor3, TextBox TxtValor4, TextBox TxtValor5, TextBox TxtValor6, TextBox TxtValor7,TextBox TxtValor8, 
                                TextBox TxtValor_Seguro, TextBox TxtGestor, TextBox TxtCoordinador, TextBox TxtOficina, ComboBox cmbFormato_Seguros,ComboBox cmbReporte_Enfermedad,ComboBox cmbSeguros_Monto,
                                ComboBox cmbSobrepeso, ComboBox cmbEstado_Reporte,DateTimePicker dtpFecha_Envio, ComboBox cmbCorte_Envio, DateTimePicker dtpHora_Envio, 
                                DateTimePicker dtpFecha_Posible_Rta, DateTimePicker dtpFecha_Restriccion, ComboBox cmbEstado_Operacion, ComboBox cmbTipologia, ComboBox TxtEstado_Correo,
                                ComboBox TtxRespuesta_Correo, DateTimePicker dtpFecha_Cierre_Etapa, TextBox TxtComentarios, TextBox TxtObservaciones)
        {          
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("buscar_vobo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Radicado", TxtRadicado.Text);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    TxtCedula_Cliente.Text = registro["Cedula_Cliente"].ToString();
                    TxtNombre_Cliente.Text = registro["Nombre_Cliente"].ToString();
                    dtpFecha_Nacimiento.Text = registro["Fecha_Nacimiento_Cliente"].ToString();
                    TxtEdad_Cliente.Text = registro["Edad_Cliente"].ToString();
                    TxtEstatura.Text = registro["Estatura"].ToString();
                    TxtPeso.Text = registro["Peso"].ToString();
                    TxtScoring.Text = registro["Scoring"].ToString();
                    cmbFuerza_Venta.Text = registro["Fuerza_Venta"].ToString();
                    TxtCodigo_Convenio.Text = registro["Codigo_Convenio"].ToString();
                    cmbDirigido.Text = registro["Dirigido"].ToString();
                    TxtCod_Matriz.Text = registro["Cod_Matriz"].ToString();
                    TxtConsecutivo.Text = registro["Consecutivo"].ToString();
                    cmbGrado.Text = registro["Grado"].ToString();
                    TxtCod_Militar1.Text = registro["Cod_Militar1"].ToString();                    
                    cmbDestino.Text = registro["Destino"].ToString();
                    TxtSubproducto.Text = registro["Subproducto"].ToString();
                    TxtTasa_E_A.Text = registro["Tasa_E_A"].ToString();
                    TxtTasa_N_M.Text = registro["Tasa_N_M"].ToString();
                    TxtMonto_Aprobado.Text = registro["Monto_Aprobado"].ToString();
                    TxtPlazo_Aprobado.Text = registro["Plazo_Aprobado"].ToString();
                    TxtValor_Cuota.Text = registro["Valor_Cuota"].ToString();
                    TxtValor_Cuota1.Text = registro["Valor_Cuota"].ToString();
                    TxtTotal_Credito.Text = registro["Total_Credito"].ToString();
                    TxtMonto_Letras.Text = registro["Monto_Letras"].ToString();
                    TxtTotal_Letras.Text = registro["Total_Letras"].ToString();
                    TxtCartera1.Text = registro["Cartera1"].ToString();
                    TxtCartera2.Text = registro["Cartera2"].ToString();
                    TxtCartera3.Text = registro["Cartera3"].ToString();
                    TxtCartera4.Text = registro["Cartera4"].ToString();
                    TxtCartera5.Text = registro["Cartera5"].ToString();
                    TxtCartera6.Text = registro["Cartera6"].ToString();
                    TxtCartera7.Text = registro["Cartera7"].ToString();
                    TxtCartera8.Text = registro["Cartera8"].ToString();
                    TxtObligacion1.Text = registro["obligacion1"].ToString();
                    TxtObligacion2.Text = registro["obligacion2"].ToString();
                    TxtObligacion3.Text = registro["obligacion3"].ToString();
                    TxtObligacion4.Text = registro["obligacion4"].ToString();
                    TxtObligacion5.Text = registro["obligacion5"].ToString();
                    TxtObligacion6.Text = registro["obligacion6"].ToString();
                    TxtObligacion7.Text = registro["obligacion7"].ToString();
                    TxtObligacion8.Text = registro["obligacion8"].ToString();
                    TxtValor1.Text = registro["valor1"].ToString();
                    TxtValor2.Text = registro["valor2"].ToString();
                    TxtValor3.Text = registro["valor3"].ToString();
                    TxtValor4.Text = registro["valor4"].ToString();
                    TxtValor5.Text = registro["valor5"].ToString();
                    TxtValor6.Text = registro["valor6"].ToString();
                    TxtValor7.Text = registro["valor7"].ToString();
                    TxtValor8.Text = registro["valor8"].ToString();
                    TxtValor_Seguro.Text = registro["valor_seguro"].ToString();
                    TxtGestor.Text = registro["nombre_gestor"].ToString();
                    TxtCoordinador.Text = registro["nombre_coordinador"].ToString();
                    TxtOficina.Text = registro["oficina"].ToString();
                    cmbFormato_Seguros.Text = registro["Formato_Seguros"].ToString();
                    cmbReporte_Enfermedad.Text = registro["Enfermedad"].ToString();
                    cmbSeguros_Monto.Text = registro["Reporte_Monto"].ToString();
                    cmbSobrepeso.Text = registro["Reporte_Sobrepeso"].ToString();
                    cmbEstado_Reporte.Text = registro["Preformalizacion_Seguros"].ToString();
                    dtpFecha_Envio.Text = registro["Fecha_Envio"].ToString();
                    cmbCorte_Envio.Text = registro["Corte_Envio"].ToString();
                    dtpHora_Envio.Text = registro["Hora_Envio"].ToString();
                    dtpFecha_Posible_Rta.Text = registro["Fecha_Posible_Rta"].ToString();
                    dtpFecha_Restriccion.Text = registro["Fecha_Restriccion"].ToString();
                    cmbEstado_Operacion.Text = registro["Estado_Operacion"].ToString();
                    cmbTipologia.Text = registro["Tipologia"].ToString();
                    TxtEstado_Correo.Text = registro["Estado_Correo"].ToString();
                    TtxRespuesta_Correo.Text = registro["Respuesta_Correo"].ToString();
                    dtpFecha_Cierre_Etapa.Text = registro["Fecha_Cierre_Etapa"].ToString();
                    TxtComentarios.Text = registro["Comentarios"].ToString();
                    TxtObservaciones.Text = registro["Observaciones"].ToString();
                    con.Close();
                }else
                {
                    MessageBox.Show("Caso no existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                    
                    TxtCedula_Cliente.Text = null;
                    TxtNombre_Cliente.Text = null;
                    TxtScoring.Text = null;
                    cmbFuerza_Venta.Text = null;
                    TxtCodigo_Convenio.Text = null;
                    cmbDirigido.Text = null;
                    TxtConsecutivo.Text = null;
                    cmbGrado.Text = null;
                    TxtCod_Militar1.Text = null;                    
                    cmbDestino.Text = null;
                    TxtSubproducto.Text = null;
                    TxtTasa_E_A.Text = null;
                    TxtTasa_N_M.Text = null;
                    TxtMonto_Aprobado.Text = null;
                    TxtPlazo_Aprobado.Text = null;
                    TxtValor_Cuota.Text = null;
                    TxtTotal_Credito.Text = null;
                    TxtMonto_Letras.Text = null;
                    TxtTotal_Letras.Text = null;
                    TxtCartera1.Text = null;
                    TxtCartera2.Text = null;
                    TxtCartera3.Text = null;
                    TxtCartera4.Text = null;
                    dtpFecha_Envio.Text = null;
                    cmbCorte_Envio.Text = null;
                    dtpHora_Envio.Text = "01/01/2020"; 
                    dtpFecha_Posible_Rta.Text = "01/01/2020";
                    dtpFecha_Restriccion.Text = "01/01/2020";
                    cmbEstado_Operacion.Text = null;
                    cmbTipologia.Text = null;
                    TxtEstado_Correo.Text = null;
                    TtxRespuesta_Correo.Text = null;
                    dtpFecha_Cierre_Etapa.Text = "01/01/2020";
                    TxtComentarios.Text = null;
                }
                con.Close();
            }
            catch (Exception ex)
            {                  
                MessageBox.Show("Caso no existe", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Buscar_matriz( TextBox TxtNombre_Convenio,TextBox TtxRestriccion , TextBox TxtDocumentos_Requeridos, 
                                   TextBox TxtHorarios_Gestion, TextBox TxtCondiciones_Especiales, TextBox TxtPaz_Salvo, 
                                   TextBox TxtContacto_Convenio, TextBox TxtContacto_Gic, TextBox TxtFecha_Actualizacion_Matriz)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Buscar_matriz", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Codigo_Convenio", usuario.Codigo_matriz2);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    TxtNombre_Convenio.Text = registro["Nombre_Convenio"].ToString();                    
                    TtxRestriccion.Text = registro["Restriccion"].ToString();
                    TxtDocumentos_Requeridos.Text = registro["Documentacion"].ToString();                   
                    TxtHorarios_Gestion.Text = registro["Horarios_Gestion"].ToString();
                    TxtCondiciones_Especiales.Text = registro["Condiciones_Especiales"].ToString();
                    TxtPaz_Salvo.Text = registro["Paz_Salvo"].ToString();
                    TxtContacto_Convenio.Text = registro["Correo_Convenio"].ToString();
                    TxtContacto_Gic.Text = registro["Correo_GicVb"].ToString();
                    TxtFecha_Actualizacion_Matriz.Text = registro["Fecha_Actualizacion_Matriz"].ToString();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Consecutivo no existe en la base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TxtNombre_Convenio.Text = null;
                    TtxRestriccion.Text = null;
                    TxtDocumentos_Requeridos.Text = null;
                    TxtHorarios_Gestion.Text = null;
                    TxtCondiciones_Especiales.Text = null;
                    TxtPaz_Salvo.Text = null;
                    TxtContacto_Convenio.Text = null;
                    TxtContacto_Gic.Text = null;
                    TxtFecha_Actualizacion_Matriz.Text = null;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Consecutivo no existe", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Enviar_correos(DateTimePicker dtpfecha, TextBox Txtcod_convenio, DateTimePicker dtpHora_Envio, DataGridView dgvDatos)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("enviar_correo2", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@_Fecha_Envio", dtpfecha.Text);
                cmd.Parameters.AddWithValue("@_Cod_Matriz", Txtcod_convenio.Text);
                cmd.Parameters.AddWithValue("@_Hora_Envio", dtpHora_Envio.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
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

        public void Copia_correos(TextBox TtxCopia_correo)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand("SELECT Correos FROM copias_correo_vb", con);                
                con.Open();
                MySqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    TtxCopia_correo.Text = registro["Correos"].ToString();                    
                    con.Close();
                }
                else
                {
                    con.Close();                    
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Pendiente_correo2(Label lblfecha, Label lbltotal)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("total_pendientes_correo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_Envio", lblfecha.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    lbltotal.Text = registro[0].ToString();                    
                    con.Close();
                }
                else
                {
                    MessageBox.Show("No hay datos para enviar el dia de hoy", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Consecutivo no existe", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Estado_Operaciones(DataGridView dgvDatos, ComboBox cmbEstado_Operacion)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("estado_operaciones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Estado_Operacion", cmbEstado_Operacion.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
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

        public void Pendiente_correo3(Label lblfecha, Label lblanterior)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("total_pendientes_correo1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_Envio", lblfecha.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    lblanterior.Text = registro[0].ToString();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("No hay datos para enviar el dia de hoy", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Consecutivo no existe", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Pendiente_correo4(DataGridView dgvCorreos_Pendientes, Label lblfecha)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("pendiente_correo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_Envio", lblfecha.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvCorreos_Pendientes.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Pendiente_correo(DataGridView dgvCorreos_Pendientes,DateTimePicker dtpfecha)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("pendiente_correo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_Envio", dtpfecha.Text);
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvCorreos_Pendientes.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Actualiza_Matriz(DataGridView dgvDatos_Matriz,TextBox TxtCod_Matriz)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("actualizar_matriz", con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataGridViewRow row in dgvDatos_Matriz.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@_Codigo_Convenio", TxtCod_Matriz.Text);
                    cmd.Parameters.AddWithValue("@_Restriccion", Convert.ToString(row.Cells["Restriccion"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Documentacion", Convert.ToString(row.Cells["Documentacion"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Correo_Convenio", Convert.ToString(row.Cells["Correo_Convenio"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Correo_GicVb", Convert.ToString(row.Cells["Correo_GicVb"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Horarios_Gestion", Convert.ToString(row.Cells["Horarios_Gestion"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Dias_Rta", Convert.ToString(row.Cells["Dias_Rta"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Condiciones_Especiales", Convert.ToString(row.Cells["Condiciones_Especiales"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Paz_Salvo", Convert.ToString(row.Cells["Paz_Salvo"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Tipo_Asunto", Convert.ToString(row.Cells["Tipo_Asunto"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Asunto", Convert.ToString(row.Cells["Asunto"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Tipo_vobo", Convert.ToString(row.Cells["Tipo_vobo"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Destinos", Convert.ToString(row.Cells["Destinos"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Nit", Convert.ToString(row.Cells["Nit"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Vencimiento_VoBo", Convert.ToString(row.Cells["Vencimiento_VoBo"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Tipo_Planilla", Convert.ToString(row.Cells["Tipo_Planilla"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Fecha_Actualizacion_Matriz", Convert.ToString(row.Cells["Fecha_Actualizacion_Matriz"].Value.ToString()));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Información Actualizada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dgvDatos_Matriz.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ActualizaBD_Envio(DataGridView dgvDatos)
        {            
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("actualizarbd_envio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@_Radicado", Convert.ToString(row.Cells["CASO"].Value.ToString()));
                    cmd.Parameters.AddWithValue("@_Estado_Correo", "Enviado");
                    cmd.Parameters.AddWithValue("@_Respuesta_Correo", "Pendiente Respuesta");                    
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Información Actualizada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dgvDatos.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTime fecha = DateTime.Now;

        public void Pendientes_envio_cerrar()
        {            
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("total_pendientes_correo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Fecha_Envio", fecha.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
                MySqlDataReader registro;
                registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    if (Convert.ToInt32(registro[0].ToString()) > 0)                    
                    MessageBox.Show("Por favor revisar, se evidencian operaciones que no se han remitido el dia de hoy", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        Application.Exit();
                    }
                    con.Close();
                }
                else
                {
                   
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada");
            }
        }
        public void Casos_Cedula(TextBox TxtCedula_Casos, DataGridView dgvCasos_Cliente)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("buscar_casos_cedula", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Cedula_Cliente", TxtCedula_Casos.Text);                
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvCasos_Cliente.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Datos_matriz_Total(TextBox TxtCod_Matriz, DataGridView dgvDatos_Matriz)
        {
             try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("buscar_datos_matriz", con);
                cmd.CommandType = CommandType.StoredProcedure;       
                cmd.Parameters.AddWithValue("@_Cod_Matriz", TxtCod_Matriz.Text);                
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvDatos_Matriz.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Datos_matriz(TextBox TxtNombre_Conveniomt,TextBox TxtRestriccionmt, TextBox Txt_Horarios_gestionmt, TextBox TxtTipo_vobo, TextBox TxtCod_Matriz)
        {
            MySqlCommand comando = new MySqlCommand("SELECT Nombre_Convenio,Restriccion,Horarios_Gestion,Tipo_vobo FROM matriz_convenios WHERE Codigo_Convenio = @Codigo_Convenio ", con);
            comando.Parameters.AddWithValue("@Codigo_Convenio", TxtCod_Matriz.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                TxtNombre_Conveniomt.Text = registro["Nombre_Convenio"].ToString();
                TxtRestriccionmt.Text = registro["Restriccion"].ToString();
                Txt_Horarios_gestionmt.Text = registro["Horarios_Gestion"].ToString();
                TxtTipo_vobo.Text = registro["Tipo_vobo"].ToString();
                con.Close();
            }
            else
            {
                con.Close();
                TxtNombre_Conveniomt.Text = null;
                TxtRestriccionmt.Text = null;
                Txt_Horarios_gestionmt.Text = null;
                MessageBox.Show("Consecutivo no se encuentra en la matriz, por favor reportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void DiasRta_matriz(TextBox TxtCod_Matriz)
        {
            MySqlCommand comando = new MySqlCommand("SELECT Dias_Rta FROM matriz_convenios WHERE Codigo_Convenio = @Codigo_Convenio ", con);
            comando.Parameters.AddWithValue("@Codigo_Convenio", TxtCod_Matriz.Text);
            con.Open();
            MySqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                usuario.dias_rta_matriz = registro["Dias_Rta"].ToString();                
                con.Close();
            }
            else
            {
                con.Close();                
            }
        }
        public void Actualizar_Contraseña(TextBox Txtusuario, TextBox Txtcontraseña)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("actualizar_contraseña", con);
            MySqlTransaction myTrans; // Iniciar una transacción local 
            myTrans = con.BeginTransaction(); // Debe asignar tanto el objeto de transacción como la conexión // al objeto de Comando para una transacción local pendiente
            try
            {                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Identificacion", Txtusuario.Text);
                cmd.Parameters.AddWithValue("@_Contraseña", Txtcontraseña.Text);
                cmd.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Información Almacenada con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void Reporteria1(DataGridView dgvDatos, TextBox Txtcod_convenio,ComboBox cmbEstado_Operacion, ComboBox cmbDestino,DateTimePicker dtpFecha_Inicio,DateTimePicker dtpFecha_Final)
        {
            try
            {
                dtpFecha_Inicio.Format = DateTimePickerFormat.Custom;
                dtpFecha_Inicio.CustomFormat = "yyyy-MM-dd";
                dtpFecha_Final.Format = DateTimePickerFormat.Custom;
                dtpFecha_Final.CustomFormat = "yyyy-MM-dd";
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("Reporteria1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_Cod_Matriz", Txtcod_convenio.Text);
                cmd.Parameters.AddWithValue("@_Estado_Operacion", cmbEstado_Operacion.Text);
                cmd.Parameters.AddWithValue("@_Destino", cmbDestino.Text);
                cmd.Parameters.AddWithValue("@_fecha_inicio", dtpFecha_Inicio.Text);
                cmd.Parameters.AddWithValue("@_fecha_final", dtpFecha_Final.Text);
                cmd.Parameters.AddWithValue("@_Fecha_Envio", fecha.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@_Nombre_Funcionario", usuario.Nombre);
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvDatos.DataSource = dt;
                con.Close();
                dtpFecha_Inicio.CustomFormat = "dd/MM/yyyy";
                dtpFecha_Inicio.CustomFormat = "dd/MM/yyyy";
                dtpFecha_Final.CustomFormat = "dd/MM/yyyy";
                dtpFecha_Final.CustomFormat = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Entidades(DataGridView dgvEntidades)
        {
            try
            {                
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("cargar_entidades", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvEntidades.DataSource = dt;
                con.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("", ex.ToString());
                con.Close();
                MessageBox.Show("Conexion cerrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Antecedentes_Reportes_Seguros(DataGridView dgvDatos_Seguros)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("antecedentes_reportes_seguros", con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter registro = new MySqlDataAdapter(cmd);
                registro.Fill(dt);
                dgvDatos_Seguros.DataSource = dt;
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

