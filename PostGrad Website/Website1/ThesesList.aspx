<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThesesList.aspx.cs" Inherits="Website1.ThesesList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{ background-color: #FFF5EE;
             color:#DC143C;
             font-weight:bold;
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
     table,td,th{
         color:#00008B;
         
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

            .button:hover {
  background-color: #20B2AA
; 
  color: white;
}

        table {
          font-family: arial, sans-serif;
          border-collapse: collapse;
          width: 70%;
        }

        td, th {
          border: 1px solid #dddddd;
          text-align: left;
          padding: 8px;
        }

        tr:nth-child(even) {
          background-color: #dddddd;
        }
    </style>
</head>
<body>
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
    <form id="form1" style="margin-left: 430px" runat="server">
        &nbsp;<br />
        <br />
        
        <br />
        <asp:Label ID="Label1" runat="server" Text="Count Ongoing Theses"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" style="margin-left:300px;" Text="Update Number Of Thesis Extension by 1"></asp:Label>
        <br />
        <br />
       
        <asp:Button ID="Button1" CssClass="button" style="margin-right:100px" runat="server" Text="Count" OnClick="OnCount" />
       
        <asp:TextBox ID="SerialBox" runat="server" TextMode="Number" placeholder="Thesis Serial Num" OnTextChanged="TextBox1_TextChanged" style="margin-left: 333px"></asp:TextBox>

        <asp:Button ID="Button2" CssClass="button" runat="server" style="margin-left: 46px" OnClick="OnUpdate" Text="Update" />
        <div style="margin-left: 400px">
        </div>
        <br />
        <br />
        
        
        

        
    </form>
    </body>
</html>
