<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthCode.aspx.cs" Inherits="AuthCode.AuthCOde" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 200px; height: 200px;">

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Image ID="Image1" ImageUrl="/AuthCode.aspx" runat="server" />

        </div>
    </form>
</body>
</html>
