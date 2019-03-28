<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarHospital.aspx.cs" Inherits="Hospital.AgregarHospital" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server">
            <h1 align="center" style="color: #808000; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo sgih2.png" />
                Registro de Hospitales</h1>
            <p align="center" style="color: #808000; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; background-image: url('Images/Lineas-de-fondo.jpg')">
                &nbsp;
            </p>                
                <table style="color: #008000; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                    <tr>
                        <td></td>
                    </tr>
                    <%--  <tr>
                    <td align="right">Código de Hospital: </td>
                    <td>
                        <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                    </td>
                </tr>--%>
                    <%--<tr><td></td></tr>--%>
                    <tr>
                        <td align="right">Nombre del Hospital: </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="right">Numero de Quirofanos: </td>
                        <td>
                            <asp:TextBox ID="txtNumQuir" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="right">Tipo de Hospital</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoHosp" runat="server" AutoPostBack="true">
                                <asp:ListItem>--SELECCIONE--</asp:ListItem>
                                <asp:ListItem>Propio</asp:ListItem>
                                <asp:ListItem>Concertado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="right">Presupuesto: </td>
                        <td>
                            <asp:TextBox ID="txtPresup" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="right">Tipo de Servicio: </td>
                        <td>
                            <asp:TextBox ID="txtTipoServ" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr align="center">
                        <td>
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" style="height: 26px" />
                        </td>
                    </tr>
                </table>            
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/4_Servicios de Salud.png" Style="top: 264px; left: 642px; position: absolute; height: 196px; width: 164px" />
        </asp:Panel>
        <asp:Label ID="Label1" runat="server" Text="Modulo para registrar nuevos Hospitales" Style="top: 209px; left: 566px; position: absolute; height: 19px; width: 312px; color: #808000; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif"></asp:Label>
    </form>
</body>
</html>
