using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Hospital
{
    public partial class Tratamientos : System.Web.UI.Page
    {
        Conexion conex = new Conexion();
        DataTable dt;
        string strSQL;
        public int codTrat;
        int codResult;
        protected void Page_Load(object sender, EventArgs e)
        {
          //  lblPaciente.Text = "Paciente: " + Session["Asegurado"].ToString();
        }

        protected void btnGuardTrat_Click(object sender, EventArgs e)
        {
            codTrat=MaxTrat();
            strSQL = "insert into tratamientos values (" + codTrat + ", '" + txtTrat.Text + "', null)";
            conex.GrabarDatos(strSQL);
            strSQL = "update hospitalizaciones set cod_tratam=" + codTrat + " where Cod_Asegur= " + Session["CodAseg"].ToString() + "";
            conex.GrabarDatos(strSQL);
        }

        protected void btnGuardResult_Click(object sender, EventArgs e)
        {
            codTrat=ObtenMaxTrat();
            strSQL = "select max(Cod_Result) from resultados";
            dt = conex.ObtenerDatos(strSQL);
            if (dt.Rows[0].ItemArray[0].ToString() == "")
                codResult = 1;
            else
                codResult = int.Parse(dt.Rows[0].ItemArray[0].ToString()) + 1;
            strSQL = "insert into resultados values (" + codResult + ",'" + txtResult.Text + "','" + txtFecResult.Text + "','" + txtHoraResult.Text + "')";
            conex.GrabarDatos(strSQL);
            strSQL = "update tratamientos set cod_result=" + codResult + " where  cod_tratam=" + codTrat + "";
            conex.GrabarDatos(strSQL);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        int MaxTrat()
        {
            int max;
            strSQL = "select max(Cod_Tratam) from tratamientos";
            dt = conex.ObtenerDatos(strSQL);
            if (dt.Rows[0].ItemArray[0].ToString() == "")
                max = 1;
            else
                max = int.Parse(dt.Rows[0].ItemArray[0].ToString()) + 1;
            return max;
        }
        int ObtenMaxTrat()
        {
            int max;
            strSQL = "select max(Cod_Tratam) from tratamientos";
            dt = conex.ObtenerDatos(strSQL);
            max = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            return max;
        }
    }
}