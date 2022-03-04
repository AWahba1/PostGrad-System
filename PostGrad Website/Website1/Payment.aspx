<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Website1.PaymentsInstallments" %>

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
        <div style="margin-left: 480px; margin-top:90px; height: 758px;">
            <br />
            <asp:Label runat="server"  Text="Thesis Serial Number:"></asp:Label>
           <asp:TextBox ID="SerialLabel" TextMode="Number" runat="server" style="margin-left: 242px"></asp:TextBox>
          
            
            <br />
            <br />
            <asp:Label runat="server"  Text="Amount:"></asp:Label>
            <asp:TextBox ID="AmountLabel"  style="margin-left: 333px" runat="server"  ></asp:TextBox>
            <br />
            <br />
            <asp:Label  runat="server"  Text="Number Of Installments:"></asp:Label>
            <asp:TextBox ID="numOfInstallmentsLabel"  style="margin-left: 224px" TextMode="Number" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server"  Text="Fund Percentage:"></asp:Label>
            <asp:TextBox ID="fundPercLabel" runat="server" style="margin-left: 275px"></asp:TextBox>
          
            
            <br />
            <br />
            <asp:Label ID="Error" runat="server" style="margin-left: 145px; color:red;" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" CssClass="button" runat="server" style="margin-left: 152px" Text="Issue Payment"  OnClick="OnIssue" Width="155px" />
          
            
        </div>
    </form>
</body>
</html>
