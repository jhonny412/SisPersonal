<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Estilos/Estilos.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            text-align: center;
        }
        .auto-style2 {
            width: 98%;
            height: 410px;
        }
        .auto-style3 {
            height: 172px;
        }
        .auto-style6 {
            height: 39px;
        }
        .auto-style7 {
            height: 44px;
        }
        .auto-style8 {
            height: 7px;
        }
        .auto-style9 {
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <strong>
        <br />
        Acceso al Sistema<br />
        </strong><br /><div id="login">
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">
                        <div id="imagenLogin">
                            <asp:Image CssClass="imagenLogin" ID="Image1" runat="server" Height="165px" Width="164px" ImageUrl="~/Imagen/login.png" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="170px" placeholder="Ingrese usuario" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:TextBox ID="TextBox2" runat="server" Width="170px" placeholder="Ingrese contraseña" required></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Button CssClass="boton" ID="btnIngresar" runat="server" Text="Ingresar" Width="105px" Height="30px" OnClick="btnIngresar_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium">
                        <a href="#">Olvido su contraseña?</a></td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox3" runat="server" placeholder="Ingrese aqui su e-mail"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:Button CssClass="boton" ID="btnEnviar" runat="server" Text="Enviar" Width="105px" Height="30px" />
                    </td>
                </tr>
            </table>
            </div>
    </div>
    </form>
</body>
</html>
