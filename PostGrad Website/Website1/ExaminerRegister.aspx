<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerRegister.aspx.cs" Inherits="Website1.ExaminerRegister" %>

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
                   <asp:Label ID="name1" runat="server"  Text="First Name"></asp:Label><br />

                <asp:TextBox ID="name" CssClass="TextBox" placeholder="Enter First Name" Width="300px" MaxLength="50" runat="server" ></asp:TextBox>
               <asp:Label ID="l1" runat="server" CssClass="labels" Text=""></asp:Label><br />

            </p>

            <p>
              <asp:Label ID="password1" runat="server"  Text="Password"></asp:Label><br />
            <asp:TextBox ID="password" CssClass="TextBox" placeholder="Enter Password" Width="300px" type="password" MaxLength="20" runat="server" ></asp:TextBox>
             <asp:Label ID="l2" runat="server" CssClass="labels" Text=""></asp:Label>

            </p>



            <p>     
            <asp:Label ID="Label1" runat="server"  Text="Repeat Password"></asp:Label><br />

            <asp:TextBox ID="RepPassBox" CssClass="TextBox" Width="300px"  type="password"  placeholder="Enter Repeated Password"  MaxLength="20" runat="server" ></asp:TextBox>
            <asp:Label ID="RepPassLab" runat="server" CssClass="labels" Text=""></asp:Label><br />

            </p>
            <p>     
           <asp:Label ID="fieldOfWork1" runat="server"  Text="Field Of Work"></asp:Label><br />

             <asp:TextBox ID="fieldOfWork" CssClass="TextBox" placeholder="Enter Field of Work" Width="300px" MaxLength="20" runat="server"></asp:TextBox>

                <asp:Label ID="l3" runat="server" CssClass="labels" Text=""></asp:Label>
            
            </p>

            <p>     
               <asp:Label ID="email1" runat="server"  Text="Email"></asp:Label><br />

               <asp:TextBox ID="email" CssClass="TextBox" placeholder="Enter Email" Width="300px" MaxLength="50" runat="server" ></asp:TextBox>
                <asp:Label ID="l4" runat="server" CssClass="labels" Text=""></asp:Label>
            

            </p>

            

            <p>    
            <asp:CheckBox ID="CheckBox" runat="server"  Text="Please tick if National"  />

            </p>
            <p style="margin-left: 80px">
               <asp:Button ID="Submit" runat="server" CssClass="button" OnClick="Register" Text="Submit" />

            </p>
        </div>
    </form>
</body>
</html>
