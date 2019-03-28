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
    public partial class CapturaExist : System.Web.UI.Page
    {
        Conexion conex = new Conexion();
        DataTable dt;
        string strSQL;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Llenar combos           
            if (!Page.IsPostBack)
            {
                CargaDatos();
                strSQL = "select cod_medico,nombre from doctores";
                dt = conex.ObtenerDatos(strSQL);
                ddlMed.DataSource = dt;
                ddlMed.DataValueField = "cod_medico";
                ddlMed.DataTextField = "Nombre";
                dt = null;
                strSQL = "select * from polizas";
                dt = conex.ObtenerDatos(strSQL);
                ddlPoliza.DataSource = dt;
                ddlPoliza.DataValueField = "cod_poliza";
                ddlPoliza.DataTextField = "observaciones";
                dt = null;
                DataBind();
                ddlTipoH.Items.Insert(0, "--SELECCIONE--");
                ddlPoliza.Items.Insert(0, "--SELECCIONE--");
                ddlMed.Items.Insert(0, "--SELECCIONE--");
            }
        }

        protected void ddlTipoH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoH.SelectedIndex != 0)
            {
                strSQL = "select cod_hosp,nombre_hosp from hospitales where tipo_hosp='" + ddlTipoH.SelectedItem.ToString() + "'";
                dt = conex.ObtenerDatos(strSQL);
                ddlHospital.DataSource = dt;
                ddlHospital.DataValueField = "cod_hosp";
                ddlHospital.DataTextField = "nombre_hosp";
                ddlHospital.DataBind();
                ddlHospital.Items.Insert(0, "--SELECCIONE--");
            }
            else
                ddlHospital.Items.Clear();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool ok = false;
            ValidaVacios(ok);
            if (ok == false)
            {
                int codigo_aseg, codigo_hospitaliz, cama;
                strSQL = "select max(cod_asegur) from asegurados";
                dt = conex.ObtenerDatos(strSQL);
                if (dt.Rows[0].ItemArray[0].ToString() == "")
                    codigo_aseg = 1;
                else
                    codigo_aseg = int.Parse(dt.Rows[0].ItemArray[0].ToString()) + 1;

                switch (ddlCateg.SelectedIndex)
                {
                    case 3:
                        strSQL = "insert into asegurados values (" + codigo_aseg + ", " + ddlPoliza.SelectedValue + ",null, '" + txtNombre.Text + "'," +
                   "'" + txtFecNac.Text + "', '" + ddlCateg.SelectedItem.ToString() + "')";
                        conex.GrabarDatos(strSQL);
                        break;
                    default:
                        //---------Obtener la cama
                        strSQL = "select min(camas.cod_camas) as cama" +
                        " from camas, salas, hospitales hosp " +
                        "where camas.estatus='disponible' and camas.cod_salas=" + ddlSalaHosp.SelectedValue + " and camas.cod_salas=salas.cod_salas and hosp.cod_hosp=salas.cod_hosp;";
                        //-------------------------------
                        dt = conex.ObtenerDatos(strSQL);
                        cama = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                        strSQL = "insert into asegurados values (" + codigo_aseg + ", " + ddlPoliza.SelectedValue + ", " + ddlHospital.SelectedValue + ", '" + txtNombre.Text + "'," +
                                      "'" + txtFecNac.Text + "', '" + ddlCateg.SelectedItem.ToString() + "')";
                        conex.GrabarDatos(strSQL);
                        //if (cama == 0)
                        //{
                        //    Response.Write("<script type=\"text/javascript\">alert(¡No se encuentran camas disponibles en esta sala!');</script>");
                        //    return;
                        //}
                        strSQL = "select max(cod_hospitaliz) from hospitalizaciones";
                        dt = conex.ObtenerDatos(strSQL);
                        if (dt.Rows[0].ItemArray[0].ToString() == "")
                            codigo_hospitaliz = 1;
                        else
                            codigo_hospitaliz = int.Parse(dt.Rows[0].ItemArray[0].ToString()) + 1;
                        strSQL = "insert into hospitalizaciones values (" + codigo_hospitaliz + ", " + ddlHospital.SelectedValue + ", " + codigo_aseg + ", " + ddlMed.SelectedValue + "," +
                            "" + cama + ", null, '" + txtFecIng.Text + "', null,  '" + txtDiag.Text + "')";
                        conex.GrabarDatos(strSQL);
                        strSQL = "update camas set estatus='Ocupada' where cod_camas=" + cama + "";
                        conex.GrabarDatos(strSQL);
                        break;
                }
            }
        }

        protected void ddlHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHospital.SelectedIndex != 0)
            {
                strSQL = "select cod_area, descripcion from areas where cod_hosp=" + ddlHospital.SelectedValue + "";
                dt = conex.ObtenerDatos(strSQL);
                ddlArea.DataSource = dt;
                ddlArea.DataValueField = "cod_area";
                ddlArea.DataTextField = "descripcion";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, "--SELECCIONE--");
            }
            else
                ddlArea.Items.Clear();
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txtFecNac.Text);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHospital.SelectedIndex != 0)
            {
                strSQL = "select distinct salas.cod_salas, areas.descripcion from salas, areas, camas cam where areas.cod_hosp=" + ddlHospital.SelectedValue + " and salas.cod_area=areas.cod_area and areas.cod_area=" + ddlArea.SelectedValue + " and  salas.cod_salas=cam.cod_salas and cam.estatus='disponible'";
                dt = conex.ObtenerDatos(strSQL);
                if (dt.Rows.Count > 0)
                {
                    ddlSalaHosp.DataSource = dt;
                    ddlSalaHosp.DataValueField = "cod_salas";
                    ddlSalaHosp.DataTextField = "cod_salas";
                    ddlSalaHosp.DataBind();
                    ddlSalaHosp.Items.Insert(0, "--SELECCIONE--");
                }
                else
                    Response.Write("<script type=\"text/javascript\">alert('¡No se encuentran camas disponibles en esta sala!');</script>");
            }
            else
                ddlSalaHosp.Items.Clear();
        }

        protected void ddlCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlCateg.SelectedIndex)
            {
                case 0:
                    ddlTipoH.Enabled = true;
                    ddlHospital.Enabled = true;
                    ddlArea.Enabled = true;
                    ddlSalaHosp.Enabled = true;
                    txtDiag.Enabled = true;
                    ddlMed.Enabled = true;
                    txtFecIng.Enabled = true;
                    ddlTipoH.Items.Clear();
                    break;
                case 1:
                    //Primera Categoria
                    ddlTipoH.Items.Clear();
                    ddlTipoH.Enabled = true;
                    ddlHospital.Enabled = true;
                    ddlArea.Enabled = true;
                    ddlMed.Enabled = true;
                    ddlSalaHosp.Enabled = true;
                    txtDiag.Enabled = true;
                    txtFecIng.Enabled = true;
                    ddlTipoH.Items.Insert(0, "--SELECCIONE--");
                    ddlTipoH.Items.Insert(1, "Propio");
                    ddlTipoH.Items.Insert(2, "Concertado");
                    break;
                case 2:
                    //Segunda Categoria
                    ddlTipoH.Items.Clear();
                    ddlTipoH.Enabled = true;
                    ddlHospital.Enabled = true;
                    ddlArea.Enabled = true;
                    ddlSalaHosp.Enabled = true;
                    txtDiag.Enabled = true;
                    ddlMed.Enabled = true;
                    txtFecIng.Enabled = true;
                    ddlTipoH.Items.Clear();
                    ddlTipoH.Items.Insert(0, "--SELECCIONE--");
                    ddlTipoH.Items.Insert(1, "Concertado");
                    //ddlTipoH.SelectedIndex = 1;
                    break;
                case 3:
                    //Tercera Categoria
                    ddlTipoH.Items.Clear();
                    ddlTipoH.Enabled = false;
                    ddlHospital.Enabled = false;
                    ddlArea.Enabled = false;
                    ddlSalaHosp.Enabled = false;
                    txtDiag.Enabled = false;
                    ddlMed.Enabled = false;
                    txtFecIng.Enabled = false;
                    break;
            }
        }

        protected void ddlSalaHosp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private Boolean ValidaVacios(bool val)
        {
            foreach (Control ctl in panel1.Controls)
            {
                if (ctl is System.Web.UI.WebControls.TextBox)
                {
                    TextBox txt;
                    txt = (TextBox)ctl;
                    if (txt.Text == "")
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Debe de llenar todos los campos antes de continuar');</script>");
                        ctl.Focus();
                        val = true;
                        return val;
                    }
                }
                if (ctl is System.Web.UI.WebControls.DropDownList)
                {
                    DropDownList ddl;
                    ddl = (DropDownList)ctl;
                    if (ddl.SelectedIndex == 0)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Elija un valor de las listas desplegables');</script>");
                        ctl.Focus();
                        val = true;
                        return val;
                    }
                }
            }
            return val;
        }

        private void CargaDatos()
        {
            string categoria;
            string strSQL2 = "select nombre, categoria, date(fecha_nacim), cod_poliza from asegurados where cod_asegur=" + int.Parse(Session["PacExist"].ToString()) + "";
            dt = conex.ObtenerDatos(strSQL2);
            categoria = dt.Rows[0].ItemArray[1].ToString();
            switch (categoria)
            {
           //--------Asigna categoria
                case "Primera":
                    ddlCateg.SelectedIndex = 1;
                    break;
                case "Segunda":
                    ddlCateg.SelectedIndex = 2;
                    break;
                case "Tercera":
                    ddlCateg.SelectedIndex = 3;
                    break;
            }
            //--------
            txtNombre.Text = dt.Rows[0].ItemArray[0].ToString();
            txtFecNac.Text = dt.Rows[0].ItemArray[2].ToString();
            ddlPoliza.SelectedIndex = int.Parse(dt.Rows[0].ItemArray[3].ToString());
        }
    }
}