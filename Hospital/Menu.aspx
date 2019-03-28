<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Hospital.Menu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxCT" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menú Principal</title>
    <style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
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
            width: 225px;
        }
        .auto-style3 {
            width: 150px;
        }
        .auto-style4 {
            width: 228px;
        }
        .auto-style5 {
            width: 202px;
        }
        .auto-style6 {
            width: 116px;
        }
    </style>
</head>
<body style="width: 1311px">
    <form id="form1" runat="server">
        <AjaxCT:ToolkitScriptManager ID="toolscriptmanager" runat="server"></AjaxCT:ToolkitScriptManager>
        <div>
            <h2 align="center" style="width: 967px">
                <asp:Image ID="Image1" runat="server" style="top: 32px; left: 128px; position: absolute; height: 134px; width: 127px" ImageUrl="~/Images/logo sgih2.png" />
                <asp:Label ID="Label1" runat="server" Font-Names="High Tower Text" Font-Size="X-Large" ForeColor="#003399" style="font-family: 'Levenim MT'; top: 69px; left: 305px; position: absolute; height: 43px; width: 744px;" Text="Sistema de Gestion de Informacion Hospitalaria" Font-Bold="True"></asp:Label>
                </h2>
            <p align="center" style="width: 967px">
                &nbsp;</p>
            <p align="center" style="width: 967px">
                &nbsp;</p>
            <p align="center" style="width: 967px">
                &nbsp;</p>
            <p align="center" style="width: 967px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label align="center" ID="lblDoc" runat="server" Font-Italic="True" Font-Size="X-Large" style="color: #008000; font-family: 'Arial Rounded MT Bold'; font-weight: 700; font-style: normal">BIENVENIDO</asp:Label>
            </p>
            <p align="center" style="width: 1369px; background-image: url('Images/Lineas-de-fondo.jpg')">&nbsp;</p>
            <%--<asp:Label ID="lblDoc" runat="server" Font-Italic="True" Font-Size="Large"></asp:Label>--%>
            <table border="0" align="center" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; width: 988px">
                <tr>
                    <td class="auto-style6"><asp:LinkButton align="center" ID="lbtnCat" runat="server">Catalogos</asp:LinkButton></td>
                    <td class="auto-style1"><asp:LinkButton ID="lbtnDiag" runat="server">Diagnostiscos de Pacientes</asp:LinkButton></td>
                    <td class="auto-style4"><asp:LinkButton ID="lbtnTratamientos" runat="server">Tratamientos de Pacientes</asp:LinkButton></td>
                    <td class="auto-style5"><asp:LinkButton ID="lbtnActualiza" runat="server">Actualización/Cambios</asp:LinkButton></td>
                    <td class="auto-style3"><asp:LinkButton ID="lbtnRep" runat="server" OnClick="lbtnRep_Click">Reportes</asp:LinkButton></td>
                    <td ><asp:LinkButton ID="lbtnBorrar" runat="server" OnClick="lbtnBorrar_Click">Borrar Datos</asp:LinkButton></td>
                </tr>
            </table>
        </div>
        <AjaxCT:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="lbtnTratamientos"
            CancelControlID="btnClose" BackgroundCssClass="modalBackground">
        </AjaxCT:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" align="center"  Style="display: none" CssClass="modalPopup">
            <table>               
                <tr>
                    <td colspan="2">Seleccione un Paciente</td>
                </tr>
                <tr>
                    <td colspan="2"><asp:DropDownList ID="ddlPacientes" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" /></td>
                    <td><asp:Button ID="btnClose" runat="server" Text="Cerrar" /></td>
                </tr>
            </table>                        
        </asp:Panel>
                <AjaxCT:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel2" TargetControlID="lbtnActualiza"
            CancelControlID="btnClose" BackgroundCssClass="modalBackground"></AjaxCT:ModalPopupExtender>
        <asp:Panel ID="Panel2" runat="server" align="center" Style="display: none" CssClass="modalPopup">
            <table>               
                <tr>
                    <td colspan="2">Seleccione un Paciente</td>
                </tr>
                <tr>
                    <td colspan="2"><asp:DropDownList ID="ddlPacientes1" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnAcep" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" /></td>
                    <td><asp:Button ID="btnCerrar1" runat="server" Text="Cerrar" /></td>
                </tr>
            </table> 
        </asp:Panel>
        <AjaxCT:ModalPopupExtender ID="ModalPopUpExt2" runat="server" PopupControlID="Panel3" TargetControlID="lbtnDiag"
            CancelControlID="btnCerrarDiag" BackgroundCssClass="modalBackground" ></AjaxCT:ModalPopupExtender>
        <asp:Panel ID="Panel3" runat="server" align="center" CssClass="modalPopup" Style="display:none" >
            <table>
                <tr>
                    <td align="center"><h3>Pacientes</h3></td>
                    <td align="center"><asp:LinkButton ID="lbtnNuevo" runat="server" OnClick="lbtnNuevo_Click">Nuevo Registro</asp:LinkButton> </td>
                    <td align="center"><asp:LinkButton ID="lbtnExistente" runat="server">Registro Existente</asp:LinkButton> </td>
                </tr>
           <tr>
               <td colspan="3" align="center"><asp:Button ID="btnCerrarDiag" runat="server" Text="Cerrar" /></td>
           </tr>
            </table>
        </asp:Panel>
         <AjaxCT:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel4" TargetControlID="lbtnExistente"
            CancelControlID="btnCerrarPacExt" BackgroundCssClass="modalBackground"></AjaxCT:ModalPopupExtender>
        <asp:Panel ID="Panel4" runat="server" align="center"  CssClass="modalPopup" Style="display:none">
            <table>
                <tr>
                    <td align="center"><h3>Pacientes</h3></td>                   
                </tr>
                <tr>
                    <td align="center"><asp:DropDownList ID="ddlPacientesExist" runat="server"></asp:DropDownList> </td>                    
                </tr>
                <tr>
                    <td align="center"><asp:Button ID="btnAceptPacExt" runat="server" Text="Aceptar" OnClick="btnAceptPacExt_Click"/></td>
                    <td align="center"><asp:Button ID="btnCerrarPacExt" runat="server" Text="Cerrar"/></td>
                </tr>
            </table>
        </asp:Panel>
        <AjaxCT:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel5" TargetControlID="lbtnCat"
            CancelControlID="btnCerrarCat" BackgroundCssClass="modalBackground"></AjaxCT:ModalPopupExtender>
        <asp:Panel ID="Panel5" runat="server" align="center"  CssClass="modalPopup" Style="display:none">
            <table>
                <tr>
                    <td align="center" colspan="2"><h3>Catalogos</h3></td>                   
                </tr>
                <tr>
                    <td><asp:LinkButton ID="lbtnMedicos" runat="server" OnClick="lbtnMedicos_Click">Medicos</asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtnHosp" runat="server" OnClick="lbtnHosp_Click">Hospitales</asp:LinkButton></td>
                </tr>
                <tr>                   
                    <td align="center" colspan="2"><asp:Button ID="btnCerrarCat" runat="server" Text="Cerrar"/></td>
                </tr>
            </table>
        </asp:Panel>
        <p>
        <asp:Image align="center" ID="Image2" runat="server" ImageUrl="~/Images/hospitalll.png" Width="597px" Height="310px" style="top: 280px; left: 413px; position: absolute" />
        </p>
    </form>
</body>
</html>


