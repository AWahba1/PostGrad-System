<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="Website1.StudentProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{ background-color: #FFF5EE;
             color:#DC143C;
             font-weight: bold;
        }

        .button { 
    background-color: #2F4F4F	  ; 
  border: none;
  color: white;
  padding: 5px 5px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 14px;
}

        .button:hover {
  background-color: #20B2AA
; 
  color: white;
}
            .sidenav {
      height: 100%;
      width: 20%; 
      position: fixed; 
      z-index: 1; 
      top: 0; 
      left: 0;
      background-color: #111;
      
      overflow-x: hidden; 
      padding-top: 60px; 
      transition: 0.5s; 
    }

    
    
    .sidenav a {
      padding: 20px 8px 8px 32px;
      text-decoration: none;
      font-size: 21px;
      color: #818181;
      display: block;
      transition: 0.3s;
    }

    
    .sidenav a:hover {
      color: #DAA520;
      
    }

    

  


    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div id="mySidenav" class="sidenav">
  
          <a href="SupervisorsList.aspx">Supervisors List</a>
          <a href="ThesesList.aspx">Theses List</a>
         <a href="Courses.aspx">Courses</a>
          <a href="StudentThesisSupervisor.aspx">Student Thesis Supervisor</a>
          <a href="NonGucianCourse.aspx">Courses by Non-gucians</a>
         <a href="Payment.aspx">Issue Payments</a>
         <a href="Installment.aspx">Issue Installments</a>
         <a href="StudentProfile.aspx">View Student Profile</a>
         <a href="SupervisorProfile.aspx">View Supervisor Profile</a>
         <a href="AcceptedPublication.aspx">Accepted Publication List</a>
         <a href="ExaminerDefense.aspx">Examiners & Defense</a>
          </div>

        <div style="margin-left: 480px">
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Student ID" Width="355px"></asp:TextBox>
        </div>
        <p style="margin-left: 480px">
            <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="Button1_Click" Text="View Profile" />
        </p>
        <p style="margin-left: 480px">
            &nbsp;</p>
        <p style="margin-left: 480px">
            <asp:Label ID="Error" style="color:red" Font-Bold runat="server" Textmode="Number" Visible="false" Text="There is no student with this ID"></asp:Label>
            
        </p>

        
              <p style="margin-left: 480px">
            <asp:Label ID="IDLabel" runat="server" Text=""></asp:Label>
            </p>
        <p style="margin-left: 480px">
            <asp:Label ID="FirstNameLabel" runat="server" Text=""></asp:Label>
            </p>
        <p style="margin-left: 480px">
            <asp:Label ID="LastNameLabel" runat="server" Text=""></asp:Label>
            </p>
        <p style="margin-left: 480px">
            <asp:Label ID="EmailLabel" runat="server" Text=""></asp:Label>
            </p>
        <p style="margin-left: 480px">
            <asp:Label ID="PasswordLabel" runat="server" Text=""></asp:Label>
            </p>
         <p style="margin-left: 480px">
            <asp:Label ID="TypeLabel" runat="server" Text=""></asp:Label>
            </p>
        <p style="margin-left: 480px">
            <asp:Label ID="FacultyLabel" runat="server" Text=""></asp:Label>
            </p>
        <p style="margin-left: 480px">
            <asp:Label ID="AddressLabel" runat="server" Text=""></asp:Label>
            </p>
        <p style="margin-left: 480px">
            <asp:Label ID="GPALabel" runat="server" Text=""></asp:Label>
            </p>


    </form>
</body>
</html>
