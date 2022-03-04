<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supervisor_Register.aspx.cs" Inherits="Website1.Supervisor_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .container{
            margin-left:550px;
            margin-top:70px;
        }

        .TextBox{
            
  padding: 6px;
  margin-top:12px;
        }
        .labels{
            margin-left:20px;
            color:#FA8072;
        }
        body{
            background-color:#2F4F4F;
            color:#FFEBCD;
            font-weight:bold;
            
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

  
}

        .button:hover {
  background-color: #3e8e41; 
  color: white;
}
    </style>
</head>
<body>
     <form id="form1" runat="server">
        <div class="container">
            <p>     
                            <asp:Label ID="first_Name1" runat="server" CssClass="auto-style9" Text="First Name"></asp:Label><br />

                <asp:TextBox ID="first_Name" MaxLength="20" placeholder="Enter First Name" runat="server" Width="300px" CssClass="TextBox"></asp:TextBox>
               <asp:Label ID="l1" runat="server" CssClass="labels" Text=""></asp:Label><br />

            </p>

            <p>     
            <asp:Label ID="last_Name1" runat="server" CssClass="auto-style10" Text="Last Name"></asp:Label><br />

            <asp:TextBox ID="last_Name" CssClass="TextBox" MaxLength="20" Width="300px" placeholder="Enter Last Name"  runat="server" ></asp:TextBox>
            <asp:Label ID="l2" runat="server" CssClass="labels" Text=""></asp:Label><br />

            </p>

            <p>     
            <asp:Label ID="password1" runat="server" CssClass="auto-style11" Text="Password"></asp:Label><br />

            <asp:TextBox ID="password" CssClass="TextBox" type="password" Width="300px" placeholder="Enter Password"  MaxLength="20" runat="server" ></asp:TextBox>
            <asp:Label ID="l3" runat="server" CssClass="labels" Text=""></asp:Label><br />

            </p>
            <p>     
            <asp:Label ID="Label1" runat="server" CssClass="auto-style11" Text="Repeat Password"></asp:Label><br />

            <asp:TextBox ID="RepPassBox" CssClass="TextBox" type="password" Width="300px" placeholder="Enter Repeated Password"  MaxLength="20" runat="server" ></asp:TextBox>
            <asp:Label ID="RepPassLab" runat="server" CssClass="labels" Text=""></asp:Label><br />

            </p>

            <p>     
                            <asp:Label ID="faculty1" runat="server" CssClass="auto-style12" Text="Faculty"></asp:Label><br />

            <asp:TextBox ID="faculty" CssClass="TextBox" MaxLength="20" Width="300px" placeholder="Enter Faculty"  runat="server" ></asp:TextBox>
            <asp:Label ID="l4" runat="server" CssClass="labels" Text=""></asp:Label><br />

            </p>

            <p>     
                            <asp:Label ID="email1" runat="server" CssClass="auto-style14" Text="Email"></asp:Label><br />

            <asp:TextBox ID="email" CssClass="TextBox" Width="300px" MaxLength="50"   placeholder="Enter Email" runat="server" ></asp:TextBox>
            <asp:Label ID="l5" runat="server" CssClass="labels" Text=""></asp:Label><br />

            </p>


            <p style="margin-left: 80px">
                            <asp:Button ID="Submit" runat="server" CssClass="button" OnClick="Register" Text="Submit" />

            </p>
        </div>
    </form>
</body>
</html>
