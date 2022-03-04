<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgressReportEvaluation.aspx.cs" Inherits="Website1.ProgressReportEvaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 385px;
            width: 1256px;
        }
        .auto-style3 {
            position: absolute;
            top: 102px;
            left: 71px;
            z-index: 1;
            height: 23px;
        }
        .auto-style4 {
            position: absolute;
            top: 139px;
            left: 48px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 175px;
            left: 102px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 233px;
            left: 200px;
            z-index: 1;
            width: 207px;
        }
        .auto-style9 {
            position: absolute;
            top: 101px;
            left: 206px;
            z-index: 1;
            width: 193px;
        }
        .auto-style10 {
            position: absolute;
            top: 140px;
            z-index: 1;
            left: 203px;
            width: 194px;
        }
        .auto-style11 {
            position: absolute;
            top: 177px;
            z-index: 1;
            left: 201px;
            width: 196px;
        }
        .auto-style12 {
            position: absolute;
            top: 18px;
            left: 437px;
            z-index: 1;
            font-size:35px;
        }
        .auto-style13 {
            position: absolute;
            top: 178px;
            left: 413px;
            z-index: 1;
            width: 131px;
        }
        .auto-style15 {
            position: absolute;
            top: 101px;
            left: 415px;
            z-index: 1;
            width: 144px;
        }
        .auto-style16 {
            position: absolute;
            top: 143px;
            left: 417px;
            z-index: 1;
            width: 134px;
        }
        .auto-style17 {
            position: absolute;
            top: 207px;
            left: 118px;
            z-index: 1;
            width: 301px;
            right: 519px;
        }
        .auto-style18 {
            position: absolute;
            top: 235px;
            left: 444px;
            z-index: 1;
            width: 209px;
        }
        .auto-style19 {
            position: absolute;
            top: 232px;
            left: 673px;
            z-index: 1;
        }
        .auto-style20 {
            position: absolute;
            top: 23px;
            left: 17px;
            z-index: 1;
        }
        .auto-style21 {
            position: absolute;
            top: 136px;
            left: 599px;
            z-index: 1;
            width: 652px;
            height: 48px;
            font-size:30px;
        }
    </style>
</head>
<body bgcolor="#000099">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label4" runat="server" CssClass="auto-style5" ForeColor="Yellow" Text="Evaluation:"></asp:Label>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style4" ForeColor="Yellow" Text="ProgressReportNo:"></asp:Label>
            <asp:Label ID="Label2" runat="server" CssClass="auto-style3" ForeColor="Yellow" Text="ThesisSerialNo:"></asp:Label>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style7" OnClick="Evaluate" Text="Evaluate" BackColor="#CCCCCC" BorderStyle="Solid" />
            <asp:TextBox ID="T2" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style9" ForeColor="Yellow" TextMode="Number"></asp:TextBox>
            <asp:TextBox ID="T3" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style10" ForeColor="Yellow" TextMode="Number"></asp:TextBox>
            <asp:TextBox ID="T4" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style11" ForeColor="Yellow" TextMode="Number"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" CssClass="auto-style12" ForeColor="Yellow" Text="Progress Report Evaluation"></asp:Label>
            <asp:Label ID="error2" runat="server" CssClass="auto-style15" Text="Field Requied!" ForeColor="#FF3300" Visible="False"></asp:Label>
            
            <asp:Label ID="error3" runat="server" CssClass="auto-style16" Text="Field Requied!" ForeColor="#FF3300" Visible="False"></asp:Label>
            <asp:Label ID="error4" runat="server" CssClass="auto-style13" ForeColor="#FF3300" Text="Field Requied!" Visible="False"></asp:Label>
            <asp:Label ID="error5" runat="server" CssClass="auto-style17" ForeColor="#FF3300" Text="Evaluation Value From 0 To 3 Only!" Visible="False"></asp:Label>
            <asp:Label ID="done" runat="server" CssClass="auto-style18" ForeColor="#FF3300" Text="ProgressReportEvaluated" Visible="False"></asp:Label>
            <asp:HyperLink ID="new1" runat="server" CssClass="auto-style19" ForeColor="Yellow" NavigateUrl="ProgressReportEvaluation.aspx" Visible="False">Evaluate New One</asp:HyperLink>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style20" ForeColor="Yellow" NavigateUrl="Supervisor.aspx">Home Page</asp:HyperLink>
            <asp:Label ID="error1" runat="server" CssClass="auto-style21" ForeColor="#FF3300" Text="Error" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
