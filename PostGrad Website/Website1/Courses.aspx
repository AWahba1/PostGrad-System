<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="Website1.Courses" %>

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
        <div style="margin-left: 480px; margin-top:90px;">
            Add New Courses<br />
            <br />
            <asp:TextBox ID="CourseCode" runat="server" placeholder="Course Code" ></asp:TextBox>
            <asp:TextBox ID="CreditHours" runat="server" style="margin-left: 104px" Width="183px" placeholder="Credit Hours" TextMode="Number"></asp:TextBox>
            <asp:TextBox ID="Fees" runat="server" style="margin-left: 108px" placeholder="Course fees" ></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" CssClass="button" runat="server" style="margin-left: 326px"  OnClick="OnAdd" Text="Add Course" />
            <br />
            <br />
            <br />
            Add a Course for a Student<br />
            <br />
            <asp:TextBox ID="CourseID" runat="server" placeholder="Course ID" TextMode="Number" ></asp:TextBox>
            <asp:TextBox ID="StudentID" runat="server" style="margin-left: 104px" Width="183px" placeholder="Student ID" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" CssClass="button" runat="server" style="margin-left: 330px"  OnClick="OnLink" Text="Link" />
            <br />
            <br />
            <br />
            Add a grade for a student of a specific course<br />
            <br />
            <asp:TextBox ID="CourseID1" runat="server" placeholder="Course ID" TextMode="Number" ></asp:TextBox>
            <asp:TextBox ID="StudentID1" runat="server" style="margin-left: 104px" Width="183px" placeholder="Student ID" TextMode="Number"></asp:TextBox>
           <asp:TextBox ID="Grade" runat="server" style="margin-left: 104px" Width="183px" placeholder="Grade" ></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" CssClass="button" runat="server" style="margin-left: 326px"  OnClick="onAddGrade" Text="Add Grade" />
        </div>
    </form>
</body>
</html>
