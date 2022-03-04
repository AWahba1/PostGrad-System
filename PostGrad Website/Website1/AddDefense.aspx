<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDefense.aspx.cs" Inherits="Website1.AddDefense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 334px;
            width: 1081px;
        }
        .auto-style2 {
            position: absolute;
            top: 75px;
            left: 77px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 109px;
            left: 88px;
            z-index: 1;
            height: 21px;
            width: 112px;
        }
        .auto-style4 {
            position: absolute;
            top: 146px;
            left: 79px;
            z-index: 1;
            height: 25px;
        }
        .auto-style5 {
            position: absolute;
            top: 203px;
            left: 80px;
            z-index: 1;
        }
        .auto-style6 {
            width: 126px;
            height: 28px;
            position: absolute;
            top: 199px;
            left: 181px;
            z-index: 1;
            right: 631px;
        }
        .auto-style8 {
            position: absolute;
            top: 151px;
            left: 543px;
            z-index: 1;
            width: 132px;
        }
        .auto-style9 {
            position: absolute;
            top: 150px;
            left: 222px;
            z-index: 1;
            width: 309px;
        }
        .auto-style10 {
            position: absolute;
            top: 110px;
            left: 222px;
            z-index: 1;
            width: 307px;
            right: 401px;
        }
        .auto-style11 {
            position: absolute;
            top: 74px;
            left: 220px;
            z-index: 1;
            width: 306px;
        }
        .auto-style12 {
            position: absolute;
            top: 112px;
            left: 544px;
            z-index: 1;
            height: 22px;
            width: 131px;
            bottom: 144px;
        }
        .auto-style13 {
            position: absolute;
            top: 76px;
            left: 537px;
            z-index: 1;
            width: 133px;
        }
        .auto-style14 {
            position: absolute;
            top: 216px;
            left: 316px;
            z-index: 1;
            width: 126px;
        }
        .auto-style15 {
            position: absolute;
            top: 298px;
            left: 218px;
            z-index: 1;
            width: 319px;
            right: 401px;
        }
        .auto-style16 {
            position: absolute;
            top: 17px;
            left: 185px;
            z-index: 1;
            width: 540px;
            height: 41px;
            font-size: 40px;
        }
        .auto-style17 {
            position: absolute;
            top: 239px;
            left: 612px;
            z-index: 1;
            width: 197px;
        }
        .auto-style20 {
            position: absolute;
            top: 269px;
            left: 613px;
            z-index: 1;
            width: 177px;
        }
        .auto-style21 {
            position: absolute;
            top: 20px;
            left: 18px;
            z-index: 1;
            width: 169px;
        }
        .auto-style22 {
            position: absolute;
            top: 185px;
            left: 507px;
            z-index: 1;
            width: 528px;
            height: 40px;
            font-size: 30px;
        }
    </style>
</head>
<body bgcolor="#000099">
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:TextBox ID="DL" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style9" MaxLength="15" ForeColor="Yellow"></asp:TextBox>
            <asp:HyperLink ID="home" runat="server" CssClass="auto-style21" ForeColor="Yellow" NavigateUrl="Supervisor.aspx">Home Page</asp:HyperLink>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="ThesisSerialNo:" ForeColor="Yellow"></asp:Label>
            <asp:Label ID="Label2" runat="server" CssClass="auto-style3" ForeColor="Yellow" Text="DefenseDate:"></asp:Label>
            <asp:TextBox ID="DD" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style10" placeholder="Year-Month-Day" TextMode="Date" ForeColor="Yellow"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style4" ForeColor="Yellow" Text="DefenseLocation:"></asp:Label>
            <asp:Label ID="Label4" runat="server" CssClass="auto-style5" ForeColor="Yellow" Text="Defense for:"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="auto-style6" Font-Bold="True" ForeColor="Yellow">
                <asp:ListItem ID="Gucian">Gucian</asp:ListItem>
                <asp:ListItem ID="NonGucian">NonGucian</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="error3" runat="server" CssClass="auto-style8" ForeColor="#FF3300" Text="Field Required!" Visible="False"></asp:Label>
            <asp:Label ID="error5" runat="server" CssClass="auto-style22" ForeColor="#FF3300" Text="Error" Visible="False"></asp:Label>
            <asp:TextBox ID="tsn" runat="server" BackColor="#000099" BorderColor="Yellow" BorderStyle="Solid" CssClass="auto-style11" TextMode="Number" ForeColor="Yellow"></asp:TextBox>
            <asp:Label ID="error2" runat="server" CssClass="auto-style12" ForeColor="#FF3300" Text="Field Required!" Visible="False"></asp:Label>
            <asp:Label ID="error1" runat="server" CssClass="auto-style13" ForeColor="#FF3300" Text="Field Required!" Visible="False"></asp:Label>
            <asp:Label ID="error4" runat="server" CssClass="auto-style14" ForeColor="#FF3300" Text="Field Required!" Visible="False"></asp:Label>
            <asp:Button ID="submit" runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Double" CssClass="auto-style15" ForeColor="Black" Text="Submit" OnClick="Submit" />
            <asp:Label ID="Label6" runat="server" CssClass="auto-style16" ForeColor="Yellow" Text="Please Enter Defense Details"></asp:Label>
            <asp:Label ID="done" runat="server" CssClass="auto-style17" ForeColor="#FF3300" Text="New Defense Added!" Visible="False"></asp:Label>
            <asp:HyperLink ID="AddNew" runat="server" CssClass="auto-style20" ForeColor="Yellow" NavigateUrl="AddDefense.aspx" Visible="False">Add New Defense</asp:HyperLink>

        </div>
    </form>
</body>
</html>
