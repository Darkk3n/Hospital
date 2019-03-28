using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using System.Windows.Forms;

namespace Hospital
{
    public partial class AgregarHospital : System.Web.UI.Page
    {
        Conexion conex = new Conexion();
        string strSQL;
        DataTable dt2;
        bool ok=false;
        string codhosp, nombhosp, numquir, tipohosp, presup, tiposer;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidaVacios();
            if (ok == true)
            {
                int codHospital;
                strSQL = "select max (cod_hosp) from hospitales";
                dt2 = conex.ObtenerDatos(strSQL);
                if (dt2.Rows[0].ItemArray[0].ToString() == "")
                    codHospital = int.Parse(dt2.Rows[0].ItemArray[0].ToString());
                else
                    codHospital = int.Parse(dt2.Rows[0].ItemArray[0].ToString() + 1);

                codhosp = codHospital.ToString();
                nombhosp = txtNombre.Text;
                numquir = txtNumQuir.Text;
                tipohosp = ddlTipoHosp.Text;
                presup = txtPresup.Text;
                tiposer = txtTipoServ.Text;

                Usuario oUsuario = new Usuario();
                oUsuario.Cod_Hosp = codhosp;
                oUsuario.Nombre_Hosp = nombhosp;
                oUsuario.Num_Quirof = numquir;
                oUsuario.Tipo_Hosp = tipohosp;
                oUsuario.Presupuesto = presup;
                oUsuario.Tipo_Serv = tiposer;
                try
                {
                    DataTable dt = oUsuario.InsertarHosp();
                    Response.Write("<script type=\"text/javascript\">alert('Datos guardados correctamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error:" + ex.Message + "');</script>");                                        
                }

            }
        }
        private void ValidaVacios()
        {
            foreach (Control ctl in Panel1.Controls)
            {
                if (ctl is System.Web.UI.WebControls.TextBox)
                {
                    TextBox txt;
                    txt = (TextBox)ctl;
                    if (txt.Text == "" & txt.Enabled == true)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Debe de llenar todos los campos antes de continuar');</script>");
                        ok = false;
                        return;
                    }
                }
                if (ctl is System.Web.UI.WebControls.DropDownList)
                {
                    DropDownList ddl;
                    ddl = (DropDownList)ctl;
                    if (ddl.SelectedIndex == 0 & ddl.Enabled == true)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Elija un valor de las listas desplegables');</script>");
                        ok = false;
                        return;
                    }
                }
            }
            ok = true;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}