<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyStudents.aspx.cs" Inherits="Website1.MyStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 17px;
            left: 14px;
            z-index: 1;
            height: 26px;
            width: 90px;
        }
        .auto-style2 {
            height: 29px;
        }
    </style>
</head>
<body bgcolor="#000099">
    <form id="form1" runat="server">
        <div class="auto-style2">
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style1" NavigateUrl="Supervisor.aspx" ForeColor="Yellow">Home Page</asp:HyperLink>
    </form>
</body>
</html>
