<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supervisor_Profile.aspx.cs" Inherits="Website1.Supervisor_Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 354px;
            width: 1305px;
        }
        .auto-style2 {
            position: absolute;
            top: 149px;
            left: 59px;
            z-index: 1;
            width: 90px;
            height: 40px;
            font-size:30px;
        }
        .auto-style3 {
            position: absolute;
            top: 103px;
            left: 59px;
            z-index: 1;
            font-size:30px;
            width: 82px;
        }
        .auto-style4 {
            position: absolute;
            top: 192px;
            left: 58px;
            z-index: 1;
            font-size:30px;
            width: 99px;
            }
        .auto-style5 {
            position: absolute;
            top: 234px;
            left: 59px;
            z-index: 1;
            font-size:30px;
            width: 103px;
        }
        .auto-style10 {
            position: absolute;
            top: 26px;
            left: 428px;
            z-index: 1;
            font-size:50px;
            width: 474px;
        }
        .auto-style11 {
            position: absolute;
            top: 22px;
            left: 18px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 116px;
            left: 484px;
            z-index: 1;
        }
        .auto-style13 {
            position: absolute;
            top: 115px;
            left: 720px;
            z-index: 1;
            width: 335px;
            right: 87px;
        }
        .auto-style15 {
            position: absolute;
            top: 286px;
            left: 375px;
            z-index: 1;
            width: 211px;
        }
        .auto-style17 {
            position: absolute;
            top: 161px;
            left: 962px;
            z-index: 1;
            width: 107px;
        }
        .auto-style18 {
            position: absolute;
            top: 153px;
            left: 406px;
            z-index: 1;
        }
        .auto-style19 {
            position: absolute;
            top: 199px;
            left: 411px;
            z-index: 1;
        }
        .auto-style20 {
            position: absolute;
            top: 162px;
            left: 812px;
            z-index: 1;
            width: 129px;
        }
        .auto-style21 {
            position: absolute;
            top: 89px;
            left: 874px;
            z-index: 1;
        }
        .auto-style22 {
            position: absolute;
            top: 89px;
            z-index: 1;
            left: 701px;
        }
        .auto-style24 {
            position: absolute;
            top: 288px;
            left: 163px;
            z-index: 1;
            width: 195px;
        }
        .auto-style25 {
            position: absolute;
            top: 239px;
            left: 176px;
            z-index: 1;
            width: 343px;
        }
        .auto-style26 {
            position: absolute;
            top: 110px;
            left: 174px;
            z-index: 1;
            width: 222px;
        }
        .auto-style27 {
            position: absolute;
            top: 156px;
            left: 174px;
            z-index: 1;
            width: 129px;
        }
        .auto-style28 {
            position: absolute;
            top: 201px;
            left: 174px;
            z-index: 1;
            width: 209px;
            height: 20px;
        }
        .auto-style29 {
            position: absolute;
            top: 155px;
            left: 156px;
            z-index: 1;
            width: 225px;
        }
        .auto-style30 {
            position: absolute;
            top: 198px;
            left: 163px;
            z-index: 1;
            width: 228px;
            right: 391px;
        }
        .auto-style31 {
            position: absolute;
            top: 117px;
            left: 1076px;
            z-index: 1;
        }
        .auto-style32 {
            position: absolute;
            top: 115px;
            left: 1122px;
            z-index: 1;
            height: 22px;
        }
        .auto-style34 {
            position: absolute;
            top: 117px;
            left: 1076px;
            z-index: 1;
            width: 22px;
            height: 19px;
        }
    </style>
</head>
<body bgcolor="#000099">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label2" runat="server" CssClass="auto-style3" ForeColor="Yellow" Text="ID:"></asp:Label>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" ForeColor="Yellow" Text="Name:"></asp:Label>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style4" ForeColor="Yellow" Text="Faculty:"></asp:Label>
            <asp:Label ID="Label4" runat="server" CssClass="auto-style5" ForeColor="Yellow" Text="Email:"></asp:Label>
            <asp:TextBox ID="N1" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style29" ForeColor="Yellow" MaxLength="20" Visible="False"></asp:TextBox>
            <asp:Label ID="T1" runat="server" CssClass="auto-style26" ForeColor="Yellow" Text="MyID"></asp:Label>
            <asp:Label ID="Label5" runat="server" CssClass="auto-style10" ForeColor="Yellow" Text="Personal Information"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style11" ForeColor="Yellow" NavigateUrl="Supervisor.aspx">Home Page</asp:HyperLink>
            <asp:Label ID="checkLabel" runat="server" CssClass="auto-style12" ForeColor="#FF3300" Text="Please Enter Your Password:" Visible="False"></asp:Label>
            <asp:TextBox ID="password" runat="server" CssClass="auto-style13" TextMode="Password" Visible="False"></asp:TextBox>
            <asp:Button ID="edit1" runat="server" BackColor="#CCCCCC" BorderStyle="Solid" CssClass="auto-style15" OnClick="edit" Text="Edit" />
            <asp:Button ID="ok1" runat="server" BackColor="#CCCCCC" BorderStyle="Solid" CssClass="auto-style17" OnClick="ok" Text="Ok" Visible="False" />
            <asp:Label ID="newName" runat="server" CssClass="auto-style18" ForeColor="#FF3300" Text="Please Enter New Name" Visible="False"></asp:Label>
            <asp:Label ID="newFaculty" runat="server" CssClass="auto-style19" ForeColor="#FF3300" Text="Please Enter New Faculty" Visible="False"></asp:Label>
            <asp:Button ID="cancel1" runat="server" BackColor="#CCCCCC" BorderStyle="Solid" CssClass="auto-style20" ForeColor="Black" OnClick="cancel" Text="Cancel" Visible="False" />
            <asp:Label ID="error1" runat="server" CssClass="auto-style21" ForeColor="#FF3300" Text="Please Enter Password!" Visible="False"></asp:Label>
            <asp:Label ID="wrong" runat="server" CssClass="auto-style22" ForeColor="#FF3300" Text="InCorrect Password!" Visible="False"></asp:Label>
            <asp:Button ID="save1" runat="server" CssClass="auto-style24" OnClick="save" Text="Save" BackColor="#CCCCCC" Visible="False" />
            <asp:Label ID="T4" runat="server" CssClass="auto-style25" Text="MyEmail" ForeColor="Yellow"></asp:Label>
            <asp:Label ID="T2" runat="server" CssClass="auto-style27" ForeColor="Yellow" Text="MyName"></asp:Label>
            <asp:TextBox ID="N2" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style30" ForeColor="Yellow" MaxLength="20" Visible="False"></asp:TextBox>
            <asp:Label ID="T3" runat="server" CssClass="auto-style28" ForeColor="Yellow" Text="MyFaculty"></asp:Label>
            <input id="Checkbox2" Visible="False" class="auto-style31" onchange="document.getElementById('password').type = this.checked ? 'text' : 'password'" type="checkbox" /><asp:Label ID="CheckBox1" runat="server" CssClass="auto-style32" ForeColor="Yellow" Text="Show Password" Visible="False"></asp:Label>
            <asp:Label ID="hide" runat="server" BackColor="#000099" CssClass="auto-style34" ForeColor="#000099" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
