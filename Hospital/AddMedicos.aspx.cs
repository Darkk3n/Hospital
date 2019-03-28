using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hospital
{
    public partial class AddMedicos : System.Web.UI.Page
    {
        DataTable dt;
        Conexion conex = new Conexion();
        string strSQL;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rbtn1.Checked = false;
                rbtn2.Checked = false;
                strSQL = "select cod_hosp, nombre_hosp from hospitales";
                ddlHosp.DataSource = conex.ObtenerDatos(strSQL);
                ddlHosp.DataValueField = "cod_hosp";
                ddlHosp.DataTextField = "nombre_hosp";
                ddlHosp.Items.Insert(0, "--SELECCIONE--");
                strSQL = "select cod_medico, nombre from doctores where cod_jefe is not null";
                ddlMed.DataSource = conex.ObtenerDatos(strSQL);
                ddlMed.DataValueField = "cod_medico";
                ddlMed.DataTextField = "nombre";
                strSQL = "select cod_medico, nombre from doctores where cod_jefe is null";
                ddlJef.DataSource = conex.ObtenerDatos(strSQL);
                ddlJef.DataValueField = "cod_medico";
                ddlJef.DataTextField = "nombre";
                DataBind();
                ddlJef.Items.Insert(0, "--SELECCIONE--");
                ddlMed.Items.Insert(0, "--SELECCIONE--");
                ddlHosp.Items.Insert(0, "--SELECCIONE--");
                Deshabilita();
            }
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            if (ddlMed.SelectedIndex != 0 & ddlJef.SelectedIndex != 0)
            {
                int jefe;
                strSQL = "select max(cod_jefe) from jefes";
                dt = conex.ObtenerDatos(strSQL);
                if (dt.Rows[0].ItemArray[0].ToString() == "")
                    jefe = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                else
                    jefe = int.Parse(dt.Rows[0].ItemArray[0].ToString()) + 1;
                strSQL = "INSER INTO JEFES VALUES (" + jefe + "," + ddlMed.SelectedValue + ")";
                conex.GrabarDatos(strSQL);
                strSQL = "update doctores set cod_jefe=" + jefe + " where cod_medico=" + ddlMed.SelectedValue + ")";
                conex.GrabarDatos(strSQL);
            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            int med;
            strSQL = "select max(cod_medico) from doctores";
            dt = conex.ObtenerDatos(strSQL);
            if (dt.Rows[0].ItemArray[0].ToString() == "")
                med = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            else
                med = int.Parse(dt.Rows[0].ItemArray[0].ToString()) + 1;
            strSQL = "insert into  doctores values(" + med + ", '" + txtmed1.Text + "', '" + txtmed2.Text + "', '" + txtmed3.Text + "', " + ddl1.SelectedValue + ", null)";
            try 
                {
                conex.GrabarDatos(strSQL);
                }
                catch (Exception ex)
                {
                    Response.Write("<script type=\"text/javascript\">alert('" + ex.Message.ToString() + "');</script>");
                }
            Response.Redirect("AddMedicos.aspx");
        }

        protected void rbtn1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn1_Click1(object sender, EventArgs e)
        {
            int med;
            strSQL = "select max(cod_medico) from doctores";
            dt = conex.ObtenerDatos(strSQL);
            if (dt.Rows[0].ItemArray[0].ToString() == "")
                med = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            else
                med = int.Parse(dt.Rows[0].ItemArray[0].ToString()) + 1;
            strSQL = "insert into  doctores values(" + med + ", '" + txtmed1.Text + "', '" + txtmed2.Text + "', '" + txtmed3.Text + "', " + ddl1.SelectedValue + ", null)";
            try
            {
                conex.GrabarDatos(strSQL);
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message.ToString() + "');</script>");
            }
            Response.Redirect("AddMedicos.aspx");
        }

        protected void btnSalir_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void rbtn1_CheckedChanged1(object sender, EventArgs e)
        {
            if (rbtn1.Checked == true & rbtn2.Checked==false)
            {
                ddlMed.Enabled = false;
                ddlJef.Enabled = false;
                btn2.Enabled = false;
                txtmed1.Enabled = true;
                txtmed2.Enabled = true;
                txtmed3.Enabled = true;
                ddlHosp.Enabled = true;
                ddl1.Enabled = true;
                //ddl2.Enabled = true;
                btn1.Enabled = true;

            }

           
        }

        protected void rbtn2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn2.Checked == true & rbtn1.Checked==false )
            {
                btn1.Enabled = false;
                txtmed1.Enabled = false;
                txtmed2.Enabled = false;
                txtmed3.Enabled = false;
                ddlHosp.Enabled = false;
                ddl1.Enabled = false;
                //ddl2.Enabled = false;
                ddlMed.Enabled = true;
                ddlJef.Enabled = true;
                btn2.Enabled = true;
            }
        }

        protected void ddlHosp_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlHosp.SelectedIndex != 0)
            {
                strSQL = "select cod_area, descripcion from areas where cod_hosp=" + ddlHosp.SelectedValue + "";
                ddl1.DataSource = conex.ObtenerDatos(strSQL);
                ddl1.DataValueField = "cod_area";
                ddl1.DataTextField = "descripcion";
                ddl1.DataBind();
                ddl1.Items.Insert(0, "--SELECCIONE--");
            }
            else
            {
                ddl1.Items.Clear();
            }
        }
        void Deshabilita()
        {
            ddl1.Enabled = false;
            ddlJef.Enabled = false;
            ddlMed.Enabled = false;
            txtmed1.Enabled = false;
            txtmed2.Enabled = false;
            txtmed3.Enabled = false;
            ddlHosp.Enabled = false;
            btn1.Enabled = false;
            btn2.Enabled = false;
        }
    }
}
