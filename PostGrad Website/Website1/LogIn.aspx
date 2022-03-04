<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Website1.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            background-color:#2F4F4F;
            color:#FFEBCD;
            
            
        }

        
        
        
        .button {
  background-color: #4CAF50; 
  border: none;
  color: white;
  padding: 12px 28px;
  text-align: center;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  position: absolute;
            top: 351px;
            left: 277px;
            z-index: 1;
            width: 171px;
}

        

        .button:hover {
  background-color: #3e8e41; 
  color: white;
}
       
        .auto-style1 {
            height: 462px;
        }
        .auto-style2 {
            position:absolute;
            top: 137px;
            left: 280px;
            z-index: 1;
            height: 32px;
        }
        .auto-style3 {
            position: absolute;
            top: 145px;
            left: 185px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 184px;
            left: 281px;
            z-index: 1;
            height: 29px;
        }
        .auto-style5 {
            position: absolute;
            top: 190px;
            left: 191px;
            z-index: 1;
            height: 22px;
        }
        .auto-style6 {
            position: absolute;
            top: 351px;
            left: 277px;
            z-index: 1;
            width: 171px;
        }
        .auto-style7 {
            width: 118px;
            height: 28px;
            position: absolute;
            top: 238px;
            left: 284px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 274px;
            left: 185px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 421px;
            left: 307px;
            z-index: 1;
            height: 22px;
            width: 62px;
        }
        .auto-style11 {
            position: absolute;
            top: 421px;
            left: 189px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 101px;
            left: 299px;
            z-index: 1;
        }
        .auto-style13 {
            position: absolute;
            top: 421px;
            left: 403px;
            z-index: 1;
        }
        .auto-style14 {
            color:darkred;
            position: absolute;
            top: 456px;
            left: 182px;
            z-index: 1;
            height: 23px;
            right: 577px;
        }
        .auto-style15 {
            color:darkred;
            position: absolute;
            top: 271px;
            left: 414px;
            z-index: 1;
        }
        .auto-style16 {
            color:darkred;
            position: absolute;
            top: 143px;
            left: 460px;
            z-index: 1;
            width: 173px;
            height: 28px;
        }
        .auto-style17 {
            color:darkred;
            position: absolute;
            top: 187px;
            left: 460px;
            z-index: 1;
            width: 225px;
        }
        .auto-style19 {
            position: absolute;
            top: 421px;
            left: 537px;
            z-index: 1;
            right: 848px;
        }
        #Required_Label,#Label6,#Label7,#Incorrect_Label{
            margin-left:20px;
            color:#FA8072;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" >
           <asp:TextBox ID="UserName" TextMode="Number" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Text="Username:"></asp:Label>
            <asp:TextBox ID="Password" MaxLength="20" Type="password" runat="server" CssClass="auto-style4"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" CssClass="auto-style5" Text="Password:"></asp:Label>
            <asp:RadioButtonList ID="Type" runat="server" CssClass="auto-style7" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem ID="Admin">Admin</asp:ListItem>
                <asp:ListItem ID="Supervisor">Supervisor</asp:ListItem>
                <asp:ListItem ID="Examiner">Examiner</asp:ListItem>
                <asp:ListItem ID="Student">Student</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="Signin" CssClass="button" runat="server"  OnClick="LogIN" Text="Login"  /><br />
            <asp:Label ID="Label3" runat="server" CssClass="auto-style8" Text="Login As:"></asp:Label>
            <asp:HyperLink ID="HyperLink3" runat="server"  NavigateUrl="Student_Register.aspx" CssClass="auto-style10">Student</asp:HyperLink>
            <asp:Label ID="Label4" runat="server" CssClass="auto-style11" Text="New User?"></asp:Label>
            <asp:Label ID="Label5" runat="server" CssClass="auto-style12" Text="Please Login"></asp:Label>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="Supervisor_Register.aspx" CssClass="auto-style13">Supervisor</asp:HyperLink>
            <asp:Label ID="Incorrect_Label" runat="server" CssClass="auto-style14" Text=""></asp:Label>
            
            <asp:Label ID="Required_Label" visible="false" runat="server" CssClass="auto-style15" Text="Field Required!"></asp:Label>
            
            <asp:Label ID="Label6" visible="false" runat="server" CssClass="auto-style16" Text="Field Required!"></asp:Label>
            <asp:Label ID="Label7" visible="false" runat="server" CssClass="auto-style17" Text="Field Required!"></asp:Label>
            
            
            
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="ExaminerRegister.aspx" CssClass="auto-style19">Examiner</asp:HyperLink>
            
            
            
        </div>
    </form>
</body>
</html>
