<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tratamientos.aspx.cs" Inherits="Hospital.Tratamientos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCT" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <AjaxCT:ToolkitScriptManager ID="toolscriptmanager" runat="server"></AjaxCT:ToolkitScriptManager>
        <AjaxCT:CalendarExtender ID="calendar1" runat="server" TargetControlID="txtFecResult" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>
        <div>
            <h1 align="center" style="color: #808000; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                <asp:Image ID="Image1" runat="server" Height="118px" ImageUrl="~/Images/logo sgih2.png" Width="124px" />
                Tratamientos y Resultados del Paciente</h1>
            <p align="center" style="background-image: url('Images/Lineas-de-fondo.jpg')">&nbsp;</p>

            <table style="color: #008000; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                <tr>
                    <td align="center" colspan="3" style="font-weight:bold;font-size:larger">Tratamiento:</td>                    
                </tr>
                <tr>                    
                    <td  style="font-style:italic; font-size:large"><asp:TextBox TextMode="MultiLine" ID="txtTrat" runat="server" Height="55px"></asp:TextBox></td>
                    
                    <td align="left"><asp:Button ID="btnGuardTrat" runat="server" Text="Guardar" OnClick="btnGuardTrat_Click" /></td>
                </tr>
                <tr>
                    <td align="center" colspan="4" style="font-weight:bold;font-size:larger">Resultados:</td>
                    
                    
                </tr>
                <tr>
                    <td style="font-style:italic; font-size:large"><asp:TextBox TextMode="MultiLine" ID="txtResult" runat="server" Height="55px"></asp:TextBox></td>                    
                    
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
                    <td align="right" colspan="2"><asp:Button ID="btnGuardResult" runat="server" Text="Guardar" OnClick="btnGuardResult_Click" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="right"><asp:Button ID="btnSalir" runat="server" Text="Regresar" OnClick="btnSalir_Click" /></td>
                </tr>
            </table>
        </div>
        <asp:Image ID="Image2" runat="server" Height="211px" ImageUrl="~/Images/tratamiento.png" style="top: 273px; left: 734px; position: absolute" Width="206px" />
        <div style="margin-left: 40px">
            <asp:Label ID="Label2" runat="server" style="top: 241px; left: 554px; position: absolute; height: 19px; width: 569px; color: #808000; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif" Text="Modulo para registrar Tratamientos hechos a los pacientes y Resultados"></asp:Label>
        </div>
    </form>
</body>
</html>
