using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Usuarios_planta
{
    class Fopep
    {
        MySqlConnection con = new MySqlConnection("server=;Uid=;password=;database=;port=3306;persistsecurityinfo=True;");
        public void Ver_Cruce_Cancelados()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("cruce_contabilizados_fopep", con);
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

        public void Resultado_Cruce_Fopep()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("resultado_cruce_fopep", con);
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

        public void Limpiar_Tablas()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("limpiar_tablas", con);
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

        public void Limpiar_Tabla_resultado_cruce_fopep()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("limpiar_tabla_resultado_cruce_fopep", con);
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
    }
}
