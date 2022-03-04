<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supervisor.aspx.cs" Inherits="Website1.Supervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 622px;
            width: 1130px;
        }
        .auto-style2 {
            position: absolute;
            top: 18px;
            left: 19px;
            z-index: 1;
            width: 151px;
            height: 37px;
            font-size: 40px;
        }
        .auto-style4 {
            position: absolute;
            top: 19px;
            left: 177px;
            z-index: 1;
            width: 624px;
            height: 43px;
            font-size: 40px;
        }
        .auto-style5 {
            position: absolute;
            top: 124px;
            left: 448px;
            z-index: 1;
            width: 188px;
            height: 54px;
            font-size:35px;
        }
        .auto-style6 {
            position: absolute;
            top: 244px;
            left: 442px;
            z-index: 1;
            right: 75px;
            width: 192px;
             font-size:35px;
        }
        .auto-style7 {
            position: absolute;
            top: 372px;
            left: 411px;
            z-index: 1;
            width: 264px;
            bottom: -7px;
            right: 342px;
             font-size:35px;
           
        }
        .auto-style8 {
            position: absolute;
            top: 178px;
            left: 431px;
            z-index: 1;
            width: 225px;
             font-size:35px;
        }
        .auto-style9 {
            position: absolute;
            top: 303px;
            left: 359px;
            z-index: 1;
            width: 370px;
            font-size:35px;
        }
        .auto-style10 {
            position: absolute;
            top: 440px;
            left: 442px;
            z-index: 1;
            bottom: 0px;
             font-size:35px;
            height: 44px;
        }
        .auto-style11 {
            position: absolute;
            top: 516px;
            left: 465px;
            z-index: 1;
            height: 47px;
             font-size:35px;
            width: 158px;
        }
        .auto-style12 {
            position: absolute;
            top: 16px;
            left: 826px;
            z-index: 1;
            font-size:30px;
        }
        .auto-style13 {
            position: absolute;
            top: 15px;
            left: 979px;
            z-index: 1;
            font-size:30px;
        }
        .auto-style14 {
            position: absolute;
            top: 66px;
            left: 477px;
            z-index: 1;
            font-size:40px;
        }
    </style>
</head>
<body bgcolor="#000099">
    <form id="form1" runat="server">
        <div class="auto-style1">


            <asp:Label ID="Label1"  runat="server" CssClass="auto-style2" ForeColor="Yellow" Text="Welcome"></asp:Label>


            


            <asp:HyperLink ID="HyperLink8" runat="server" CssClass="auto-style12" ForeColor="Yellow" NavigateUrl="Supervisor_Profile.aspx">My Profile</asp:HyperLink>


            


            <asp:Label ID="name" visible=False runat="server" CssClass="auto-style4" Text=" My Name" ForeColor="Yellow"></asp:Label>


            


            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style5" NavigateUrl="MyStudents.aspx" ForeColor="Yellow">My Students</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style6" NavigateUrl="AddDefense.aspx" ForeColor="Yellow">Add Defense</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="auto-style7" ForeColor="Yellow" NavigateUrl="StudentPublication.aspx" Height="40px">View Publications</asp:HyperLink>


            


            <asp:HyperLink ID="HyperLink4" runat="server" CssClass="auto-style8" ForeColor="Yellow" NavigateUrl="CancelThesis.aspx">Cancel Thesis</asp:HyperLink>
            <asp:HyperLink ID="HyperLink5" runat="server" CssClass="auto-style9" ForeColor="Yellow" NavigateUrl="ProgressReportEvaluation.aspx">Evaluate Progress Report</asp:HyperLink>
            <asp:HyperLink ID="HyperLink6" runat="server" CssClass="auto-style10" ForeColor="Yellow" NavigateUrl="AddExaminer.aspx">Add Examiner</asp:HyperLink>
            <asp:HyperLink ID="HyperLink7" runat="server" CssClass="auto-style11" ForeColor="Yellow" NavigateUrl="AddGrade.aspx">Add Grade</asp:HyperLink>


            


            <asp:HyperLink ID="HyperLink9" runat="server" CssClass="auto-style13" ForeColor="Yellow"  NavigateUrl="LogIn.aspx">LogOut</asp:HyperLink>


            


            <asp:Label ID="Label2" runat="server" CssClass="auto-style14" ForeColor="Yellow" Text="Services"></asp:Label>


            


        </div>
    </form>
</body>
</html>
