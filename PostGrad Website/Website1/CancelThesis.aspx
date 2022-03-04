<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelThesis.aspx.cs" Inherits="Website1.CancelThesis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 48px;
            left: 596px;
            right: 100px;
            z-index: 1;
            height: 25px;
            width: 242px;
        }
        .auto-style2 {
            height: 238px;
            width: 1092px;
        }
        .auto-style3 {
            position: absolute;
            top: 44px;
            left: 19px;
            z-index: 1;
            width: 305px;
            font-size: 25px;
            height: 35px;
        }
        .auto-style4 {
            position: absolute;
            top: 48px;
            left: 320px;
            z-index: 1;
            width: 261px;
        }
        .auto-style5 {
            position: absolute;
            top: 114px;
            left: 180px;
            z-index: 1;
            width: 912px;
            font-size: 30px;
            height: 43px;
        }
        .auto-style6 {
            position: absolute;
            top: 80px;
            left: 319px;
            z-index: 1;
            width: 251px;
        }
        .auto-style7 {
            position: absolute;
            top: 22px;
            left: 21px;
            z-index: 1;
        }
    </style>
</head>
<body bgcolor="#000099">
    <form id="form1" runat="server">
        <div class="auto-style2">
            <asp:Button ID="Button1" runat="server" CssClass="auto-style1" Text="Delete" OnClick="delete1" BorderColor="#CCCCCC" BorderStyle="Solid" />
            <asp:Label ID="error1" runat="server" CssClass="auto-style6" ForeColor="#FF3300" Text="Please Enter ThesisSerialNo!" Visible="False"></asp:Label>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style3" ForeColor="Yellow" Text="Please Enter ThesisSerialNo :"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style4" ForeColor="Yellow" placeholder="Last Progress Report Evaluation Is Zero" TextMode="Number"></asp:TextBox>
            <asp:Label ID="Message" runat="server" CssClass="auto-style5" ForeColor="#FF3300" Text="Thesis Removed Successfully!" Visible="False"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style7" ForeColor="Yellow" NavigateUrl="Supervisor.aspx">Home Page</asp:HyperLink>
        </div>
    </form>
</body>
</html>
