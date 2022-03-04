<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddExaminer.aspx.cs" Inherits="Website1.AddExaminer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 500px;
            width: 1143px;
        }
        .auto-style2 {
            position: absolute;
            top: 30px;
            left: 509px;
            z-index: 1;
            font-size: 40px;
        }
        .auto-style3 {
            position: absolute;
            top: 16px;
            left: 16px;
            z-index: 1;
            height: 21px;
        }
        .auto-style4 {
            position: absolute;
            top: 149px;
            left: 12px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 181px;
            left: 30px;
            z-index: 1;
            height: 27px;
        }
        .auto-style6 {
            position: absolute;
            top: 218px;
            left: 18px;
            z-index: 1;
            width: 109px;
            height: 25px;
        }
        .auto-style8 {
            position: absolute;
            top: 248px;
            left: 30px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 148px;
            left: 145px;
            z-index: 1;
            width: 239px;
        }
        .auto-style11 {
            position: absolute;
            top: 217px;
            left: 146px;
            z-index: 1;
            width: 241px;
        }
        .auto-style12 {
            position: absolute;
            top: 246px;
            left: 148px;
            z-index: 1;
            width: 240px;
            right: 549px;
        }
        .auto-style13 {
            position: absolute;
            top: 312px;
            left: 43px;
            z-index: 1;
            height: 22px;
        }
        .auto-style14 {
            position: absolute;
            top: 150px;
            left: 404px;
            z-index: 1;
        }
        .auto-style15 {
            position: absolute;
            top: 185px;
            left: 404px;
            z-index: 1;
            width: 122px;
        }
        .auto-style16 {
            position: absolute;
            top: 219px;
            left: 402px;
            z-index: 1;
            width: 124px;
            height: 23px;
        }
        .auto-style17 {
            position: absolute;
            top: 244px;
            left: 407px;
            z-index: 1;
            width: 139px;
            bottom: 16px;
        }
        .auto-style18 {
            position: absolute;
            top: 305px;
            left: 145px;
            z-index: 1;
            width: 171px;
        }
        .auto-style19 {
            position: absolute;
            top: 313px;
            left: 335px;
            z-index: 1;
            width: 179px;
            right: 195px;
        }
        .auto-style20 {
            position: absolute;
            top: 346px;
            left: 338px;
            z-index: 1;
        }
        .auto-style21 {
            position: absolute;
            top: 183px;
            left: 143px;
            z-index: 1;
            width: 242px;
        }
        .auto-style22 {
            position: absolute;
            top: 274px;
            left: 53px;
            z-index: 1;
            width: 88px;
            height: 21px;
        }
        .auto-style23 {
            position: absolute;
            top: 276px;
            left: 146px;
            z-index: 1;
            width: 242px;
            right: 313px;
        }
        .auto-style24 {
            position: absolute;
            top: 275px;
            left: 570px;
            z-index: 1;
            width: 131px;
        }
        .auto-style25 {
            position: absolute;
            top: 278px;
            left: 404px;
            z-index: 1;
        }
        .auto-style26 {
            position: absolute;
            top: 275px;
            left: 434px;
            z-index: 1;
        }
    </style>
</head>
<body bgcolor="#000099">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" ForeColor="Yellow" Text="Add New Examiner"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style3" ForeColor="Yellow" NavigateUrl="Supervisor.aspx">Home Page</asp:HyperLink>
            <asp:Label ID="Label2" runat="server" CssClass="auto-style4" ForeColor="Yellow" Text="ThesisSerialNo:"></asp:Label>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style5" ForeColor="Yellow" Text="DefenseDate:"></asp:Label>
            <asp:Label ID="Label4" runat="server" CssClass="auto-style6" ForeColor="Yellow" Text="ExaminerName:"></asp:Label>
            <asp:Label ID="Label6" runat="server" CssClass="auto-style8" ForeColor="Yellow" Text="FieldOfWork:"></asp:Label>
            <asp:TextBox ID="T1" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style9" ForeColor="Yellow" TextMode="Number"></asp:TextBox>
            <asp:TextBox ID="T3" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style11" ForeColor="Yellow" MaxLength="20"></asp:TextBox>
            <asp:TextBox ID="T4" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style12" ForeColor="Yellow" MaxLength="20" ></asp:TextBox>
            <asp:CheckBox ID="CheckBox1" runat="server" BorderStyle="None" CssClass="auto-style13" ForeColor="Yellow" Text="National?" TextAlign="Left" />
            <asp:Label ID="error1" runat="server" CssClass="auto-style14" ForeColor="#FF3300" Text="Field Required!" Visible="False"></asp:Label>
            <asp:Label ID="error2" runat="server" CssClass="auto-style15" ForeColor="#FF3300" Text="Field Requied!" Visible="False"></asp:Label>
            <asp:Label ID="error3" runat="server" CssClass="auto-style16" ForeColor="#FF3300" Text="Field Requied!" Visible="False"></asp:Label>
            <asp:Label ID="error4" runat="server" CssClass="auto-style17" ForeColor="#FF3300" Text="Field Requied!" Visible="False"></asp:Label>
            <asp:Button ID="Add1" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Solid" CssClass="auto-style18" Text="Add" OnClick="Add" />
            <asp:Label ID="done" runat="server" CssClass="auto-style19" ForeColor="#FF3300" Text="New Examiner Added" Visible="False"></asp:Label>
            <asp:HyperLink ID="new1" runat="server" CssClass="auto-style20" ForeColor="Yellow" NavigateUrl="AddExaminer.aspx" Visible="False">Add New Examiner</asp:HyperLink>
            <asp:TextBox ID="T2" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style21" ForeColor="Yellow" placeholder="Year-Month-Day" TextMode="Date"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" CssClass="auto-style22" ForeColor="Yellow" Text="Password:"></asp:Label>
            <asp:TextBox ID="T5" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style23" ForeColor="Yellow" TextMode="Password"></asp:TextBox>
            <asp:Label ID="error5" runat="server" CssClass="auto-style24" ForeColor="#FF3300" Text="Field Required!" Visible="False"></asp:Label>
            <input id="Checkbox2" class="auto-style25" onchange="document.getElementById('T5').type = this.checked ? 'text' : 'password'" type="checkbox" /><asp:Label ID="Label8" runat="server" CssClass="auto-style26" ForeColor="Yellow" Text="Show Password"></asp:Label>
        </div>
    </form>
</body>
</html>
