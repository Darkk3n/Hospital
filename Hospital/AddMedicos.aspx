<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMedicos.aspx.cs" Inherits="Hospital.AddMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        #form1 {
            height: 716px;
        }

        .auto-style2 {
            width: 209px;
        }

        .auto-style3 {
            height: 23px;
        }

        .auto-style4 {
            height: 26px;
        }

        .auto-style5 {
            font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande", "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
            color: #0066CC;
            background-image: url('');
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 align="center" class="auto-style5">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo sgih2.png" />
            CAPTURA MEDICOS</h1>
        <p align="center" class="auto-style5">
            <asp:Panel ID="Panel1" runat="server" Height="460px">
                <table style="color: #0066CC; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                    <tr>
                        <td>
                            <asp:RadioButton ID="rbtn1" runat="server" Text="Medico Nuevo" AutoPostBack="True" Checked="True" GroupName="radiogroup" OnCheckedChanged="rbtn1_CheckedChanged1" />
                        </td>
                        <td class="auto-style2"></td>
                        <td colspan="2">
                            <asp:RadioButton ID="rbtn2" runat="server" Text="Asignar Jefatura a Medico" AutoPostBack="True" GroupName="radiogroup" OnCheckedChanged="rbtn2_CheckedChanged" />
                        </td>
                        <td></td>

                    </tr>
                    <tr>
                        <td>Nombre:</td>
                        <td class="auto-style2"><asp:TextBox ID="txtmed1" runat="server"></asp:TextBox></td>
                        <td>Jefe:</td>
                        <td><asp:DropDownList ID="ddlJef" runat="server"></asp:DropDownList></td>
                    </tr>

                    <tr>
                        <td>Telefono:</td>
                        <td class="auto-style2">

                            <asp:TextBox ID="txtmed2" runat="server"></asp:TextBox>

                        </td>
                        <td>Medico:</td>
                        <td><asp:DropDownList ID="ddlMed" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Especialidad:</td>
                        <td>

                            <asp:TextBox ID="txtmed3" runat="server"></asp:TextBox>

                        </td>
                        <td>
                            <asp:Button ID="btn2" runat="server" align="center" OnClick="btn2_Click" Text="Agregar Jefatura" />
                        </td>

                    </tr>
                    <tr>
                        <td>Hospital:</td>
                        <td><asp:DropDownList ID="ddlHosp" runat="server" OnSelectedIndexChanged="ddlHosp_SelectedIndexChanged1"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Area:</td>
                        <td><asp:DropDownList ID="ddl1" runat="server"></asp:DropDownList></td>
                    </tr>
                
                    <tr>
                        <td class="auto-style4"></td>
                    </tr>
                    <tr>
                        <td>

                            <asp:Button ID="btn1" runat="server" Text="Agregar Medico" OnClick="btn1_Click1" />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btnSalir" runat="server" Text="Regresar" OnClick="btnSalir_Click1" />

                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/medico.png" Style="top: 200px; left: 935px; position: absolute; height: 256px; width: 256px" />

                        </td>
                    </tr>
                </table>
                <asp:Label ID="Label3" runat="server" Text="Modulo para registrar Medicos y asignar jefatura a Medicos Existentes" Style="top: 166px; left: 783px; position: absolute; height: 40px; width: 538px; color: #0066CC; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif"></asp:Label>

            </asp:Panel>
    </form>
</body>
</html>
