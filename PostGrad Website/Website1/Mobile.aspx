<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mobile.aspx.cs" Inherits="Website1.Mobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <asp:TextBox ID="PhoneBox" MaxLength="20" runat="server" Width="394px" placeholder="Phone Number Here" OnTextChanged="PhoneBox_TextChanged"></asp:TextBox>
            <br />
        </div>
        <div style="margin-left: 40px">
            <asp:Button ID="AddButton" runat="server" OnClick="onAdd" Text="Add" Width="138px" />
        </div>
    </form>
</body>
</html>

