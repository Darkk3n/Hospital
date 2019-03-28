using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Hospital
{
    public partial class Menu : System.Web.UI.Page
    {
        Conexion conex = new Conexion();
        string strSQL;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblDoc.Text = "Bienvenido, " + Session["usuario"];
            if (!Page.IsPostBack)
            {
                strSQL = "select aseg.cod_asegur, aseg.nombre, hospt.fecha_salida  from asegurados aseg, hospitalizaciones hospt where aseg.cod_asegur=hospt.cod_asegur and hospt.fecha_salida is null";
                dt = conex.ObtenerDatos(strSQL);
                ddlPacientes.DataSource = dt;
                ddlPacientes.DataValueField = "cod_asegur";
                ddlPacientes.DataTextField = "nombre";
                ddlPacientes1.DataSource = dt;
                ddlPacientes1.DataValueField = "cod_asegur";
                ddlPacientes1.DataTextField = "nombre";
                ddlPacientes.Items.Insert(0, "--SELECCIONE--");
                ddlPacientes1.Items.Insert(0, "--SELECCIONE--");
                dt = conex.ObtenerDatos(strSQL);
                strSQL = "select aseg.cod_asegur, aseg.nombre, hospt.fecha_salida  from asegurados aseg, hospitalizaciones hospt where aseg.cod_asegur=hospt.cod_asegur and hospt.fecha_salida is not null";
                dt = conex.ObtenerDatos(strSQL);
                ddlPacientesExist.DataSource = dt;
                ddlPacientesExist.DataValueField = "cod_asegur";
                ddlPacientesExist.DataTextField = "nombre";
                DataBind();
                ddlPacientes.Items.Insert(0, "--SELECCIONE--");
                ddlPacientes1.Items.Insert(0, "--SELECCIONE--");
                ddlPacientesExist.Items.Insert(0, "--SELECCIONE--");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ddlPacientes.SelectedIndex != 0)
            {
                Session["Asegurado"] = ddlPacientes.SelectedItem.ToString();
                Session["CodAseg"] = ddlPacientes.SelectedValue.ToString();
                Response.Redirect("Tratamientos.aspx");
            }
        }

        protected void btnAceptPacExt_Click(object sender, EventArgs e)
        {
            if (ddlPacientesExist.SelectedIndex != 0)
            {
                Session["PacExist"] = ddlPacientesExist.SelectedValue;
                Response.Redirect("CapturaExist.aspx");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Elija un Paciente');</script>");
                return;
            }
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Captura.aspx");
        }

        protected void lbtnRep_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }

        protected void lbtnMedicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMedicos.aspx");
        }

        protected void lbtnHosp_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarHospital.aspx");
        }

        protected void lbtnBorrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BorrarDatos.aspx");
        }
    }
}