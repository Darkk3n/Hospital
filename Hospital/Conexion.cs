using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Hospital
{
    public class Conexion
    {
        public void GrabarDatos(string pSQL)
        {
            MySqlConnection oConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString.ToString());
            MySqlCommand oCmd = new MySqlCommand(pSQL, oConn);
            try
            {
                oConn.Open();
                oCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la información: " + ex.Message.ToString(), "Hospital", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                oCmd.Dispose();
                oConn.Dispose();
                oConn.Close();
            }
        }

        public DataTable ObtenerDatos(string strSQL)
        {
            MySqlConnection oConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString.ToString());
            MySqlCommand oCmd = new MySqlCommand(strSQL, oConn);
            DataTable dt = new DataTable();
            MySqlDataAdapter oDatos = new MySqlDataAdapter(oCmd);

            try
            {
                oDatos.Fill(dt);
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("No es posible conectar con el servidor", "Hospital", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1042:
                        MessageBox.Show("Usuario/Password incorrectos. Intente de nuevo", "Hospital", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
            finally
            {
                oConn.Dispose();
                oCmd.Dispose();
                oDatos.Dispose();
            }
            return dt;
        }
    }
}