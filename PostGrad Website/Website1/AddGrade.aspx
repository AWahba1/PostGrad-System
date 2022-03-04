<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGrade.aspx.cs" Inherits="Website1.AddGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 214px;
        }
        .auto-style2 {
            position: absolute;
            top: 79px;
            left: 25px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 79px;
            left: 160px;
            z-index: 1;
            width: 229px;
        }
        .auto-style6 {
            position: absolute;
            top: 21px;
            left: 477px;
            z-index: 1;
            height: 50px;
            font-size:40px;
            width: 317px;
        }
        .auto-style8 {
            position: absolute;
            top: 81px;
            left: 410px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 24px;
            left: 16px;
            z-index: 1;
        }
        .auto-style11 {
            position: absolute;
            top: 112px;
            left: 158px;
            z-index: 1;
            width: 244px;
        }
        .auto-style12 {
            position: absolute;
            top: 115px;
            left: 413px;
            z-index: 1;
            width: 167px;
        }
        .auto-style13 {
            position: absolute;
            top: 145px;
            left: 414px;
            z-index: 1;
            width: 168px;
        }
    </style>
</head>
<body bgcolor="#000099">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" ForeColor="Yellow" Text="ThesisSerialNo:"></asp:Label>
            <asp:TextBox ID="T1" runat="server" CssClass="auto-style4" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" ForeColor="Yellow" TextMode="Number"></asp:TextBox>
            <asp:HyperLink ID="new1" runat="server" CssClass="auto-style13" ForeColor="Yellow" NavigateUrl="AddGrade.aspx" Visible="False">Add New Grade</asp:HyperLink>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style6" ForeColor="Yellow" Text="Add Grade"></asp:Label>
            <asp:Label ID="error1" runat="server" CssClass="auto-style8" Text="Field Requied!" ForeColor="#FF3300" Visible="False"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style9" ForeColor="Yellow" NavigateUrl="Supervisor.aspx">Home Page</asp:HyperLink>
            <asp:Button ID="Button1" runat="server" BackColor="#CCCCCC" BorderStyle="Solid" CssClass="auto-style11" OnClick="add" Text="Add" />
            <asp:Label ID="done" runat="server" CssClass="auto-style12" ForeColor="#FF3300" Text="New Graded Added" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
