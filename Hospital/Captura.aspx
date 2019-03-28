<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captura.aspx.cs" Inherits="Hospital.Captura" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Captura de Información</title>
    <style type="text/css">
        .auto-style1 {
            color: #33CC33;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <asp:Panel ID="panel1" runat="server" Height="642px">
        <AjaxCT:ToolkitScriptManager ID="toolscript" runat="server"></AjaxCT:ToolkitScriptManager>       
            <div>
                <AjaxCT:CalendarExtender ID="calendar1" runat="server" TargetControlID="txtFecNac" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>
                <AjaxCT:CalendarExtender ID="calendar2" runat="server" TargetControlID="txtFecIng" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>
                <%--<AjaxCT:CalendarExtender ID="calendar3" runat="server" TargetControlID="txtFecSalida" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>--%>
                <h1 align="center" style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo sgih2.png" />
                    <span class="auto-style1">Captura de Información</span></h1>
                <p align="center" style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; height: 25px; background-image: url('Images/Lineas-de-fondo.jpg')">
                    &nbsp;</p>
                <table style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; color: #008000">
                    <tr>
                        <td align="right">Categoría:</td>
                        <td>
                            <asp:DropDownList ID="ddlCateg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCateg_SelectedIndexChanged">
                                <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
                                <asp:ListItem Value="1">Primera</asp:ListItem>
                                <asp:ListItem Value="2">Segunda</asp:ListItem>
                                <asp:ListItem Value="4">Tercera</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">Nombre:</td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">Fecha de Nacimiento:</td>
                        <td>
                            <asp:TextBox ID="txtFecNac" runat="server"></asp:TextBox></td>
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
                        <td align="right">Área:</td>
                        <td>
                            <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">Sala:</td>
                        <td>
                            <asp:DropDownList ID="ddlSalaHosp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSalaHosp_SelectedIndexChanged"></asp:DropDownList></td>
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
                    <%--  <tr>
                    <td align="right">Fecha de Salida:</td>
                    <td>
                        <asp:TextBox ID="txtFecSalida" runat="server"></asp:TextBox></td>
                </tr>--%>
                    <tr>
                        <td align="right">Diagnostico:</td>
                        <td>
                            <asp:TextBox ID="txtDiag" runat="server" Height="78px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /></td>
                        <td>
                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" /></td>
                    </tr>
                </table>
                <asp:Label ID="Label1" runat="server" Text="Modulo para registrar nuevo Asegurado " style="top: 244px; left: 568px; position: absolute; height: 20px; width: 300px; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; color: #33CC33"></asp:Label>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/nuevousuario.png" style="top: 279px; left: 644px; position: absolute; height: 170px; width: 170px" />
            </div>
        </asp:Panel>
    </form>
</body>
</html>
