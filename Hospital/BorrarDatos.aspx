<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BorrarDatos.aspx.cs" Inherits="Hospital.BorrarDatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server">
            <h1 align ="center">Borrado de Datos</h1>
            <table>
                <tr><td></td></tr>
                <tr>
                    <td>¿Qué necesita eliminar?</td>
                    <td>
                        <asp:DropDownList ID="ddlSeleccionar" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSeleccionar_SelectedIndexChanged">
                            <asp:ListItem>--Seleccione--</asp:ListItem>
                            <asp:ListItem>Asegurados</asp:ListItem>
                            <asp:ListItem>Doctores</asp:ListItem>
                            <asp:ListItem>Hospitales</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr><td></td><td></td><td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" /></td></tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDato" runat="server" Text="Label" Visible="false"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDato" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr><td></td></tr>
            </table>
            <asp:GridView ID="gvrResultado" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Identificador" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click" Visible="False" />
        </asp:Panel>
    </form>
</body>
</html>
