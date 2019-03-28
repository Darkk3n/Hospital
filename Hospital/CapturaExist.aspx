<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapturaExist.aspx.cs" Inherits="Hospital.CapturaExist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Captura de Información</title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:Panel ID="panel1" runat="server">
        <AjaxCT:ToolkitScriptManager ID="toolscript" runat="server"></AjaxCT:ToolkitScriptManager>       
            <div>
                <AjaxCT:CalendarExtender ID="calendar1" runat="server" TargetControlID="txtFecNac" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>
                <AjaxCT:CalendarExtender ID="calendar2" runat="server" TargetControlID="txtFecIng" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>
                <%--<AjaxCT:CalendarExtender ID="calendar3" runat="server" TargetControlID="txtFecSalida" Format="yyyy/MM/dd"></AjaxCT:CalendarExtender>--%>
                <h1 align="center" style="color: #0066CC; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo sgih2.png" />
                    Captura de Información</h1>
                <p align="center" style="background-image: url('Images/azul-lineas-de-cuadricula-vector_270-163975.jpg')">
                    &nbsp;</p>
                <table style="color: #0066CC; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                    <tr>
                        <td align="right">Categoría:</td>
                        <td>
                            <asp:DropDownList ID="ddlCateg" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCateg_SelectedIndexChanged">
                                <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
                                <asp:ListItem Value="1">Primera</asp:ListItem>
                                <asp:ListItem Value="2">Segunda</asp:ListItem>
                                <asp:ListItem Value="4">Tercera</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Nombre:</td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Fecha de Nacimiento:</td>
                        <td>
                            <asp:TextBox ID="txtFecNac" runat="server"></asp:TextBox>
                            <AjaxCT:MaskedEditExtender ID="txtFecNac_MaskedEditExtender" runat="server" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFecNac">
                            </AjaxCT:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Poliza:</td>
                        <td>
                            <asp:DropDownList ID="ddlPoliza" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Tipo de Hospital:</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoH" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoH_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Hospital:</td>
                        <td>
                            <asp:DropDownList ID="ddlHospital" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHospital_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Área:</td>
                        <td>
                            <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Sala:</td>
                        <td>
                            <asp:DropDownList ID="ddlSalaHosp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSalaHosp_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Médico:</td>
                        <td>
                            <asp:DropDownList ID="ddlMed" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Fecha de Ingreso:</td>
                        <td>
                            <asp:TextBox ID="txtFecIng" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <%--  <tr>
                    <td align="right">Fecha de Salida:</td>
                    <td>
                        <asp:TextBox ID="txtFecSalida" runat="server"></asp:TextBox></td>
                </tr>--%>
                    <tr>
                        <td align="right">Diagnostico:</td>
                        <td>
                            <asp:TextBox ID="txtDiag" runat="server" Height="78px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
                        </td>
                        <td>
                            <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" />
                        </td>
                    </tr>
                </table>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/usuarioexist.jpg" style="top: 331px; left: 655px; position: absolute; height: 127px; width: 133px" />
                <asp:Label ID="Label1" runat="server" Text="Modulo para nuevos registos de Asegurado ya eistente" style="color: #0066CC; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; top: 263px; left: 505px; position: absolute; height: 18px; width: 419px"></asp:Label>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
