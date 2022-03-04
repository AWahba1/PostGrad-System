<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Website1.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

        body{ background-color: #FFF5EE;
             color:#DC143C;
             text-align:center;
        }

        .sidenav {
          height: 100%;
          width: 100%; 
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
      font-size: 25px;
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
    </form>
</body>
</html>
