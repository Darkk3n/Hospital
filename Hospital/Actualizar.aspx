<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actualizar.aspx.cs" Inherits="Hospital.Actualizar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCT" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Actualización de Información</title>
</head>
<body>
    <form id="form1" runat="server">
        <AjaxCT:ToolkitScriptManager ID="toolscript" runat="server"></AjaxCT:ToolkitScriptManager>
        <div>
            <AjaxCT:CalendarExtender ID="calendar1" runat="server" TargetControlID="txtFecNac" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>
            <AjaxCT:CalendarExtender ID="calendar2" runat="server" TargetControlID="txtFecIng" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>
            <%--<AjaxCT:CalendarExtender ID="calendar3" runat="server" TargetControlID="txtFecSalida" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>--%>
            <h1 align="center">Actualización de Información</h1>
            <table>
                <tr>
                    <td align="right">Categoría:</td>
                    <td>
                        <asp:TextBox ID="txtCateg" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">Nombre:</td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">Fecha de Nacimiento:</td>
                    <td><asp:TextBox ID="txtFecNac" runat="server"></asp:TextBox></td>                    
                </tr>
                <tr>
                    <td align="right">Poliza:</td>
                    <td>
                        <asp:DropDownList ID="ddlPoliza" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">Tipo de Hospital:</td>
                    <td>
                        <asp:DropDownList ID="ddlTipoH" runat="server" OnSelectedIndexChanged="ddlTipoH_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">Hospital:</td>
                    <td>
                        <asp:DropDownList ID="ddlHospital" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHospital_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">Sala:</td>
                    <td>
                        <asp:DropDownList ID="ddlSalaHosp" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">Médico:</td>
                    <td>
                        <asp:DropDownList ID="ddlMed" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="right">Fecha de Ingreso:</td>
                    <td>
                        <asp:TextBox ID="txtFecIng" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">Fecha de Salida:</td>
                    <td>
                        <asp:TextBox ID="txtFecSalida" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">Diagnostico:</td>
                    <td>
                        <asp:TextBox ID="txtDiag" runat="server" Height="78px" TextMode="MultiLine" Width="214px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="font-weight:bold;font-size:larger">Tratamiento:</td>                    
                </tr>
                <tr>                    
                    <td colspan="2" align="center"  style="font-style:italic; font-size:large"><asp:TextBox TextMode="MultiLine" ID="txtTrat" runat="server" Height="55px" Width="350px"></asp:TextBox></td>                                        
                </tr>
                <tr>
                    <td align="center" colspan="2" style="font-weight:bold;font-size:larger">Resultados:</td>
                    
                    
                </tr>
                <tr>
                    <td colspan="2" style="font-style:italic; font-size:large"><asp:TextBox TextMode="MultiLine" ID="txtResult" runat="server" Height="55px" Width="350px"></asp:TextBox></td>                                        
                </tr>
                <tr>
                    <td style="font-size:medium; font-style:italic;" align="right">Fecha:</td>
                    <td colspan="2"><asp:TextBox ID="txtFecResult" runat="server" Width="75px"></asp:TextBox></td>                    
                </tr>
                <tr>
                  <td style="font-size:medium; font-style:italic;" align="right">Hora:</td>
                    <td colspan="2"><asp:TextBox ID="txtHoraResult" runat="server"  Width="75px" TextMode="Number"></asp:TextBox></td> 
                </tr>

                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
