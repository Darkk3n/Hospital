using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;

namespace Hospital
{
    public partial class Reportes : System.Web.UI.Page
    {
        Conexion conex = new Conexion();
        DataTable dt;
        string strSQL;
        protected void Page_Load(object sender, EventArgs e)
        {
            dgRep.Enabled = false;
            if (!Page.IsPostBack)
            {
                strSQL = "select cod_poliza, observaciones from polizas";
                dt = conex.ObtenerDatos(strSQL);
                ddlPoliza.DataSource = dt;
                ddlPoliza.DataValueField = "cod_poliza";
                ddlPoliza.DataTextField = "observaciones";
                strSQL = "select cod_hosp, nombre_hosp from hospitales";
                dt = conex.ObtenerDatos(strSQL);
                ddlHosp.DataSource = dt;
                ddlHosp.DataValueField = "cod_hosp";
                ddlHosp.DataTextField = "nombre_hosp";
                strSQL = "select cod_asegur, nombre from asegurados";
                ddlAseg.DataSource = conex.ObtenerDatos(strSQL);
                ddlAseg.DataValueField = "cod_asegur";
                ddlAseg.DataTextField = "nombre";
                DataBind();
                ddlHosp.Items.Insert(0, "--SELECCIONE--");
                ddlPoliza.Items.Insert(0, "--SELECCIONE--");
                ddlAseg.Items.Insert(0, "--SELECCIONE--");

            }
        }

        protected void lbtnRep1_Click(object sender, EventArgs e)
        {
            strSQL = "select distinct doc.cod_medico as \"Clave Medico\", doc.nombre as \"Nombre Medico\" ,"
+ " (select count(hosp.cod_medico) from hospitalizaciones hosp where hosp.cod_medico=doc.cod_medico) as \"Asegurados\" "
+ " from doctores doc ,hospitalizaciones hosp "
+ "where doc.cod_medico=hosp.cod_medico;";
            dgRep.DataSource = conex.ObtenerDatos(strSQL);
            dgRep.DataBind();

        }

        protected void lbtnRep2_Click(object sender, EventArgs e)
        {
            strSQL = "select distinct hosp.nombre_hosp as \"Hospital\","
+ " (select count(hospt.cod_hosp) from hospitalizaciones hospt where hospt.cod_hosp=hosp.cod_hosp) as \"Asegurados\" "
+ "from hospitales hosp, hospitalizaciones hospt "
+ "where hosp.cod_hosp=hospt.cod_hosp;";
            dgRep.DataSource = conex.ObtenerDatos(strSQL);
            dgRep.DataBind();
        }

        protected void lbtnRep3_Click(object sender, EventArgs e)
        {
            strSQL = "select aseg.categoria as \"Categoria\", (select count(Categoria)) as \"Cantidad\" from asegurados aseg group by Categoria";
            dgRep.DataSource = conex.ObtenerDatos(strSQL);
            dgRep.DataBind();
        }

        protected void lbtnRep4_Click(object sender, EventArgs e)
        {

        }

        protected void btnAcpPol_Click(object sender, EventArgs e)
        {
            if (ddlPoliza.SelectedIndex != 0)
            {
                strSQL = "select aseg.nombre as \"Nombre\", aseg.fecha_nacim as \"Fecha de Nacimiento\", aseg.categoria as \"Categoria\", pol.observaciones as \"Poliza\" "
+ "from asegurados aseg, polizas pol "
+ "where aseg.cod_poliza=pol.Cod_Poliza "
+ "and pol.cod_poliza=" + ddlPoliza.SelectedValue + "";
                dgRep.DataSource = conex.ObtenerDatos(strSQL);
                dgRep.DataBind();
            }
        }

        protected void btnPacHosp_Click(object sender, EventArgs e)
        {
            if (ddlHosp.SelectedIndex != 0)
            {
                strSQL = "select p1.cod_asegur as 'Codigo de Asegurado', pol.observaciones as 'Observaciones', hosp.nombre_hosp as 'Hospital', "
                + " p1.nombre as 'Nombre', p1.fecha_nacim as 'Fecha de Nacimiento', p1.categoria as 'Categoria', p2.Cod_Hospitaliz as 'Codigo de Hospitalizacion', "
                + " doc.nombre as 'Medico que atiende' "
                + "from hospital.asegurados as p1, hospital.hospitalizaciones as p2, polizas pol, hospitales hosp, doctores doc "
                + "where p1.Cod_Asegur = p2.Cod_Asegur "
                + "and doc.cod_medico=p2.cod_medico "
                + "and hosp.cod_hosp=p1.cod_hosp "
                + "and p1.cod_poliza=pol.Cod_Poliza "
                + "and p2.Cod_Hosp =" + ddlHosp.SelectedValue + "";
                dgRep.DataSource = conex.ObtenerDatos(strSQL);
                dgRep.DataBind();
            }
        }

        protected void lbtnRep6_Click(object sender, EventArgs e)
        {
            strSQL = "select p1.nombre from hospital.doctores as p1, hospital.jefes as p2 where p1.Cod_Medico = p2.Cod_Medico;";
            dgRep.DataSource = conex.ObtenerDatos(strSQL);
            dgRep.DataBind();

        }

        protected void btnAcpInfo_Click(object sender, EventArgs e)
        {
            strSQL = "select aseg.cod_asegur as \"Codigo de Asegurado\", pol.observaciones as \"Poliza\" , "
+ "aseg.nombre as \"Nombre\", aseg.fecha_nacim as \"Fecha de Nacimiento\", aseg.categoria as \"Categoria\", hospt.cod_hospitaliz as \"Hospitalizacion\", "
+ "hosp.nombre_hosp as \"Hospital\", doc.nombre as \"Medico\",  hospt.diagnostico as \"Diagnostico\", trat.Descripcion as \"Tratamiento\" , "
+ "res.descripcion as \"Resultado\", hospt.fecha_inic as \"Fecha de Entrada\", hospt.fecha_salida as \"Fecha de Salida\" "
+ "from asegurados aseg, polizas pol, hospitales hosp, hospitalizaciones hospt, tratamientos trat, doctores doc, resultados res "
+ "where pol.cod_poliza=aseg.Cod_Poliza "
+ "and aseg.cod_asegur=hospt.cod_Asegur and hosp.cod_hosp=hospt.cod_hosp and doc.cod_medico=hospt.Cod_medico and trat.cod_tratam=hospt.cod_tratam "
+ "and res.Cod_Result=trat.cod_result	 and aseg.cod_asegur= " + ddlAseg.SelectedValue + " group by aseg.cod_asegur";
            dgRep.DataSource = conex.ObtenerDatos(strSQL);
            dgRep.DataBind();
        }

        protected void lbtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
        }

        protected void btn_Click1(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            strSQL = "select distinct doc.cod_medico as \"Clave Medico\", doc.nombre as \"Nombre Medico\" ,"
+ " (select count(hosp.cod_medico) from hospitalizaciones hosp where hosp.cod_medico=doc.cod_medico) as \"Asegurados\" "
+ " from doctores doc ,hospitalizaciones hosp "
+ "where doc.cod_medico=hosp.cod_medico;";
            dgRep.DataSource = conex.ObtenerDatos(strSQL);
            dgRep.DataBind();
            //lbtnRep1_Click(sender, e);
        }


    }
}