using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hospital
{
    public partial class BorrarDatos : System.Web.UI.Page
    {

        string Variable;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ddlSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSeleccionar.Text == "Asegurados")
            {
                lblDato.Visible = true;
                txtDato.Visible = true;
                lblDato.Text = "Escriba uno de los nombres del asegurado: ";
            }
            else if(ddlSeleccionar.Text == "Doctores")
            {
                lblDato.Visible = true;
                txtDato.Visible = true;
                lblDato.Text = "Escriba uno de los nombres del Doctor: ";
            }
            else if(ddlSeleccionar.Text == "Hospitales")
            {
                lblDato.Visible = true;
                txtDato.Visible = true;
                lblDato.Text = "Escriba el nombre del Hospital: ";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            btnBorrar.Visible = true;
            if(ddlSeleccionar.Text == "Asegurados")
            {
                Usuario oUsuario = new Usuario();
                oUsuario.NombrePar = txtDato.Text;
                DataTable dt = oUsuario.BuscarAsegura();
                gvrResultado.DataSource = dt;
                gvrResultado.DataBind();
            }
            else if(ddlSeleccionar.Text == "Doctores")
            {
                Usuario oUsuario = new Usuario();
                oUsuario.NombrePar = txtDato.Text;
                DataTable dt = oUsuario.BuscarDoctor();
                gvrResultado.DataSource = dt;
                gvrResultado.DataBind();
            }
            else if(ddlSeleccionar.Text == "Hospitales")
            {
                Usuario oUsuario = new Usuario();
                oUsuario.NombrePar = txtDato.Text;
                DataTable dt = oUsuario.BuscarHospital();
                gvrResultado.DataSource = dt;
                gvrResultado.DataBind();
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow gvr in gvrResultado.Rows)
            {
                CheckBox chk = gvr.FindControl("CheckBox1") as CheckBox;
                if(chk.Checked)
                {
                    Variable = gvr.Cells[1].Text;

                    if (ddlSeleccionar.Text == "Asegurados")
                    {
                        Usuario oUsuario = new Usuario();
                        oUsuario.Codigo = Variable;
                        DataTable dt = oUsuario.BorrarAsegurado ();
                    }
                    else if (ddlSeleccionar.Text == "Doctores")
                    {
                        Usuario oUsuario = new Usuario();
                        oUsuario.Codigo = Variable;
                        DataTable dt = oUsuario.BorrarDoctor();
                    }
                    else if (ddlSeleccionar.Text == "Hospitales")
                    {
                        Usuario oUsuario = new Usuario();
                        oUsuario.Codigo = Variable;
                        DataTable dt = oUsuario.BorrarHospital();
                    }
                }
            }
        }
    }
}