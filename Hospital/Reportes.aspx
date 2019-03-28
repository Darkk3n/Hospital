<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Hospital.Reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
    <style type="text/css">
        .mGrid {
            width: 100%;
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
        }

            .mGrid tr {
                padding: 4px 2px;
                color: #fff;
                background: #424242 repeat-x top;
                border-left: solid 1px #525252;
                font-size: 0.9em;
                font-family: "Trebuchet MS";
            }

            .mGrid td {
                padding: 2px;
                border: solid 1px #c1c1c1;
                font-family: "Calibri";
                /*color: #717171;*/
            }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }

        .auto-style1 {
            font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande", "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
            color: #0033CC;
        }

        .divWaiting {
            position: absolute;
            background-color: #FAFAFA;
            z-index: 2147483647 !important;
            opacity: 0.8;
            overflow: hidden;
            text-align: center;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            padding-top: 20%;
        }
        .auto-style2 {
            height: 166px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <AjaxCT:ToolkitScriptManager ID="TSM1" runat="server"></AjaxCT:ToolkitScriptManager>
        <h1 align="center" class="auto-style1">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo sgih2.png" Style="top: 14px; left: 353px; position: absolute; height: 122px; width: 116px" />
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/reportes.png" Style="top: 23px; left: 896px; position: absolute; height: 114px; width: 120px" />
        </h1>
        <p align="center" class="auto-style1">&nbsp;</p>
        <p align="center" class="auto-style1">&nbsp;</p>
        <p align="center" class="auto-style1">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Reportes"></asp:Label>
        </p>
        <p align="center" style="background-image: url('Images/azul-lineas-de-cuadricula-vector_270-163975.jpg')">&nbsp;</p>

        <%--<asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>--%>
        <table align="center" border="0" style="border: 3px outset #507CD1">
            <tr>
                <asp:UpdatePanel runat="server" ID="up1">
                    <ContentTemplate>
                        <td style="border: solid" align="center">
                            <asp:LinkButton ID="lbtnRep1" runat="server" OnClick="lbtnRep1_Click">Doctores que atienden a más asegurados</asp:LinkButton></td>
                        <td style="border: solid" align="center">
                            <asp:LinkButton ID="lbtnRep2" runat="server" OnClick="lbtnRep2_Click">Hospital con más asegurados</asp:LinkButton></td>
                        <td style="border: solid" align="center">
                            <asp:LinkButton ID="lbtnRep3" runat="server" OnClick="lbtnRep3_Click">Categoría con más asegurados</asp:LinkButton></td>
                        <td style="border: solid" align="center" rowspan="2">
                            <asp:LinkButton ID="lbtnSalir" runat="server" Text="Regresar" OnClick="lbtnSalir_Click" /></td>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </tr>
            <tr>
                <td style="border: solid" align="center">
                    <asp:LinkButton ID="lbtnRep4" runat="server" OnClick="lbtnRep4_Click">Asegurados por tipo de Poliza</asp:LinkButton></td>
                <td style="border: solid" align="center">
                    <asp:LinkButton ID="lbtnRep6" runat="server">Información de Asegurados</asp:LinkButton></td>
                <td style="border: solid" align="center">
                    <asp:LinkButton ID="lbtnRep5" runat="server">Pacientes por Hospital</asp:LinkButton></td>
            </tr>
        </table>
        <asp:UpdatePanel ID="up2" runat="server">
            <ContentTemplate>
                <asp:Button ID="btn1" runat="server" Text="boton" OnClick="btn_Click1" />
                <table align="center" border="1">
                    <tr>
                        <td style="border: solid" class="auto-style2">
                            <asp:DataGrid ID="dgRep" runat="server" CssClass="mGrid"></asp:DataGrid></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="updateprog1" runat="server" DisplayAfter="10" AssociatedUpdatePanelID="up1">
            <ProgressTemplate>
                <div>
                    <img src="images/gifs/loading2.gif" />&nbsp;Please Wait...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>


        <AjaxCT:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="lbtnRep4"
            CancelControlID="btnCerrarPol" BackgroundCssClass="modalBackground">
        </AjaxCT:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" align="center" CssClass="modalPopup" Style="display: none">
            <table>
                <tr>
                    <td align="center" colspan="2">
                        <h3>Seleccione una Poliza</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlPoliza" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAcpPol" runat="server" Text="Aceptar" OnClick="btnAcpPol_Click" /></td>
                    <td align="center">
                        <asp:Button ID="btnCerrarPol" runat="server" Text="Cerrar" /></td>
                </tr>
            </table>
        </asp:Panel>
        <AjaxCT:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel2" TargetControlID="lbtnRep5"
            CancelControlID="btnCerrarPacHosp" BackgroundCssClass="modalBackground">
        </AjaxCT:ModalPopupExtender>
        <asp:Panel ID="Panel2" runat="server" align="center" CssClass="modalPopup" Style="display: none">
            <table>
                <tr>
                    <td align="center" colspan="2">
                        <h3>Seleccione un Hospital</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlHosp" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnPacHosp" runat="server" Text="Aceptar" OnClick="btnPacHosp_Click" /></td>
                    <td align="center">
                        <asp:Button ID="btnCerrarPacHosp" runat="server" Text="Cerrar" /></td>
                </tr>
            </table>
        </asp:Panel>
        <AjaxCT:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel3" TargetControlID="lbtnRep6"
            CancelControlID="btnCerrarPacHosp" BackgroundCssClass="modalBackground">
        </AjaxCT:ModalPopupExtender>
        <asp:Panel ID="Panel3" runat="server" align="center" CssClass="modalPopup" Style="display: none">
            <table>
                <tr>
                    <td align="center" colspan="2">
                        <h3>Seleccione un Asegurado</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlAseg" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAcpInfo" runat="server" Text="Aceptar" OnClick="btnAcpInfo_Click" /></td>
                    <td align="center">
                        <asp:Button ID="btnCerrarInfo" runat="server" Text="Cerrar" /></td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />



    </form>
</body>
</html>
